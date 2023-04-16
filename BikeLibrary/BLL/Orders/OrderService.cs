using BikeClassLibrary.DBL;
using BikeLibrary.DBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeLibrary.BLL
{
    public class OrderService 
    {
        private List<Order> orders;
        DBOrders dbOrders;
        ConStr con;

        public OrderService() 
        {
            con= new ConStr();
            dbOrders = new DBOrders(con.GetConnectionString());
            orders = dbOrders.GetAll();
        }

        public List<Order> GetOrders() { return orders; }

        public Order GetOrder(int id)
        { 
            return (Order)orders.Where(o => o.GetId() == id);
        }

        public void AddOrder(Order order)
        {
            dbOrders.AddOrder(order);
            SetOrders();
        }

        public void UpdateStatus(Order order)
        {
            dbOrders.UpdateStatus(order);
            SetOrders();
        }

        public void SetOrders()
        {
            orders = dbOrders.GetAll();
        }

        public List<Order> GetOrdersByStatus(string status)
        {
            return orders.Where(o => o.GetStatus() == status).ToList();

        }

        
    }
}
