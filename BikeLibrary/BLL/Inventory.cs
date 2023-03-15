
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeClassLibrary.DBL;

namespace BikeClassLibrary
{
	public class Inventory
	{
		private List<Bike> bikes;

		private DBBikes dbbikes;

		public Inventory() 
		{
			dbbikes = new DBBikes();
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
			foreach(var bike in bikes)
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
	}

}
