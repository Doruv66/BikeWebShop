
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Text.Json.Serialization;

namespace BikeClassLibrary
{

	public class Bike 
	{
		private int id;

		private string brand;

		private double price;

		private int stock;

		private byte[] imageData;

		private BikeType type;

		public Bike(int _id, string _brand, double _price, int _stock, byte[] _imageData, BikeType _type)
		{
			id = _id;
			brand = _brand;
			price = _price;
			stock = _stock;
			imageData = _imageData;
			type = _type;
		}
		public int GetId()
		{
			return this.id;
		}

		public void SetId(int _id)
		{
			id = _id;
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

		public void SetImage(byte[] imageData)
		{
			this.imageData = imageData;
		}

		public override string ToString()
		{
			return $"Brand: {brand} price {price} stock {stock}";
		}

		public byte[] GetImageData()
		{
			return imageData;
		}

		public string GetBrand()
		{
			return brand;
		}

		public BikeType GetBikeType()
		{
			return type;
		}

		public void DecreaseStock(int quantity)
		{
			stock -= quantity;
		}
 
	}
}