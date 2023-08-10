using Microsoft.AspNetCore.Mvc;

namespace AcademyNet.Controllers.Admin
{
    public class TeacherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View("Register");
        }
    }
}
