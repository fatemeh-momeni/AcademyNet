using Business_Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DALOrder
    {
        public void Create(Order order)
        {
            DB db = new DB();
            db.Order.Add(order);
            db.SaveChanges();
        }


        public List<Order> GetSkip(int skip)
        {
            int getTenOfRecords = skip * 10;
            DB db = new DB();
            var q = db.Order.Skip(getTenOfRecords).Take(10);
            return q.ToList();
        }

        public Order SearchById(int id)
        {
            DB db = new DB();
            var query = from i in db.Order
                        where i.ID == id
                        select i;
            return query.SingleOrDefault();
        }
        public List<Order> GetAllRecords()
        {
            DB db = new DB();
            var q = from i in db.Order select i;
            return q.ToList();
        }
    }
}
