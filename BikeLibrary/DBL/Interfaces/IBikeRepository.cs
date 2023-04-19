using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeClassLibrary;

namespace BikeLibrary.DBL
{
    public interface IBikeRepository
    {
        List<Bike> GetAllBikes();

        bool DeleteBike(int id);

        bool UpdateBike(int id, double price, int stock, byte[] imgData);

        Bike GetBike(int id);

        bool AddNewBike(Bike bike);

        List<Bike> GetLastBikes();
    }
}
