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
		public CityBike(string _brand, double _price, int _stock, string _imageData, bool _lights) : base( _brand,  _price, _stock, _imageData)
		{
			this.ligths = _lights;
		}
	}
}
