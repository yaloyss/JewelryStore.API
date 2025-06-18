using JewelryStore.DAL.Pagination;
namespace JewelryStore.BLL.DTOs.Product
{
	public class ProductSearchRequest :PagedRequest
	{
        public string? SearchName { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public string? Metal { get; set; }
        public string? Stone { get; set; }
        public string? Manufacturer { get; set; }
        public string? SortBy { get; set; } = "price"; // name, price, weight
        public bool SortDescending { get; set; } = false;
    }
}

