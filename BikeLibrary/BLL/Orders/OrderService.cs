using BikeClassLibrary.DBL;
using BikeLibrary.BLL.Interfaces;
using BikeLibrary.DBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeLibrary.BLL
{
    public class OrderService : IOrderService
    {
        private List<Order> orders;
        IOrderRepository dbOrders;

        public OrderService(IOrderRepository dbOrders) 
        {
            this.dbOrders = dbOrders;
            orders = dbOrders.GetAll();
        }

        public List<Order> GetOrders() { return orders; }

        public Order GetOrder(int id)
        {
            orders = dbOrders.GetAll();
            return (Order)orders.Where(o => o.GetId() == id);
        }

        public void AddOrder(Order order)
        {
            dbOrders.AddOrder(order);
        }

        public void UpdateStatus(Order order)
        {
            dbOrders.UpdateStatus(order);
        }

        public void SetOrders()
        {
            orders = dbOrders.GetAll();
        }

        public List<Order> GetOrdersByStatus(string status)
        {
            orders = dbOrders.GetAll();
            return orders.Where(o => o.GetStatus() == status).ToList();

        }

        
    }
}
