using System;
namespace JewelryStore.DAL.Models
{
	public class Employee
	{
        public int EmployeeId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime? BirthDate { get; set; }

        public string? Schedule { get; set; }

        public int PositionId { get; set; }

        public Position Position { get; set; }
    }
}

