using Application.Interfaces;
using DataLayer.Models.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System.Text.RegularExpressions;
using DataLayer.Models;
using DataLayer;

namespace Presentation.Controllers
{

    public class AccountController : Controller
    {

        IUser _user;



        public AccountController(IUser user)
        {
            _user = user;

        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login)
        {

            if (!ModelState.IsValid)
            {
                return View(login);
            }

            var user = await _user.Login(login);

            if (user == null)
            {
                ModelState.AddModelError("username", "کاربری با مشخصات داده شده یافت نشد");

                return View();
            }

            var roles = await _user.GetAllUserRoles(user.UserId);

            var claims = new List<Claim>();
           

            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()));
            claims.Add(new Claim(ClaimTypes.Name, user.UserName));
            claims.Add(new Claim(ClaimTypes.Email, user.Email));

            foreach (var item in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, item));

            }



            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);

            var properties = new AuthenticationProperties
            {
                IsPersistent = login.RememberMe,

            };

            await HttpContext.SignInAsync(principal, properties);



            return RedirectToPage("/UserPanel/Index");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }

        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }


            if (!Regex.IsMatch(model.Password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*\W).+$"))
            {
                ModelState.AddModelError(string.Empty, "Password must have at least one lowercase letter, one uppercase letter, one digit, and one special character.");
                return View(model);
            }

            if (await _user.IsExistUser(model))
            {
                ModelState.AddModelError("UserName", "این نام کاربری از قبل موجود است");
                return View(model);
            }

            User user = new User()
            {
                UserName = model.UserName,
                Password = model.Password,
                AvatarName = "Default.jpg",
                Email = model.Email,
                IsAdmin = false
            };

            await _user.AddUser(user);

            return View("SuccessFullRegister");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

    }


}
