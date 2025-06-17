namespace JewelryStore.BLL.DTOs.Client
{
	public class ClientSummaryDTO
	{
        public int ClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string PhoneNumber { get; set; }
    }
}

