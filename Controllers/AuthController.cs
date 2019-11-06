﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using papuff.backoffice.Controllers.Base;
using papuff.backoffice.Models.Helpers;
using papuff.backoffice.Models.Request;
using papuff.backoffice.Models.Response;
using System;
using System.Net.Http;
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

            request.Password = request.Password.Encrypt();
            var user = await Post<AuthResponse>("user/auth", request);

            if (user != null) {
                var properties = new AuthenticationProperties {
                    AllowRefresh = false,
                    IsPersistent = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(60)
                };

                var claims = new[]{
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.Hash, user.Token),
                        new Claim(ClaimTypes.Name, user.Name ?? "Não Informado"),
                        new Claim(ClaimTypes.DateOfBirth, DateTime.Now.ToString()),
                        new Claim(ClaimTypes.Role, user.Type.ToString()),
                    };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(principal, properties);
            }

            return RedirectToAction("Index", "Home");
        }
        [Authorize]
        public async Task<IActionResult> Logout(string returnUrl) {
            ViewBag.ReturnUrl = returnUrl;
            return await SingOut();
        }

        public IActionResult Register() {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterRequest request) {

            if(ModelState.IsValid){
                await Post<dynamic>("user/single", request);

                SetMessage(Models.MessageType.Success,
                    "Bem vindo marujo, confirme seu e-mail se não quiser fugir da prancha");
            }

            return RedirectToAction(nameof(Login));
        }

        private async Task<IActionResult> SingOut() {
            if (User.Identity.IsAuthenticated)
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Login));
        }

        public async Task<IActionResult> PostalCode(string value) {

            var uri = new UriBuilder("https://viacep.com.br/") {
                Path = $"ws/{value}/json",
            };

            using (HttpClient client = new HttpClient()) {
                var response = await client.GetAsync(uri.ToString());

                if (response.IsSuccessStatusCode) {
                    var obj = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<dynamic>(obj);

                    // todo
                    //stateId = estadoRepository.GetByName(result.uf)?.Id;
                    //cityId = cidadeRepository.GetByName(result.localidade)?.Id;

                    return new JsonResult(new AddressRequest {
                        PostalCode = result.cep,
                        AddressLine = result.logradouro,
                        City = result.localidade,
                        District = result.bairro,
                        StateProvince = result.uf,
                    });

                    
                }
                else
                    throw new Exception("Código postal não localizado, tente novamente.");
            }
        }
    }
}