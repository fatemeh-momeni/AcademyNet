using Business_Entity;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class BLLOrder
    {
        public void Create(Order order)
        {
            DALOrder dALOrder = new DALOrder();
            dALOrder.Create(order);
        }
        public List<Order> GetAllRecords()
        {
            DALOrder dALOrder = new DALOrder();
            return dALOrder.GetAllRecords();
        }

        public List<Order> GetSkip(int skip)
        {
            DALOrder dALOrder = new DALOrder();
            return dALOrder.GetSkip(skip);
        }

        public Order SearchById(int id)
        {
            DALOrder dALOrder = new DALOrder();
            return dALOrder.SearchById(id);
        }
    }
}
