
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using BikeClassLibrary.DBL;
using BikeLibrary.DBL;

namespace BikeClassLibrary
{
	public class Inventory
	{
		private List<Bike> bikes;

		private IBikeRepository dbbikes;

		public Inventory(IBikeRepository _dbbikes) 
		{
			dbbikes = _dbbikes;
		}

		public void AddBike(Bike bike)
		{
            if (string.IsNullOrEmpty(bike.GetBrand()) || bike.GetPrice() <= 0 || bike.GetStock() <= 0)
            {
                throw new ArgumentException("Invalid Bike Data");
            }
            dbbikes.AddNewBike(bike);
		}

		public List<Bike> GetBikes()
		{
			return dbbikes.GetAllBikes();
		}

		public List<Bike> GetBikesForHome()
		{
			return dbbikes.GetLastBikes();
		}

		public void RemoveBike(int id)
		{
			if(dbbikes.GetBike(id) != null)
			{
                dbbikes.DeleteBike(id);
            }
			else
			{
                throw new ArgumentException("The bike you are trying to delete dose not exist");
            }
		}

		public Bike GetBike(int id)
		{
			return dbbikes.GetBike(id);
		}


		public void UpdateBike(int id, double price, int stock, byte[] image)
		{
            if (price <= 0 || stock < 0)
            {
                throw new ArgumentException("Invalid Bike Data");
            }
			if(dbbikes.GetBike(id) == null)
			{
                throw new ArgumentException("The bike you try to update does not exist");
            }
            dbbikes.UpdateBike(id, price, stock, image);
		}
		

		public List<Bike> GetBikesForPage(int page)
		{
			return dbbikes.GetBikesForPage(page);
		}

        public List<Bike> GetBikesBySearch(int[] types, string search)
        {
			return dbbikes.GetBikesBySearch(types, search);
        }

        public List<BikeType> GetBikesType()
		{
			List<BikeType> bikeTypes = new List<BikeType>();
			foreach(var type in Enum.GetValues(typeof(BikeType)))
			{
				bikeTypes.Add((BikeType)type);
			}
			return bikeTypes;
		}
    }

}
