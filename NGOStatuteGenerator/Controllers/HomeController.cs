using Microsoft.AspNetCore.Mvc;
using NGOStatuteGenerator.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace NGOStatuteGenerator.Controllers
{
    public class HomeController : Controller
    {
        [HttpPost]
        public IActionResult Index(Statute model, string handler)
        {
            if (handler == "findPurpose")
            {
                model.PurposeInformation.FindPurpose();
                Response.Redirect(Request.Path);
            }
            else if (handler == "finalSubmit")
            {
                //TODO: Render RTF and send as File to Download
                Response.Redirect(Request.Path);
                return File(new byte[] { }, "application/rtf");
            }

            

            model.PurposeInformation.FindPurpose();
            var doc = new TextGeneration.Document
            {
                FontName = "Verdana",
                FontSize = 22
            };

            for (int i = 1; i <= 12; i++)
            {
                var paragraphInfo = Program.ReadJson<TextGeneration.Data.Paragraph>(Program.GetParagraphResourceFileName(i));
                doc.Paragraphs.Add(paragraphInfo.BuildDocumentParagraph(model));
            }
            
            System.IO.File.WriteAllText("D:\\test.rtf", doc.Build(), System.Text.Encoding.ASCII);
            return View(model);
        }



        [HttpGet]
        public IActionResult Index()
        {
            return View(new Statute());
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
