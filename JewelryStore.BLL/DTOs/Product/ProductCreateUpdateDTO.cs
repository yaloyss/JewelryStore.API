using System.ComponentModel.DataAnnotations;

namespace JewelryStore.BLL.DTOs.Product
{
	public class ProductCreateUpdateDTO
	{
        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Weight { get; set; }

        [StringLength(50)]
        public string? Metal { get; set; }

        [StringLength(100)]
        public string? Stone { get; set; }

        [Range(0, double.MaxValue)]
        public decimal? Size { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [StringLength(100)]
        public string Manufacturer { get; set; }
    }
}

