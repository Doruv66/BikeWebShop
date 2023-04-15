using BikeLibrary.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeLibrary.DBL
{
    public interface IOrderRepository
    {
        List<Order> GetAll();

        Order GetOrder(int id);

        bool AddOrder(Order order);
    }
}
