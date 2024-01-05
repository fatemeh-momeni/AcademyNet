using Business_Entity;
using Microsoft.EntityFrameworkCore;
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

        public List<Course> GetAllRecordsByTeachers()
        {
            DB db = new DB();
            var q = from i in db.Course.Include(s=>s.TeacherCourses).ThenInclude(s=>s.Teacher)  select i;
            return q.ToList();
        }


        public List<Course> GetSkip(int skip)
        {
            int getTenOfRecords = skip * 10;
            DB db = new DB();
            var q = db.Course.Skip(getTenOfRecords).Take(10);
            return q.ToList();
        }
        public List<Course> Search(string search)
        {
            int n = 0;
            DB db = new DB();
            var query = from i in db.Course
                        where i.Title.Contains(search.ToString())    
                        select i;
            return query.ToList();
        }
        public Course SearchById(int id)
        {
            DB db = new DB();
            var query = from i in db.Course.Include(s => s.TeacherCourses).ThenInclude(t=>t.Teacher)
                        where i.ID == id    
                        select i;
            return query.SingleOrDefault();
        }
    }
}
