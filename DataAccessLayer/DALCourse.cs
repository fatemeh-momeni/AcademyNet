using Business_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DALCourse
    {
        public void Create(Course course)
        {
            DB db = new DB();
            db.Course.Add(course);
            db.SaveChanges();
        }
        public List<Course> Read()
        {
            DB db = new DB();
            return db.Course.ToList();

        }
        public void Update(Course courses)
        {
            DB db = new DB();
            var q = from i in db.Course where i.ID == courses.ID select i;
            Course course = new Course();
            course = q.Single();
            course.ID = courses.ID;
            course.VideoIntro = courses.VideoIntro;
            course.CourseDetailFiles = courses.CourseDetailFiles;
            course.TeacherCourses = courses.TeacherCourses;
            course.Humans = courses.Humans;
            course.Price = courses.Price;
            course.Descript = courses.Descript;
            course.TotalTime = courses.TotalTime;
            course.Title = courses.Title;
            db.SaveChanges();

        }
        public int GetCountOfAllRecords()
        {
            DB db = new DB();
            return db.Course.Count();
        }
        public List<Course> GetAllRecords()
        {
            DB db = new DB();
            var q = from i in db.Course select i;
            return q.ToList();
        }

        public List<Course> GetSkip(int skip)
        {
            int getTenOfRecords = skip * 10;
            DB db = new DB();
            var q = db.Course.Skip(getTenOfRecords).Take(10);
            return q.ToList();
        }
        public List<Course> Search(List<string> tags)
        {
            List<Course> courses = new List<Course>();
            foreach (string item in tags)
            {
                DB db = new DB();
                var query = from i in db.Course
                            where (i.Price == Convert.ToInt32(item) || i.Title.Contains(item.ToString()))
                            select i;
                courses = courses.Concat(query.ToList()).ToList();

            }
            return courses;
        }
    }
}
