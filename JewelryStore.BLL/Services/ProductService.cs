using JewelryStore.BLL.DTOs.Product;
using JewelryStore.BLL.Services.Interfaces;
using JewelryStore.DAL.Models;
using JewelryStore.DAL.UOW;

namespace JewelryStore.BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ProductListViewDTO>> GetAllProductsAsync()
        {
            var products = await unitOfWork.Products.GetAllAsync();

            return products.Select(p => new ProductListViewDTO
            {
                ProductId = p.ProductId,
                Name = p.Name,
                Price = p.Price
            });
        }

        public async Task<ProductDetailedViewDTO?> GetProductByIdAsync(int productId)
        {
            var product = await unitOfWork.Products.GetByIdAsync(productId);

            if (product == null)
                return null;

            return new ProductDetailedViewDTO
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Price = product.Price,
                Weight = product.Weight,
                Metal = product.Metal,
                Stone = product.Stone,
                Size = product.Size,
                Manufacturer = product.Manufacturer
            };
        }

        public async Task<ProductDetailedViewDTO> CreateProductAsync(ProductCreateUpdateDTO productDto)
        {
            var product = new Product
            {
                Name = productDto.Name,
                Weight = productDto.Weight,
                Metal = productDto.Metal,
                Stone = productDto.Stone,
                Size = productDto.Size,
                Price = productDto.Price,
                Manufacturer = productDto.Manufacturer
            };

            await unitOfWork.Products.AddAsync(product);
            await unitOfWork.SaveChangesAsync();

            return new ProductDetailedViewDTO
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Price = product.Price,
                Weight = product.Weight,
                Metal = product.Metal,
                Stone = product.Stone,
                Size = product.Size,
                Manufacturer = product.Manufacturer
            };
        }

        public async Task<ProductDetailedViewDTO?> UpdateProductAsync(int productId, ProductCreateUpdateDTO productDto)
        {
            var existingProduct = await unitOfWork.Products.GetByIdAsync(productId);
            if (existingProduct == null)
                return null;

            existingProduct.Name = productDto.Name;
            existingProduct.Weight = productDto.Weight;
            existingProduct.Metal = productDto.Metal;
            existingProduct.Stone = productDto.Stone;
            existingProduct.Size = productDto.Size;
            existingProduct.Price = productDto.Price;
            existingProduct.Manufacturer = productDto.Manufacturer;

            unitOfWork.Products.Update(existingProduct);
            await unitOfWork.SaveChangesAsync();

            return new ProductDetailedViewDTO
            {
                ProductId = existingProduct.ProductId,
                Name = existingProduct.Name,
                Price = existingProduct.Price,
                Weight = existingProduct.Weight,
                Metal = existingProduct.Metal,
                Stone = existingProduct.Stone,
                Size = existingProduct.Size,
                Manufacturer = existingProduct.Manufacturer
            };
        }

        public async Task<bool> DeleteProductAsync(int productId)
        {
            var product = await unitOfWork.Products.GetByIdAsync(productId);
            if (product == null)
                return false;

            unitOfWork.Products.Delete(product);
            await unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}

