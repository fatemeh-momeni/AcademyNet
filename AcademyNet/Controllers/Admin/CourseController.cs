using BusinessLogicLayer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Business_Entity;
using BusinessLogicLayer;
using AcademyNet.Models;
using Course = Business_Entity.Course;

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
            BLLHuman bLLHuman = new BLLHuman();
            ViewBag.BLLHuman = bLLHuman.GetAllRecords();
            return View();
        }

        //public IActionResult GetAllRecords()
        //{
        //    BLLCourse bLLCourse = new BLLCourse();
        //    ViewBag.BLLCourse = bLLCourse.GetAllRecords();
        //    return View();
        //}


        //ریختن دیتا مدل در مدل ویو
        public IActionResult Edit(int id)
        {
            BLLCourse bLLCourse = new BLLCourse();
            var bECourse = bLLCourse.SearchById(id);

            BLLHuman bLLHuman = new BLLHuman();
            ViewBag.teachers = bLLHuman.GetAllRecords();

            var modelCourse = new Models.Course
            {
                Title = bECourse.Title,
                Price = bECourse.Price,
                Descript = bECourse.Descript,
                TotalTime = bECourse.TotalTime,
                VideoUrl = bECourse.VideoIntro,
                ID = bECourse.ID,
                teachers = bECourse.TeacherCourses.Select(s => s.Teacher.Id).ToList()

            };

            return View(modelCourse);
        }
        //ریختن مدل ویو در دیتا مدل
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Models.Course course)
        {
            BLLCourse bLLCourse = new BLLCourse();
            var bECourse = bLLCourse.SearchById(course.ID);
            bECourse.ID = course.ID;
            bECourse.Title = course.Title;
            bECourse.Price = course.Price;
            bECourse.Descript = course.Descript;
            bECourse.TotalTime = course.TotalTime;
    
            if (course.VideoIntro != null)
            {
                UploadFile uploadFile = new UploadFile(webHostEnvironment);
                bECourse.VideoIntro = uploadFile.UploadVideo(course.VideoIntro);
            }
            bLLCourse.Update(bECourse);
            //چرا از redirect استفاده شد؟
            return RedirectToAction(nameof(ShowAllCourse));
        }

        public IActionResult Create()
        {
            return View("Create");
        }
        //جزئیات دوره
        public IActionResult Details(int id)
        {
            BLLCourse bLLCourse = new BLLCourse();
            Course course = new Course();
            course = bLLCourse.SearchById(id);

            return View(course);
        }
        public IActionResult ShowAllCourse()
        {
            BLLCourse bLLCourse = new BLLCourse();
            ViewBag.courses = bLLCourse.GetAllRecords();
            return View();
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

            Business_Entity.Course businessCourse = new Business_Entity.Course();
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
        public IActionResult Search(string search)
        {
            BLLCourse bLLCourse = new BLLCourse();
            List<Business_Entity.Course> courses = bLLCourse.Search(search);
            ViewBag.courses = courses;
            return View("ShowAllCourse", courses);
        }
        public IActionResult GetSkip(int skip)
        {
            BLLCourse bLLCourse = new BLLCourse();
            return View("ShowTeachersAccount", bLLCourse.GetSkip(skip));

        }
    }
}
