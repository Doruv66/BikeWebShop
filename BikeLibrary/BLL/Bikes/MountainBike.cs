
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
		public MountainBike(int _id, string _brand, double _price, int _stock, byte[] _imageData, BikeType _type, int _suspension) : base(_id, _brand,  _price, _stock, _imageData, _type)
		{
			this.suspension = _suspension;
		}

		public int GetSuspension()
		{
			return suspension;
		}
	}
}
