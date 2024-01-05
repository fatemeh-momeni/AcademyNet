using Microsoft.AspNetCore.Mvc;


namespace AcademyNet.ViewComponents.User
{

    public class CourseListViewComponent : ViewComponent
    {
        //چرا از invokeAsync استفاده شد؟219
        public async Task <IViewComponentResult> InvokeAsync()
        {
            BusinessLogicLayer.BLLCourse bLLCourse = new BusinessLogicLayer.BLLCourse();
            var courses = bLLCourse.GetAllRecordsByTeachers();

            return View(courses);
        }
    }
}
