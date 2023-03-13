
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BikeClassLibrary
{
	public class CityBike : Bike
	{
		private bool ligths;
		public CityBike(string _brand, double _price, int _stock, byte[] _imageData, BikeType _type, bool _lights) : base(_brand,  _price, _stock, _imageData, _type)
		{
			this.ligths = _lights;
		}

		public bool GetLights()
		{
			return this.ligths;
		}
	}
}
