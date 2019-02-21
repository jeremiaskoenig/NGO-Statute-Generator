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
            }
            else if (handler == "finalSubmit")
            {
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

                byte[] result;

                string docText = doc.Build(model);
                result = System.Text.Encoding.ASCII.GetBytes(docText);

                return File(result, "application/rtf", "satzung.rtf", true);
            }

            
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
