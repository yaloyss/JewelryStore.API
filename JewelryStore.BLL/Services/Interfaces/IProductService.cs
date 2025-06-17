using JewelryStore.BLL.DTOs.Product;

namespace JewelryStore.BLL.Services.Interfaces
{
	public interface IProductService
	{
        Task<IEnumerable<ProductListViewDTO>> GetAllProductsAsync();
        Task<ProductDetailedViewDTO?> GetProductByIdAsync(int productId);
        Task<ProductDetailedViewDTO> CreateProductAsync(ProductCreateUpdateDTO productDto);
        Task<ProductDetailedViewDTO?> UpdateProductAsync(int productId, ProductCreateUpdateDTO productDto);
        Task<bool> DeleteProductAsync(int productId);
    }
}

