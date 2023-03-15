using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeClassLibrary.BLL
{
	public interface IBike
	{
		int GetId();

		double GetPrice();

		void SetPrice(double price);

		int GetStock();

		void SetStock(int stock);
	}
}
