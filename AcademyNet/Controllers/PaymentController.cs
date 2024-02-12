using AcademyNet.Models;
using BusinessLogicLayer;
using Microsoft.AspNetCore.Mvc;
using Business_Entity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Course = Business_Entity.Course;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace AcademyNet.Controllers
{/// <summary>
/// کنترلر پرداخت
/// </summary>
    public class PaymentController : Controller
    {
        private UserManager<UserApp> _userManager;
        public PaymentController(UserManager<UserApp> userManager)
        {
            this._userManager = userManager;
        }
        //فرض بر این است که به درگاه بانک وصل شده و می خواهیم خرید پرداخت شده را در دیتا بیس ثبت کنیم
        public async Task<IActionResult> PaymentAsync()
        {
            var courseIDs = new List<int>();
            if (HttpContext.Session.GetString("basket") != null)
            {
                courseIDs = JsonConvert.DeserializeObject<List<int>>(HttpContext.Session.GetString("basket"));
                var bllCourse = new BLLCourse();
                //لیستی از خرید ها در متغیری به نام Courses  قرار دارد
                var courses = bllCourse.SearchById(courseIDs);

                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                BLLOrder bLLOrder = new BLLOrder();
                var orderCourses = new List<OrderCourse>();
                foreach (var item in courses)
                {
                    orderCourses.Add(new OrderCourse { CourseID = item.ID });
                }
                bLLOrder.Create(new Order
                {
                    OrderCourses = orderCourses,
                    TotalPrice = courses.Sum(s => s.Price),
                    UserID = user.Id  
                });
                
            }

            return RedirectToAction("Index", "Profile" , new {message = "پرداخت با موفقیت انجام شد." });
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
