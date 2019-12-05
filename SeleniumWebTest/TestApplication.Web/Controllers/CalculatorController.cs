using Microsoft.AspNetCore.Mvc;

namespace TestApplication.Web.Controllers
{
    public class CalculatorController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(int summandOne, int summandTwo)
        {
            return View(summandOne + summandTwo);
        }

    }
}
