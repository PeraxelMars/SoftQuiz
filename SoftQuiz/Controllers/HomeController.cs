using SoftQuiz.Extensions;
using SoftQuiz.Services;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SoftQuiz.Controllers
{
    [OutputCache(Duration = 0)]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<string> availableQuiz = QuizDataService.ListAvailableQuiz(this.GetApplicationRootPath());

            return View(availableQuiz);
        }

        [Route("Home/Quiz/{selectedQuiz}")]
        public ActionResult Quiz(string selectedQuiz)
        {
            ViewBag.SelectedQuiz = selectedQuiz;

            return View();
        }
    }
}