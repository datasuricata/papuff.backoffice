using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using papuff.backoffice.Controllers.Base;

namespace papuff.backoffice.Controllers {

    [Authorize]
    public class SiegeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}