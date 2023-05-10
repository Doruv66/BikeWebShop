using BikeClassLibrary;
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
    public class OrderService
    {
        private List<Order> orders;
        IOrderRepository dbOrders;

        public OrderService(IOrderRepository dbOrders) 
        {
            this.dbOrders = dbOrders;
        }

        public List<Order> GetOrders() { return dbOrders.GetAll(); }

        public Order GetOrder(int id)
        {
            return dbOrders.GetOrder(id);
        }

        public void AddOrder(Order order, Inventory inventory)
        {
            foreach (var item in order.GetItems())
            {
                Bike bike = inventory.GetBike(item.bikeid);
                if (bike.GetStock() < item.quantity)
                {
                    throw new ArgumentException("Not enough stock for bike " + bike.GetBrand());
                }
                bike.DecreaseStock(item.quantity);
                inventory.UpdateBike(bike.GetId(), bike.GetPrice(), bike.GetStock(), bike.GetImageData());
            }
            dbOrders.AddOrder(order);
        }

        public void UpdateStatus(int orderid, string newstatus)
        {
            if (string.IsNullOrEmpty(newstatus))
            {
                throw new ArgumentException("Invalid new status");

            }
            if (dbOrders.GetOrder(orderid) == null)
            {
                throw new ArgumentException("The order you are trying to update does not exist");
            }
            dbOrders.UpdateStatus(orderid, newstatus);
        }

        public List<Order> GetOrdersByStatus(string status)
        {
            if (!string.IsNullOrEmpty(status))
            {
                throw new ArgumentException("Given status is invalid");
            }
            return dbOrders.GetOrdersByStatus(status);
        }

        public List<Order> GetUserOrders(int accid)
        {
            return dbOrders.GetUserOrders(accid);
        }

        
    }
}
