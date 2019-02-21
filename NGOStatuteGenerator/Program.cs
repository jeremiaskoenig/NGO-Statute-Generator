using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NGOStatuteGenerator
{
    public class Program
    {

        public static IEnumerable<string> CanDecideConditions { get; set; }
        public static IEnumerable<string> PopularVoteOptiones { get; set; }
        public static IEnumerable<string> ExecutiveTieBreakerOptions { get; set; }

        public static IEnumerable<string> GeneralMeetingRepresentedByOptions{ get; set; }

        // Maybe not required
        public static IEnumerable<string> ContactTypes { get; private set; }
        public static IEnumerable<string> Executives { get; private set; }
        public static IEnumerable<string> ExecutiveTasks { get; private set; }
        public static IEnumerable<string> MembershipPeriod { get; private set; }
        public static IEnumerable<string> PersonTypes { get; private set; }
        public static IEnumerable<string> PurposeTypes { get; private set; }

        public static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            // TextGeneration.Data.Paragraph para1 = ReadJson<TextGeneration.Data.Paragraph>(GetParagraphResourceFileName(1));
            ContactTypes = ReadJson<string[]>(GetEnumResourceFileName("contactTypes"));
            Executives = ReadJson<string[]>(GetEnumResourceFileName("contactTypes"));
            ExecutiveTasks = ReadJson<string[]>(GetEnumResourceFileName("contactTypes"));
            MembershipPeriod = ReadJson<string[]>(GetEnumResourceFileName("contactTypes"));
            PersonTypes = ReadJson<string[]>(GetEnumResourceFileName("contactTypes"));
            PurposeTypes = ReadJson<string[]>(GetEnumResourceFileName("contactTypes"));

            CanDecideConditions = ReadJson<string[]>(GetEnumResourceFileName("contactTypes"));
            PopularVoteOptiones = ReadJson<string[]>(GetEnumResourceFileName("contactTypes"));
            ExecutiveTieBreakerOptions = ReadJson<string[]>(GetEnumResourceFileName("contactTypes"));
            GeneralMeetingRepresentedByOptions = ReadJson<string[]>(GetEnumResourceFileName("contactTypes"));

            var genInfo = new Models.GeneralInformation
            {
                City = "Berlin",
                ClubName = "1 KG Schnitzel e.V.",
                PostCode = 10961
            };

            var doc = new TextGeneration.Document
            {
                FontName = "Calibri",
                FontSize = 22
            };
            //doc.Paragraphs.Add(para1.BuildDocumentParagraph(genInfo));

            File.WriteAllText("D:\\test.rtf", doc.Build(), System.Text.Encoding.ASCII);

            CreateWebHostBuilder(args).Build().Run();
        }

        private static string GetEnumResourceFileName(string enumName)
        {
            return Path.Combine("resources", "enums", $"{enumName}.json");
        }

        private static string GetParagraphResourceFileName(int paragraph)
        {
            return Path.Combine("resources", "enums", $"paragraph{paragraph}.json");
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
