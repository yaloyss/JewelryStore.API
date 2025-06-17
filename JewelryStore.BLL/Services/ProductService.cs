using AutoMapper;
using JewelryStore.BLL.DTOs.Product;
using JewelryStore.BLL.Services.Interfaces;
using JewelryStore.DAL.Models;
using JewelryStore.DAL.UOW;

namespace JewelryStore.BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ProductListViewDTO>> GetAllProductsAsync()
        {
            var products = await unitOfWork.Products.GetAllAsync();
            return mapper.Map<IEnumerable<ProductListViewDTO>>(products);
        }

        public async Task<ProductDetailedViewDTO?> GetProductByIdAsync(int productId)
        {
            var product = await unitOfWork.Products.GetByIdAsync(productId);
            return product == null ? null : mapper.Map<ProductDetailedViewDTO>(product);
        }

        public async Task<ProductDetailedViewDTO> CreateProductAsync(ProductCreateUpdateDTO productDto)
        {
            var product = mapper.Map<Product>(productDto);

            await unitOfWork.Products.AddAsync(product);
            await unitOfWork.SaveChangesAsync();

            return mapper.Map<ProductDetailedViewDTO>(product);
        }

        public async Task<ProductDetailedViewDTO?> UpdateProductAsync(int productId, ProductCreateUpdateDTO productDto)
        {
            var existingProduct = await unitOfWork.Products.GetByIdAsync(productId);
            if (existingProduct == null)
                return null;

            mapper.Map(productDto, existingProduct);

            unitOfWork.Products.Update(existingProduct);
            await unitOfWork.SaveChangesAsync();

            return mapper.Map<ProductDetailedViewDTO>(existingProduct);
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

