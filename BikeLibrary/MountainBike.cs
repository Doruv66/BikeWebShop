using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeClassLibrary
{
	public class MountainBike : Bike
	{
		private int suspension;
		public MountainBike(string _brand, double _price, int _stock, byte[] _imageData, int _suspension) : base(_brand,  _price, _stock, _imageData)
		{
			this.suspension = _suspension;
		}
	}
}
