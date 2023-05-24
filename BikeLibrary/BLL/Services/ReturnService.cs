using BikeLibrary.DBL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeLibrary.BLL
{
    public class ReturnService
    {
        private List<Return> returns;

        private IReturnRepository dbreturns;

        public ReturnService(IReturnRepository returns)
        {
            this.dbreturns = returns;
        }

        public void AddReturn(Return Return, OrderService orderService)
        {
            Order order = orderService.GetOrder(Return.GetOrderId());
            if(order.GetOrderDate().AddDays(15) > DateTime.Now)
            {
                dbreturns.AddReturn(Return);
            }
            else
            {
                throw new ArgumentException("Return not valid(15 days passed)");
            }
        }

        public List<Return> GetAllReturns()
        {
            return dbreturns.GetAllReturns();
        }

        public Return GetReturn(int returnid)
        {
            return dbreturns.GetReturn(returnid);
        }

        public void ApproveReturn(Return Return)
        {
            if(dbreturns.GetReturn(Return.GetId())!= null)
            {
                dbreturns.ApproveReturn(Return);
            }
            else
            {
                throw new ArgumentException("The return dose not exist");
            }
        }

        
    }
}
