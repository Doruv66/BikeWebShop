using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeClassLibrary
{
	public class TouringBike : Bike
	{
		private int nrBags;

		public TouringBike(string _brand, double _price, int _stock, string _imageData, int _nrBags) : base(_brand, _price, _stock, _imageData)
		{
			this.nrBags = _nrBags;
		}
	}
}
