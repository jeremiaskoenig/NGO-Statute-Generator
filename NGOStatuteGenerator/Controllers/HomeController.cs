using Microsoft.AspNetCore.Mvc;
using NGOStatuteGenerator.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace NGOStatuteGenerator.Controllers
{
    public class HomeController : Controller
    {
        [HttpPost]
        /// <remarks>
        /// All models need to have "model" in their variable name
        /// </remarks>
        public IActionResult Index(Statute model, string handler, GeneralInformation generalModel)
        {
            if (generalModel != null)
            {
                model.GeneralInformation = generalModel;
            }



            if (handler == "findPurpose")
            {
                model.PurposeInformation.FindPurpose();
            }
            else if (handler == "finalSubmit")
            {
                var doc = new TextGeneration.Document
                {
                    FontName = "Verdana",
                    FontSize = 22,
                    FontSizeHeader = 24
                };
                
                foreach (string paragraphFileName in Program.GetParagraphResources())
                {
                    var paragraphInfo = Program.ReadJson<TextGeneration.Data.Paragraph>(paragraphFileName);
                    doc.Paragraphs.Add(paragraphInfo.BuildDocumentParagraph(model));
                }

                byte[] result;

                result = System.Text.Encoding.ASCII.GetBytes(doc.Build(model));

                return File(result, "application/rtf", $"Satzung - {model.GeneralInformation.ClubName}.rtf", true);
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
