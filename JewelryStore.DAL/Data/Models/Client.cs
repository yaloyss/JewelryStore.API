using System;
namespace JewelryStore.DAL.Models
{
	public class Client
	{
        public int ClientId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime? BirthDate { get; set; }

    }
}

