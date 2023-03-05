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

		public List<Bike> GetBikes()
		{
			return bikes;
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
		

		public List<Bike> GetBikesForPage(int page)
		{
			int bikesPerPage = 6;
			int start = (page - 1) * bikesPerPage;
			int end = start + bikesPerPage;
			if(start >= bikes.Count || start < 0) {return new List<Bike>();}
			if(end > bikes.Count){end = bikes.Count;}
			return bikes.GetRange(start, end-start);
		}

		public List<Bike> GetBikesForHome()
		{
			int count = bikes.Count;
			if(count >= 3)
			{
				return bikes.GetRange(count-3, 3);
			}
			else
			{
				return bikes;
			}
		}

		public void MockBikes()
		{
			AddBike(new MountainBike("Giant", 550.00, 10, "giant.png", 1));
            AddBike(new CityBike("Caféchaser", 399.99, 13, "CityBike.png", true));
            AddBike(new MountainBike("Giant", 550.00, 10, "giant.png", 1));
            AddBike(new CityBike("Caféchaser", 399.99, 13, "CityBike.png", true));
            AddBike(new MountainBike("Giant", 550.00, 10, "giant.png", 1));
            AddBike(new CityBike("Caféchaser", 399.99, 13, "CityBike.png", true));
            AddBike(new MountainBike("Giant", 550.00, 10, "giant.png", 1));;
        }
	}

}
