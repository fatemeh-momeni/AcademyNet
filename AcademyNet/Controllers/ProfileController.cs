using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AcademyNet.Controllers
{
    // [Authorize]
    public class ProfileController : Controller
    {
        //مقدار را از بسکت می گیرد و اکتیو می کند مقدار سبد خرید در این ویو را اکتیو می کند و آن قسمت ریز می شود
        public IActionResult Index(string showBasket, string message = null)
        {
           
            if (!string.IsNullOrWhiteSpace(message))
            {
                ViewBag.SuccessPayment = message;
            }
            else ViewBag.showBasket = "active";
            return View();
        }
    }
}
