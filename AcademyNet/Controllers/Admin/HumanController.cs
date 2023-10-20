using Microsoft.AspNetCore.Mvc;
using Business_Entity;
using BusinessLogicLayer;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json.Linq;

namespace AcademyNet.Controllers.Admin
{
    public class HumanController : Controller
    {
        private IWebHostEnvironment webHostEnvironment;
        public HumanController(IWebHostEnvironment _webHostEnvironment)
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
        public IActionResult ShowAllTeachersAccount()
        {
            BLLHuman bLLHuman = new BLLHuman();

            return View("ShowTeachersAccount",bLLHuman.GetSkip(0));
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
        public void Update(Models.Human human)
        {
            BLLHuman bLLHuman = new BLLHuman();

            Business_Entity.Human businessHuman = new Human();
            businessHuman.Id = human.Id;
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
            bLLHuman.Update(businessHuman);

        }
        public JsonResult HumanSearchJson()
        {
            return Json(new { redirect = "Search" });
        }
        public IActionResult Search(string tags)
        {
            JArray jsonArray= new JArray(tags);
            dynamic data = JArray.Parse(jsonArray[0].ToString());
            List<string> split = new List<string>();
            foreach (dynamic item in data)
            {
                split.Add(item.tag.ToString()); 

            }
            BLLHuman bLLHuman= new BLLHuman();
            List<Human> humans = bLLHuman.Search(split);
            return View("ShowTeachersAccount", humans);
        }
        public IActionResult GetSkip(int skip)
        {
            BLLHuman bLLHuman = new BLLHuman();
            return View("ShowTeachersAccount", bLLHuman.GetSkip(skip));

        }
    }
}
