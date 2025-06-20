using System;
using JewelryStore.DAL.Data.Models;

namespace JewelryStore.DAL.Models
{
	public class Order
	{
        public int OrderId { get; set; }

        public int ClientId { get; set; }

        public string? UserId { get; set; }

        public int EmployeeId { get; set; }

        public int ProductId { get; set; }

        public DateTime OrderDate { get; set; }

        public Client Client { get; set; }
        public User? User { get; set; }
        public Employee Employee { get; set; }
        public Product Product { get; set; }
    }
}

