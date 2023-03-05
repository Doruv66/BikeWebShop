using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BikeClassLibrary
{
	public class ElectricBike : Bike
	{
		private int batteryCapacity;

		public ElectricBike(string _brand, double _price, int _stock, byte[] _imageData, int batteryCapacity) : base(_brand, _price, _stock, _imageData)
		{
			this.batteryCapacity = batteryCapacity;
		}
	}
}
