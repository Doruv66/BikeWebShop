
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using BikeClassLibrary.DBL;

namespace BikeClassLibrary
{
	public class Inventory
	{
		private List<Bike> bikes;

		private DBBikes dbbikes;

		private ConStr conn;

		public Inventory() 
		{
			conn = new ConStr();
			dbbikes = new DBBikes(conn.GetConnectionString());
			bikes = dbbikes.GetAllBikes();
		}

		public void AddBike(Bike bike)
		{
			dbbikes.AddNewBike(bike);
			SetBikes();
		}

		public List<Bike> GetBikes()
		{
			return bikes;
		}

		public List<Bike> GetBikesForHome()
		{
			int count = bikes.Count;
			if (count >= 3)
			{
				return bikes.GetRange(count - 3, 3);
			}
			else
			{
				return bikes;
			}
		}


		public void RemoveBike(int id)
		{
			dbbikes.DeleteBike(id);
			SetBikes();
		}

		public Bike GetBike(int id)
		{
			foreach(Bike bike in bikes)
			{
				if(bike.GetId() == id)
				{
					return bike;
				}
			}
			throw new Exception("Not Found");
		}


		public void UpdateBike(int id, double price, int stock, byte[] image)
		{
			dbbikes.UpdateBike(id, price, stock, image);
			SetBikes();
		}
		

		public List<Bike> GetBikesForPage(int page)
		{
			int bikesPerPage = 6;
			int start = (page - 1) * bikesPerPage;
			int end = start + bikesPerPage;
			if(start >= bikes.Count || start < 0) { return null; }
			if(end > bikes.Count){end = bikes.Count;}
			return bikes.GetRange(start, end-start);
		}

		private void SetBikes()
		{
			bikes = dbbikes.GetAllBikes();
		}

        public List<Bike> GetBikesBySearch(int[] types, string search)
        {
            if (string.IsNullOrEmpty(search) && types.Count() == 0) { return bikes; }
            List<Bike> searchedBikes = new List<Bike>();
            foreach (Bike bike in bikes)
            {
                if (!string.IsNullOrEmpty(search) && !bike.GetBrand().ToLower().Contains(search.ToLower()))
                {
                    continue;
                }
                if (types.Count() > 0 && !types.Contains(Convert.ToInt32(bike.GetBikeType())))
                {
                    continue;
                }
                searchedBikes.Add(bike);
            }
            return searchedBikes;
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
