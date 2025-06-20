namespace JewelryStore.BLL.DTOs.Authentication
{
	public class UserInfoDTO
	{
        public string Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IList<string> Roles { get; set; } = new List<string>();
    }
}

