using System;
namespace JewelryStore.BLL.DTOs.Order
{
	public class ClientOrderHistoryDTO
	{
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
    }
}

