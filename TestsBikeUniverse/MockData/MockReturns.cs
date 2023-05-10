using BikeLibrary.BLL;
using BikeLibrary.DBL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsBikeUniverse.MockData
{
    public class MockReturns : IReturnRepository
    {
        private List<Return> returns;

        public MockReturns()
        {
            returns = new List<Return>();
        }

        public void AddReturn(Return Return)
        {
            returns.Add(Return);
        }

        public void ApproveReturn(Return Return)
        {
            throw new NotImplementedException();
        }

        public List<Return> GetAllReturns()
        {
            return returns;
        }
    }
}
