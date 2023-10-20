using Business_Entity;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class BLLCourse
    {
        public void Create(Course course)
        {
            DALCourse dALCourse = new DALCourse();
            dALCourse.Create(course);
        }
        public void Update(Course course)
        {
            DALCourse dALCourse = new DALCourse();
            dALCourse.Update(course);
        }
        public List<Course> Read()
        {
            DALCourse dALCourse = new DALCourse();
            return dALCourse.Read();

        }
        public List<Course> Search(List<string> tags)
        {
            DALCourse dALCourse = new DALCourse();
            return dALCourse.Search(tags);

        }
        public int GetCountOfAllRecords()
        {
            DALCourse dALCourse = new DALCourse();
            return dALCourse.GetCountOfAllRecords();
        }
        public List<Course> GetSkip(int skip)
        {
            DALCourse dALCourse = new DALCourse();
            return dALCourse.GetSkip(skip);
        }
    }
}
