using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace NGOStatuteGenerator
{
    public class Program
    {
        public static IEnumerable<string> ContactTypes { get; private set; }
        public static IEnumerable<string> Executives { get; private set; }
        public static IEnumerable<string> MembershipPeriod { get; private set; }
        public static IEnumerable<string> PersonTypes { get; private set; }
        public static IEnumerable<string> PurposeTypes { get; private set; }

        public static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            TextGeneration.Data.Paragraph para1 = ReadJson<TextGeneration.Data.Paragraph>("resources/paragraph1.json");
            ContactTypes = ReadJson<string[]>("resources/contactTypes.json");
            Executives = ReadJson<string[]>("resources/executives.json");
            MembershipPeriod = ReadJson<string[]>("resources/membershipPeriod.json");
            PersonTypes = ReadJson<string[]>("resources/personTypes.json");
            PurposeTypes = ReadJson<string[]>("resources/purposeTypes.json");

            var genInfo = new Models.GeneralInformation
            {
                City = "Berlin",
                ClubName = "1 KG Schnitzel e.V.",
                PostCode = 10961,
                IsRegistered = true
            };

            var doc = new TextGeneration.Document
            {
                FontName = "Calibri",
                FontSize = 22
            };
            doc.Paragraphs.Add(para1.BuildDocumentParagraph(genInfo));

            File.WriteAllText("D:\\test.rtf", doc.Build(), System.Text.Encoding.ASCII);

            CreateWebHostBuilder(args).Build().Run();
        }

        private static T ReadJson<T>(string path)
        {
            try
            {
                using (var reader = new Newtonsoft.Json.JsonTextReader(new StreamReader(File.Open(path, FileMode.Open), Encoding.UTF8)))
                {
                    var serializer = new Newtonsoft.Json.JsonSerializer();

                    var result = serializer.Deserialize<T>(reader);

                    return result;
                }
            }
            catch
            {
                return default(T);
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
