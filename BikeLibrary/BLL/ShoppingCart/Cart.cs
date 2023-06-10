﻿using BikeClassLibrary;
using BikeLibrary.BLL.Cupons;
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

        public Coupon coupon { get; set; }

        public Cart()
        {
            items = new List<Item>();
            coupon = null;
        }

        public List<Item> Getitems()
        {
            return items;
        }

        public void SetCoupon(Coupon _coupon)
        {
            coupon = _coupon;
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

        public void Remove(int bikeid)
        {
            int index = Exists(bikeid);
            items.RemoveAt(index);
        }

        public double GetTotalPrice(Inventory inventory)
        {
            double totalPrice = Convert.ToDouble(items.Sum(i => inventory.GetBike(i.bikeid).GetPrice() * i.quantity));
            if(coupon != null)
            {
                totalPrice = coupon.Apply(totalPrice);
            }
            return totalPrice;
        }

        public void Clear()
        {
            items.Clear();
            coupon = null;
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
