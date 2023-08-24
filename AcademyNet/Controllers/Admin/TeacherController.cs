using Microsoft.AspNetCore.Mvc;
using Business_Entity;
using BusinessLogicLayer;
using Microsoft.AspNetCore.Hosting;

namespace AcademyNet.Controllers.Admin
{
    public class TeacherController : Controller
    {
        private IWebHostEnvironment webHostEnvironment;
        public TeacherController(IWebHostEnvironment _webHostEnvironment)
        {
            webHostEnvironment = _webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View("Create");
        }
        [HttpPost]
        public void Create(Models.Human human)
        {
            BLLHuman bLLHuman = new BLLHuman();

            Business_Entity.Human businessHuman = new Human();
            businessHuman.Name = human.Name;
            businessHuman.Family = human.Family;
            businessHuman.Email = human.Email;
            businessHuman.gender = (Human.Gender)human.gender;
            businessHuman.Password = human.Password;
            businessHuman.role = (Human.Role)human.role;
            UploadFile uploadFile = new UploadFile(webHostEnvironment);
            if (human.Picture != null)
            {
                businessHuman.Picture = uploadFile.Upload(human.Picture);
            }
            bLLHuman.Create(businessHuman);


        }
    }
}
