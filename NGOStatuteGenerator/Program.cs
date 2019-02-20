using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace NGOStatuteGenerator
{
    public class Program
    {
        public static IEnumerable<string> PersonTypes;
        public static IEnumerable<string> PurposeTypes;
        public static IEnumerable<string> ExecutiveTypes;
        public static void Main(string[] args)
        {
            PersonTypes = new List<string>();
            PurposeTypes = new List<string>();
            ExecutiveTypes = new List<string>();
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
