using Microsoft.AspNetCore.Mvc;
using NGOStatuteGenerator.Models;
using System.Collections.Generic;

namespace NGOStatuteGenerator.Controllers
{
    public class StatuteController : Controller
    {
        [HttpPost]
        public IActionResult Statute(Statute model, string handler)
        {

            var doc = new TextGeneration.Document
            {
                FontName = "Verdana",
                FontSize = 16
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

        [HttpPost]               
        public IActionResult PurposeDescription(string purposeType, string purposeFreeText)
        {
            return Json(PurposeInformation.FindPurpose(purposeType, purposeFreeText));         
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StatuteGenerator()
        {
            ViewData["Message"] = "Your application description page.";

            return View(new Statute());
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
