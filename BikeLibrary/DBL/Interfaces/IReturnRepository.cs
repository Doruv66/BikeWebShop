using BikeLibrary.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeLibrary.DBL.Interfaces
{
    public interface IReturnRepository
    {
        List<Return> GetAllReturns();

        void AddReturn(Return Return);

        void ApproveReturn(Return Return);
    }
}
