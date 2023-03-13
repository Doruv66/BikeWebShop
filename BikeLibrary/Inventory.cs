
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeClassLibrary
{
	public class Inventory
	{
		private List<Bike> bikes;

		public Inventory() 
		{
			bikes = new List<Bike>();
		}

		public void SetBikes(List<Bike> _bikes)
		{
			bikes = _bikes;
		}

		public void AddBike(Bike bike)
		{
			bikes.Add(bike);
		}

		public void RemoveBike(int id)
		{
			foreach(var bike in bikes)
			{
				if(bike.GetId() == id)
				{
					bikes.Remove(bike);
					return;
				}
			}
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
			foreach(var bike in bikes)
			{
				if(bike.GetId() == id)
				{
					bike.SetPrice(price);
					bike.SetStock(stock);
					bike.SetImage(image);
				}
			}
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
	}

}
