
using BikeLibrary.BLL;
using BikeLibrary.DBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsBikeUniverse.MockData
{
    public class MockOrders : IOrderRepository
    {
        List<Order> orders;
        public MockOrders()
        {
            orders = new List<Order>();
        }
        public bool AddOrder(Order order)
        {
            orders.Add(order);
            return true;
        }

        public List<Order> GetAll()
        {
            return orders;
        }

        public Order GetOrder(int id)
        {
            return orders.FirstOrDefault(o => o.GetId() == id);
        }

        public List<Order> GetOrdersByStatus(string status)
        {
            return orders.Where(o => o.GetStatus() == status).ToList();
        }

        public List<Order> GetUserOrders(int accid)
        {
            return orders.Where(o => o.GetAccid() == accid).ToList();
        }

        public void UpdateStatus(int orderid, string newstatus)
        {
            Order o = orders.FirstOrDefault(o => o.GetId() == orderid);
            if (o != null)
            {
                o.ChangeStatus(newstatus);
            }
        }
    }
}
