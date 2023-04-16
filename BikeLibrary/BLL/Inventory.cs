
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using BikeClassLibrary.DBL;
using BikeLibrary.BLL.Interfaces;
using BikeLibrary.DBL;

namespace BikeClassLibrary
{
	public class Inventory : IInventory
	{
		private List<Bike> bikes;

		private IBikeRepository dbbikes;

		public Inventory(IBikeRepository _dbbikes) 
		{
			dbbikes = _dbbikes;
		}

		public void AddBike(Bike bike)
		{
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
			dbbikes.DeleteBike(id);
		}

		public Bike GetBike(int id)
		{
			return dbbikes.GetBike(id);
		}


		public void UpdateBike(int id, double price, int stock, byte[] image)
		{
			dbbikes.UpdateBike(id, price, stock, image);
			SetBikes();
		}
		

		public List<Bike> GetBikesForPage(int page)
		{
			SetBikes();
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
			bikes = dbbikes.GetAllBikes();
            if (string.IsNullOrEmpty(search) && types.Count() == 0) { return bikes; }
            List<Bike> searchedBikes = new List<Bike>();
            foreach (Bike bike in dbbikes.GetAllBikes())
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
