using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using papuff.backoffice.Controllers.Base;
using papuff.backoffice.Models;
using papuff.backoffice.Models.Helpers;
using papuff.backoffice.Models.Request;
using papuff.backoffice.Models.Response;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace papuff.backoffice.Controllers {
    public class AuthController : BaseController {

        public IActionResult Login() {
            return View(new AuthRequest());
        }

        [HttpPost]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(AuthRequest request) {

            try {

                request.Password = request.Password.Encrypt();

                var user = await Post<AuthResponse>("user/auth", request);

                if (user != null) {
                    var properties = new AuthenticationProperties {
                        AllowRefresh = false,
                        IsPersistent = true,
                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(40)
                    };

                    var claims = new[]{
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.Hash, user.Token),
                        new Claim(ClaimTypes.Name, user.Name),
                        new Claim(ClaimTypes.Role, user.Type.ToString()),
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(principal, properties);

                    Notify($"Olá {user.Name}!", MessageType.Info);
                }

            } catch (Exception e) {
                Notify(e.Message, MessageType.Exception);
            }

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public async Task<IActionResult> Logout(string returnUrl) {
            ViewBag.ReturnUrl = returnUrl;
            return await SingOut();
        }

        private async Task<IActionResult> SingOut() {
            if (User.Identity.IsAuthenticated)
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Login));
        }
    }
}
