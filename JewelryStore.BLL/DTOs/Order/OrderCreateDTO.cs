using System;
using System.ComponentModel.DataAnnotations;

namespace JewelryStore.BLL.DTOs.Order
{
	public class OrderCreateDTO
	{
        [Required]
        public int ProductId { get; set; }

        [Required]
        public int ClientId { get; set; }
    }
}

