using BikeClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeLibrary.BLL
{
    public class Cart
    {
        public List<Item> items { get; set; }

        public List<ICupon> cupons { get; set; }

        public Cart()
        {
            items = new List<Item>();
            cupons = new List<ICupon>();
        }

        public List<Item> Getitems()
        {
            return items;
        }

        public void AddCupon(ICupon cupon)
        {
            cupons.Add(cupon);
        }

        public void Add(int bikeid)
        {
            int index = Exists(bikeid);
            if (index == -1)
            {
                items.Add(new Item(bikeid, 1, "wished"));
            }
            else
            {
                items[index].quantity++;
            }
        }

        public bool HasCupon(ICupon cupon)
        {
            foreach(var cup in cupons)
            {
                if(cup.GetCuponType() == cupon.GetCuponType())
                {
                    return false;
                }
            }
            return true;
        }

        public void Remove(int bikeid)
        {
            int index = Exists(bikeid);
            items.RemoveAt(index);
        }

        public double GetTotalPrice(Inventory inventory)
        {
            double totalPrice = Convert.ToDouble(items.Sum(i => inventory.GetBike(i.bikeid).GetPrice() * i.quantity));
            foreach(var cupon in cupons)
            {
                totalPrice = cupon.applyCupon(totalPrice);
            }
            return totalPrice;
        }

        public void Clear()
        {
            items.Clear();
        }

        public int Exists(int bikeid)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].bikeid == bikeid)
                {
                    return i;
                }
            }
            return -1;
        }
    }

}
