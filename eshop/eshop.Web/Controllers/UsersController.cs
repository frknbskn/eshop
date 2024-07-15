using eshop.Application;
using eshop.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace eshop.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        public IActionResult Login(string? gidilecekSayfa)
        {
            UserLoginViewModel userLoginViewModel = new UserLoginViewModel() { ReturnUrl=gidilecekSayfa};
            return View(userLoginViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginViewModel userLogin,string? gidilecekSayfa)
        {
            var user = userService.ValidateUser(userLogin.UserName,userLogin.Password);
            if (user != null)
            {
                var claims = new Claim[]
                {
                    new Claim(ClaimTypes.Name,user.UserName),
                    new Claim(ClaimTypes.Email,user.Email),
                    new Claim(ClaimTypes.Role,user.Role)
                };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
               await HttpContext.SignInAsync(claimsPrincipal);
                if (!string.IsNullOrEmpty(gidilecekSayfa) && Url.IsLocalUrl(gidilecekSayfa))
                {
                    return Redirect(gidilecekSayfa);
                }
                return Redirect("/");
            }
            ModelState.AddModelError("login", "Hatalı kullanıcı ya da şifre");
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
