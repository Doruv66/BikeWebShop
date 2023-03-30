using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeClassLibrary
{
	public enum BikeType
	{
		[Description("Mountain Bikes")]
		MountainBike,
        [Description("Electric Bikes")]
        ElectricBike,
        [Description("City Bikes")]
        CityBike,
        [Description("Touring Bikes")]
        TouringBike
	}
}
