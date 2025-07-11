﻿using JewelryStore.BLL.DTOs.Product;
using JewelryStore.BLL.Services.Interfaces;
using JewelryStore.DAL.Pagination;
using Microsoft.AspNetCore.Mvc;

namespace JewelryStore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet("shortened details view")]
        public async Task<ActionResult<PagedResult<ProductListViewDTO>>> GetAllProducts([FromQuery] PagedRequest request)
        {
            try
            {
                var products = await productService.GetAllProductsAsync(request);
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error while getting products list: {ex.Message}");
            }
        }

        [HttpGet("filtering and sorting")]
        public async Task<ActionResult<PagedResult<ProductDetailedViewDTO>>> SearchProducts([FromQuery] ProductSearchRequest request)
        {
            try
            {
                var products = await productService.FilterProductsAsync(request);
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error while searching products: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDetailedViewDTO>> GetProductById(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Product ID must be greater than zero.");
                }

                var product = await productService.GetProductByIdAsync(id);

                if (product == null)
                {
                    return NotFound($"Product with ID {id} is not found.");
                }

                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error while getting product: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<ProductDetailedViewDTO>> CreateProduct([FromBody] ProductCreateUpdateDTO productDto)
        {
            try
            {
                var createdProduct = await productService.CreateProductAsync(productDto);
                return CreatedAtAction(nameof(GetProductById), new { id = createdProduct.ProductId }, createdProduct);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error while getting product: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDetailedViewDTO>> UpdateProduct(int id, [FromBody] ProductCreateUpdateDTO productDto)
        {
            try
            {
                var updatedProduct = await productService.UpdateProductAsync(id, productDto);

                if (updatedProduct == null)
                {
                    return NotFound($"Product with ID {id} is not found.");
                }

                return Ok(updatedProduct);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error while updating product: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Product ID must be greater than zero.");
                }

                var result = await productService.DeleteProductAsync(id);

                if (!result)
                {
                    return NotFound($"Product with ID {id} is not found.");
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error while deleting product: {ex.Message}");
            }
        }
    }
}

