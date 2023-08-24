using Microsoft.AspNetCore.Mvc;
using Business_Entity;
using BusinessLogicLayer;
using Microsoft.AspNetCore.Hosting;

namespace AcademyNet.Controllers.Admin
{
    public class TeacherController : Controller
    {
        private  IWebHostEnvironment webHostEnvironment;
        public TeacherController(IWebHostEnvironment _webHostEnvironment)
        {
            webHostEnvironment=_webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View("Create");
        }
    }
}
