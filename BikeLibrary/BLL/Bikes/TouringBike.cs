
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

		public TouringBike(int _id, string _brand, double _price, int _stock, byte[] _imageData, BikeType _type, int _nrBags) : base(_id, _brand, _price, _stock, _imageData, _type)
		{
			this.nrBags = _nrBags;
		}

		public int getNrBags() { return nrBags; }
	}
}
