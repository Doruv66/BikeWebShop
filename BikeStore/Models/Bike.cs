

using System;

namespace BikeClassLibrary
{
	public class Bike : IBike
	{
		private int id;

		private string brand;

		private double price;

		private int stock;

		private string imageData;

		private static int nextid = 1;
		public Bike(string _brand, double _price, int _stock, string _imageData)
		{
			id = nextid++;
			brand = _brand;
			price = _price;
			stock = _stock;
			imageData = _imageData;
		}

		public int GetId()
		{
			return this.id;
		}

		public double GetPrice()
		{
			return this.price;
		}

		public int GetStock()
		{
			return this.stock;
		}

		public void SetPrice(double price)
		{
			this.price = price;
		}

		public void SetStock(int stock)
		{
			this.stock=stock;
		}

		public void SetImage(string imageData)
		{
			this.imageData = imageData;
		}

		public override string ToString()
		{
			return $"Brand: {brand} price {price} stock {stock}";
		}

		public string GetImageData()
		{
			return imageData;
		}

		public string GetBrand()
		{
			return brand;
		}
 
	}
}