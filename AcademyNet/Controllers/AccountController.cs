using AcademyNet.Models;
using Business_Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Runtime.CompilerServices;

namespace AcademyNet.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<UserApp> _userManager;
        private SignInManager<UserApp> _signInManager;
        public AccountController(UserManager<UserApp> userManager, SignInManager<UserApp> signInManager)
        {
            this._userManager = userManager;
            _signInManager = signInManager;
        }

        //نمایش
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Register register)
        {
            var user = await _userManager.FindByNameAsync(register.UserName);
            if (user == null)
            {
                ModelState.AddModelError("register", "کاربر با این نام کاربری پیدا نشد.");
                return View(register);
            }
            var signInResult = await _signInManager.PasswordSignInAsync(user, register.Password, true, false);
            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError("", "نام کاربری یا رمز عبور شما اشتباه است .");
                return View(register);
            }

            return View();
        }
        //فقط ویو را نمایش می دهد
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Register register)
        {
            var user = await _userManager.FindByNameAsync(register.UserName);
            if (user != null)
            {
                ModelState.AddModelError("UserName", "این نام کاربری در سیستم موجود می باشد.");
                return View(register);
            }
            if (register.Password != register.ConfirmPassword)
            {
                ModelState.AddModelError("", "رمز عبور یکسان نیست");
                return View(register);

            }
            var userApp = new UserApp
            {
                UserName = register.UserName,
                Email = register.Email,
                FirstName = register.FirstName,
                LastName = register.LastName,
            };
            var addResult = await _userManager.CreateAsync(userApp, register.Password);
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
