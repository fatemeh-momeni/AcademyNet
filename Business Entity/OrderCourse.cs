using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Entity
{
    public class OrderCourse
    {
        public int ID { get; set; }
        //برای جستجو راحت تر است فیلد آیدی هر جدول را قرار دهیم
        public int CourseID { get; set; }
        public Course Course { get; set; }
        public int OrderID { get; set; }
        public Order Order { get; set; }
    }
}
