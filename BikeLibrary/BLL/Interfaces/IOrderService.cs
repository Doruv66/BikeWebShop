using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeLibrary.BLL.Interfaces
{
    public interface IOrderService
    {
        Order GetOrder(int id);

        void AddOrder(Order order);

        void UpdateStatus(Order order);

        List<Order> GetOrdersByStatus(string status);

    }
}
