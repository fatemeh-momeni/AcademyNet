using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Entity
{
    public class Course
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public float TotalTime { get; set; }
        public List<Human> Humans { get; set; } = new List<Human>();
        public string Descript { get; set; }
        public string VideoIntro { get; set; }
        public float Price { get; set; }
        public List<CourseDetailFile> CourseDetailFiles { get; set; } = new List<CourseDetailFile>();
        public List<TeacherCourse> TeacherCourses { get; set; } = new List<TeacherCourse>();
        public List<OrderCourse> OrderCourses { get; set; }  

    }


}

