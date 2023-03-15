using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeClassLibrary.BLL
{
	public class ElectricBike: Bike	
	{
		private int batteryCapacity;

		public ElectricBike(string _brand, double _price, int _stock, byte[] _imageData, BikeType _type, int batteryCapacity) : base(_brand, _price, _stock, _imageData, _type)
		{
			this.batteryCapacity = batteryCapacity;
		}

		public int GetBatteryCapacity() { return batteryCapacity; }
	}
}
