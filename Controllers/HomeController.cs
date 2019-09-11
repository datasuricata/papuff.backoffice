using Microsoft.AspNetCore.Mvc;
using papuff.backoffice.Controllers.Base;

namespace papuff.backoffice.Controllers {
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
