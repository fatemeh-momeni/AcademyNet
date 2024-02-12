using BusinessLogicLayer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AcademyNet.Controllers
{
    public class OrderController : Controller
    {
        public async Task<IActionResult> AddToBasket(int courseID)
        {
            var basketList = new List<int>();
            if (HttpContext.Session.GetString("basket") != null)
            {
                basketList = JsonConvert.DeserializeObject<List<int>>(HttpContext.Session.GetString("basket")).ToList();
            }
            basketList.Add(courseID);
            HttpContext.Session.SetString("basket", JsonConvert.SerializeObject(basketList)); //تبدیل به جیسان
            return RedirectToAction("Details", "Course", new { courseID = courseID });
        }
        public IActionResult ShowBasket()
        {
            
            return View();
        }
    }
}
