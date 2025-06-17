namespace JewelryStore.BLL.DTOs.Product
{
	public class ProductDetailedViewDTO
	{
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Weight { get; set; }
        public string? Metal { get; set; }
        public string? Stone { get; set; }
        public decimal? Size { get; set; }
        public string Manufacturer { get; set; }
    }
}

