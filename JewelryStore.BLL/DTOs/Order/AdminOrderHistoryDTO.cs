using JewelryStore.BLL.DTOs.Client;

namespace JewelryStore.BLL.DTOs.Order
{
	public class AdminOrderHistoryDTO
	{
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public ClientSummaryDTO Client { get; set; }
    }
}

