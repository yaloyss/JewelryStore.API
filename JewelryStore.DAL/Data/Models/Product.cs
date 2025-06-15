using System;
namespace JewelryStore.DAL.Models
{
	public class Product
	{
		public int ProductId { get; set; }

		public string Name { get; set; }

		public decimal Weight { get; set; }

		public string? Metal { get; set; }

		public string? Stone { get; set; }
		
		public decimal? Size { get; set; }

		public decimal Price { get; set; }

		public string Manufacturer { get; set; }
	}
}

