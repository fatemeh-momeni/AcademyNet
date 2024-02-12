using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Business_Entity
{
    public class Order
    {
        public int ID { get; set; }
       // برای انتصاب یوزرآیدی در پرداخت
        public string UserID { get; set; }
        //شخصی که خرید کرده
        public UserApp User { get; set; }
        public float TotalPrice{ get; set; }
        //لیست محصولاتی که خرید کرده
        // بین دو جدول  n  رابطه 1 به   
        public List<OrderCourse> OrderCourses { get; set; }

    }
}
