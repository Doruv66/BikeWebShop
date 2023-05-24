using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeLibrary.BLL
{
    public interface ICupon
    {
        double applyCupon(double totalPrice);

        string GetCuponType();
    }
}
