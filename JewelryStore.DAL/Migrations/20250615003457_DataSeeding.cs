using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryStore.DAL.Migrations
{
    /// <inheritdoc />
    public partial class DataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Seed Positions
            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "PositionId", "PositionName" },
                values: new object[,]
                {
                    { 1, "Shop Owner" },
                    { 2, "Administrator" },
                    { 3, "Accountant" },
                    { 4, "Security" },
                    { 5, "Consultant Manager" },
                    { 6, "Technical Staff" }
                });

            // Seed Employees
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "FirstName", "LastName", "BirthDate", "PhoneNumber", "Schedule", "PositionId" },
                values: new object[,]
                {
                    { 1, "Vyshnevska", "Iryna", new DateTime(1986, 7, 16, 0, 0, 0, 0, DateTimeKind.Utc), "0995647231", "weekdays", 1 },
                    { 2, "Levytskyi", "Andrii", new DateTime(1984, 12, 11, 0, 0, 0, 0, DateTimeKind.Utc), "0667735429", "weekdays", 2 },
                    { 3, "Gavryl", "Kai", new DateTime(1985, 8, 22, 0, 0, 0, 0, DateTimeKind.Utc), "0506723490", "weekdays", 3 },
                    { 4, "Skrypal", "Anton", new DateTime(1980, 9, 13, 0, 0, 0, 0, DateTimeKind.Utc), "0996654981", "Monday, Tuesday, Friday, Saturday", 4 },
                    { 5, "Voznyak", "Lana", new DateTime(1979, 1, 24, 0, 0, 0, 0, DateTimeKind.Utc), "0954311076", "Wednesday, Thursday, Sunday", 4 },
                    { 6, "Sklyar", "Wonbin", new DateTime(1991, 2, 26, 0, 0, 0, 0, DateTimeKind.Utc), "0669014463", "Monday, Wednesday, Thursday, Saturday", 5 },
                    { 7, "Tkach", "Omar", new DateTime(1992, 7, 12, 0, 0, 0, 0, DateTimeKind.Utc), "0952216598", "Monday, Tuesday, Thursday, Sunday", 5 },
                    { 8, "Andruhovych", "Elina", new DateTime(1996, 5, 11, 0, 0, 0, 0, DateTimeKind.Utc), "0508914269", "Tuesday, Wednesday, Friday", 5 },
                    { 9, "Soya", "Yan", new DateTime(2000, 2, 18, 0, 0, 0, 0, DateTimeKind.Utc), "0504012380", "Friday, Saturday, Sunday", 5 },
                    { 10, "Yalivec", "Serhii", new DateTime(1990, 3, 10, 0, 0, 0, 0, DateTimeKind.Utc), "0956439071", "Monday, Wednesday, Friday", 6 },
                    { 11, "Komariv", "Dmytro", new DateTime(1993, 9, 23, 0, 0, 0, 0, DateTimeKind.Utc), "0668789190", "Tuesday, Thursday, Saturday, Sunday", 6 }
                });

            // Seed Clients
            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ClientId", "FirstName", "LastName", "BirthDate", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Hoya", "Kaia", new DateTime(2001, 2, 21, 0, 0, 0, 0, DateTimeKind.Utc), "0991125869" },
                    { 2, "Kavun", "Sydor", new DateTime(1974, 6, 12, 0, 0, 0, 0, DateTimeKind.Utc), "0665923301" },
                    { 3, "Slyvka", "Yulia", new DateTime(1990, 9, 17, 0, 0, 0, 0, DateTimeKind.Utc), "0997735412" },
                    { 4, "Gojo", "Satoru", new DateTime(1989, 12, 7, 0, 0, 0, 0, DateTimeKind.Utc), "0663078021" },
                    { 5, "Burya", "Kyryl", new DateTime(2001, 12, 14, 0, 0, 0, 0, DateTimeKind.Utc), "0508830294" },
                    { 6, "Kaidash", "Volodymyr", new DateTime(1985, 11, 10, 0, 0, 0, 0, DateTimeKind.Utc), "0997761290" },
                    { 7, "Levytskii", "Vladyslav", new DateTime(1991, 4, 2, 0, 0, 0, 0, DateTimeKind.Utc), "0995370162" }
                });

            // Seed Products
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Name", "Weight", "Metal", "Stone", "Price", "Manufacturer", "Size" },
                values: new object[,]
                {
                    { 1, "Silver stud earrings with pink cubic zirconium", 3, "Silver", "Pink cub. zirconium", 2146m, "Ukraine", null },
                    { 2, "Silver necklace with cubic zirconia", 6, "Silver", "Cub. zirconium", 8038m, "Ukraine", 47 },
                    { 3, "White gold necklace with cubic zirconia", 4, "Gold", "Pink and white cub. zirconium", 12020m, "Ukraine", 47 },
                    { 4, "Silver pendant with pink and white cubic zirconium", 1, "Silver", "Pink and white cub. zirconium", 16676m, "Ukraine", null },
                    { 5, "Silver stud earrings with cubic zirconium", 2, "Silver", "Cub. zirconium", 3461m, "Ukraine", null },
                    { 6, "Silver ring with cubic zirconia", 5, "Silver", "Cub. zirconium", 8395m, "Ukraine", 16 },
                    { 7, "Silver pendant with cubic zirconium", 1, "Silver", "Cub. zirconium", 4072m, "Ukraine", null },
                    { 8, "White gold bracelet with cubic zirconia", 4, "Gold", "Cub. zirconium", 28000m, "Ukraine", 170 },
                    { 9, "Silver ring", 2, "Silver", "None", 4303m, "Ukraine", 16 },
                    { 10, "White gold ring with sapphire and diamonds", 2, "Gold", "Diamond, sapphire", 58570m, "Ukraine", 17 }
                });

            // Seed Orders
            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "OrderDate", "ProductId", "EmployeeId", "ClientId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 25, 0, 0, 0, 0, DateTimeKind.Utc), 5, 3, 1 },
                    { 2, new DateTime(2024, 3, 29, 0, 0, 0, 0, DateTimeKind.Utc), 8, 7, 2 },
                    { 3, new DateTime(2024, 4, 4, 0, 0, 0, 0, DateTimeKind.Utc), 2, 1, 3 },
                    { 4, new DateTime(2024, 4, 10, 0, 0, 0, 0, DateTimeKind.Utc), 9, 10, 4 },
                    { 5, new DateTime(2024, 4, 18, 0, 0, 0, 0, DateTimeKind.Utc), 4, 6, 5 },
                    { 6, new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Utc), 7, 2, 6 },
                    { 7, new DateTime(2024, 5, 9, 0, 0, 0, 0, DateTimeKind.Utc), 1, 11, 7 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remove seed data in reverse order (due to foreign key constraints)
            migrationBuilder.DeleteData(table: "Orders", keyColumn: "OrderId", keyValues: new object[] { 1, 2, 3, 4, 5, 6, 7 });
            migrationBuilder.DeleteData(table: "Products", keyColumn: "ProductId", keyValues: new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
            migrationBuilder.DeleteData(table: "Employees", keyColumn: "EmployeeId", keyValues: new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 });
            migrationBuilder.DeleteData(table: "Clients", keyColumn: "ClientId", keyValues: new object[] { 1, 2, 3, 4, 5, 6, 7 });
            migrationBuilder.DeleteData(table: "Positions", keyColumn: "PositionId", keyValues: new object[] { 1, 2, 3, 4, 5, 6 });
        }
    }
}