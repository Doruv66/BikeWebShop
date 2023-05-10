using BikeClassLibrary;
using BikeLibrary.DBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsBikeUniverse.MockData
{
    public class MockBikes : IBikeRepository
    {
        private List<Bike> bikes;

        public MockBikes()
        {
            bikes = new List<Bike>();
        }

        public bool AddNewBike(Bike bike)
        {
            bikes.Add(bike);
            return true;
        }

        public bool DeleteBike(int id)
        {
            bikes.Remove(GetBike(id));
            return true;
        }

        public List<Bike> GetAllBikes()
        {
            return bikes;
        }

        public Bike GetBike(int id)
        {
            return bikes.FirstOrDefault(b => b.GetId() == id);
        }

        public List<Bike> GetBikesBySearch(int[] types, string search)
        {
            return bikes.Where(b => b.GetBrand().Contains(search) || types.Contains(Convert.ToInt32(b.GetType()))).ToList();
        }

        public List<Bike> GetBikesForPage(int page)
        {
            int pageSize = 6;
            return bikes.Skip((page - 1) * pageSize)
                              .Take(pageSize)
                              .ToList();
        }

        public List<Bike> GetLastBikes()
        {
            return bikes.GetRange(-3, 3);
        }

        public bool UpdateBike(int id, double price, int stock, byte[] imgData)
        {
            Bike bike = GetBike(id);
            bike.SetPrice(price);
            bike.SetStock(stock);
            bike.SetImage(imgData);
            return true;
        }
    }
}
