using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeClassLibrary.BLL
{
	public class MountainBike : Bike
	{
		private int suspension;
		public MountainBike(string _brand, double _price, int _stock, byte[] _imageData, BikeType _type, int _suspension) : base(_brand, _price, _stock, _imageData, _type)
		{
			this.suspension = _suspension;
		}

		public int GetSuspension()
		{
			return suspension;
		}
	}
}
