using System;
namespace JewelryStore.DAL.Models
{
	public class Order
	{
        public int OrderId { get; set; }

        public int ClientId { get; set; }

        public int EmployeeId { get; set; }

        public int ProductId { get; set; }

        public DateTime OrderDate { get; set; }

        public Client Client { get; set; }
        //public Employee Employee { get; set; }
        public Product Product { get; set; }
    }
}

