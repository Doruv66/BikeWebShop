using BikeClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeLibrary.BLL.Interfaces
{
    public interface IInventory
    {
        void AddBike(Bike bike);
        void RemoveBike(int id);
        void UpdateBike(int id, double price, int stock, byte[] image);
        List<Bike> GetBikes();
        Bike GetBike(int id);
        List<Bike> GetBikesForHome();
        List<Bike> GetBikesForPage(int page);
        List<Bike> GetBikesBySearch(int[] types, string search);
        List<BikeType> GetBikeTypes();

    }
}
