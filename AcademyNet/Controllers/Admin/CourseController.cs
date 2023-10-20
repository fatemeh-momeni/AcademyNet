using BusinessLogicLayer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Business_Entity;
using BusinessLogicLayer;
using AcademyNet.Models;

namespace AcademyNet.Controllers.Admin
{
    public class CourseController : Controller
    {
        private IWebHostEnvironment webHostEnvironment;
        public CourseController(IWebHostEnvironment _webHostEnvironment)
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
            BLLCourse bLLCourse = new BLLCourse();

            return View("ShowTeachersAccount", bLLCourse.GetSkip(0));
        }

        [HttpPost]
        public void Create(Models.Course course)
        {
            BLLCourse bLLCourse = new BLLCourse();
            Business_Entity.Course businessCourse = new Business_Entity.Course();
            businessCourse.Price = course.Price;
            businessCourse.Descript = course.Descript;
            businessCourse.ID = course.ID;
            businessCourse.TotalTime = course.TotalTime;
            businessCourse.Title = course.Title;
            UploadFile uploadFile = new UploadFile(webHostEnvironment);
            businessCourse.VideoIntro = uploadFile.UploadVideo(course.VideoIntro);
        
            bLLCourse.Create(businessCourse);

        }
        public void Update(Models.Course course)
        {
            BLLCourse bLLCourse = new BLLCourse();

            Business_Entity.Course businessCourse = new  Business_Entity.Course();
            businessCourse.ID = course.ID;
            businessCourse.Price = course.Price;
            businessCourse.Descript = course.Descript;
            businessCourse.TotalTime = course.TotalTime;
            businessCourse.Title = course.Title;
            UploadFile uploadFile = new UploadFile(webHostEnvironment);
            businessCourse.VideoIntro = uploadFile.UploadVideo(course.VideoIntro);

            bLLCourse.Update(businessCourse);


        }
        public JsonResult HumanSearchJson()
        {
            return Json(new { redirect = "Search" });
        }
        public IActionResult Search(string tags)
        {
            JArray jsonArray = new JArray(tags);
            dynamic data = JArray.Parse(jsonArray[0].ToString());
            List<string> split = new List<string>();
            foreach (dynamic item in data)
            {
                split.Add(item.tag.ToString());

            }
            BLLCourse bLLCourse = new BLLCourse();
            List<Business_Entity.Course> courses = bLLCourse.Search(split);
            return View("ShowTeachersAccount", courses);
        }
        public IActionResult GetSkip(int skip)
        {
            BLLCourse bLLCourse = new BLLCourse();
            return View("ShowTeachersAccount", bLLCourse.GetSkip(skip));

        }
    }
}
