using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BikeClassLibrary;

namespace BikeWebShop.Pages
{
    public class BikePageModel : PageModel
    {
        public Inventory inventory { get; set; }

        public Bike bike { get; set; }

        public string Description { get; set; }

        public void OnGet(int id)
        {
            inventory = new Inventory();
            bike = inventory.GetBike(id);
            Description = setDescription();
        }

        public string setDescription()
        {
            string description = string.Empty;
            switch (bike)
            {
                case MountainBike mountainbike:
                    if (mountainbike.GetSuspension() == 1)
                    {
                        description = "The bike has one suspension";
                    }
                    if(mountainbike.GetSuspension() == 2)
                    {
                        description = "The bike has double suspension";
                    }
                    break;
                case CityBike cityBike:
                    if (cityBike.GetLights())
                    {
                        description = "The bike has lights";
                    }
                    else
                    {
                        description = "The bike doesn't have lights";
                    }
                    break;
                case TouringBike touringBike:
                    description = $"This touring bike has {touringBike.getNrBags()} nr of bags" ;
                    break;
                case ElectricBike electricBike:
                    description = $"This electric bike has a battery capacity of {electricBike.GetBatteryCapacity()} WH";
                    break;    
            }
            return description;
        }
    }
}
