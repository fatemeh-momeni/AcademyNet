using BusinessLogicLayer;
using Microsoft.AspNetCore.Mvc;

namespace AcademyNet.ViewComponents.User
{
    public class TeachersViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            BusinessLogicLayer.BLLHuman bLLHuman = new BusinessLogicLayer.BLLHuman();   
            return View("_Teachers", bLLHuman.Read());   
        }
    }
}
