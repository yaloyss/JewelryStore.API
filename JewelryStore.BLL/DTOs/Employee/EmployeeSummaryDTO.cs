namespace JewelryStore.BLL.DTOs.Employee
{
	public class EmployeeSummaryDTO
	{
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string Position { get; set; }
    }
}

