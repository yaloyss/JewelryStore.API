using System;
namespace JewelryStore.BLL.DTOs.Order
{
	public class OrderCreatedResponseDTO
	{
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ClientName { get; set; } 
        public DateTime OrderDate { get; set; }
    }
}

