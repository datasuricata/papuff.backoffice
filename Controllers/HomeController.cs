using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using papuff.backoffice.Controllers.Base;

namespace papuff.backoffice.Controllers {

  //  [Authorize]
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous] //todo remove this after create
        public IActionResult FirstSteps(){
            return View();
        }
    }
}
