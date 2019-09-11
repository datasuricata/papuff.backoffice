using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using papuff.backoffice.Controllers.Base;
using papuff.backoffice.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace papuff.backoffice.Controllers {
    [Authorize]
    public class UserController : BaseController {

        public async Task<IActionResult> Index() {
            var user = await Get<List<UserResponse>>("user/all");
            return View(user);
        }

        public IActionResult Create() {
            return View();
        }
    }
}
