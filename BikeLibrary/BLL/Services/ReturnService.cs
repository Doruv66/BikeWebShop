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

        public void AddReturn(Return Return)
        {
            dbreturns.AddReturn(Return);
        }

        public List<Return> GetAllReturns()
        {
            return dbreturns.GetAllReturns();
        }

        public void ApproveReturn(Return Return)
        {
            dbreturns.ApproveReturn(Return);
        }

        
    }
}
