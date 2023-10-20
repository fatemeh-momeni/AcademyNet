using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Entity
{
    public class TeacherCourse
    {
        public int ID { get; set; }
        public Human Teacher { get; set; }
        public Course Course { get; set; }

    }
}
