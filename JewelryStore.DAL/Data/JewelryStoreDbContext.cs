using Microsoft.EntityFrameworkCore;
using JewelryStore.DAL.Models;
using JewelryStore.DAL.Models.Configuration;
using JewelryStore.DAL.Data.Models;
using JewelryStore.DAL.Data.Models.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

public class JewelryStoreDbContext : IdentityDbContext<User>
{
    public JewelryStoreDbContext(DbContextOptions<JewelryStoreDbContext> options)
        : base(options) { }

    public DbSet<Position> Positions { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new PositionConfiguration());
        modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        modelBuilder.ApplyConfiguration(new ClientConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new RefreshTokenConfiguration());

        modelBuilder.Entity<Product>().HasData(
            new Product { ProductId = 1, Name = "Silver stud earrings with pink cubic zirconium", Weight = 3, Metal = "Silver", Stone = "Pink cub. zirconium", Price = 2146, Manufacturer = "Ukraine" },
            new Product { ProductId = 2, Name = "Silver necklace with cubic zirconia", Weight = 6, Metal = "Silver", Stone = "Cub. zirconium", Price = 8038, Manufacturer = "Ukraine", Size = 47 },
            new Product { ProductId = 3, Name = "White gold necklace with cubic zirconia", Weight = 4, Metal = "Gold", Stone = "Pink and white cub. zirconium", Price = 12020, Manufacturer = "Ukraine", Size = 47 },
            new Product { ProductId = 4, Name = "Silver pendant with pink and white cubic zirconium", Weight = 1, Metal = "Silver", Stone = "Pink and white cub. zirconium", Price = 16676, Manufacturer = "Ukraine" },
            new Product { ProductId = 5, Name = "Silver stud earrings with cubic zirconium", Weight = 2, Metal = "Silver", Stone = "Cub. zirconium", Price = 3461, Manufacturer = "Ukraine" },
            new Product { ProductId = 6, Name = "Silver ring with cubic zirconia", Weight = 5, Metal = "Silver", Stone = "Cub. zirconium", Price = 8395, Manufacturer = "Ukraine", Size = 16 },
            new Product { ProductId = 7, Name = "Silver pendant with cubic zirconium", Weight = 1, Metal = "Silver", Stone = "Cub. zirconium", Price = 4072, Manufacturer = "Ukraine" },
            new Product { ProductId = 8, Name = "White gold bracelet with cubic zirconia", Weight = 4, Metal = "Gold", Stone = "Cub. zirconium", Price = 28000, Manufacturer = "Ukraine", Size = 170 },
            new Product { ProductId = 9, Name = "Silver ring", Weight = 2, Metal = "Silver", Stone = "None", Price = 4303, Manufacturer = "Ukraine", Size = 16 },
            new Product { ProductId = 10, Name = "White gold ring with sapphire and diamonds", Weight = 2, Metal = "Gold", Stone = "Diamond, sapphire", Price = 58570, Manufacturer = "Ukraine", Size = 17 }
);

        modelBuilder.Entity<Client>().HasData(
            new Client { ClientId = 1, FirstName = "Hoya", LastName = "Kaia", BirthDate = DateTime.SpecifyKind(DateTime.Parse("2001-02-21"), DateTimeKind.Utc), PhoneNumber = "0991125869" },
            new Client { ClientId = 2, FirstName = "Kavun", LastName = "Sydor", BirthDate = DateTime.SpecifyKind(DateTime.Parse("1974-06-12"), DateTimeKind.Utc), PhoneNumber = "0665923301" },
            new Client { ClientId = 3, FirstName = "Slyvka", LastName = "Yulia", BirthDate = DateTime.SpecifyKind(DateTime.Parse("1990-09-17"), DateTimeKind.Utc), PhoneNumber = "0997735412" },
            new Client { ClientId = 4, FirstName = "Gojo", LastName = "Satoru", BirthDate = DateTime.SpecifyKind(DateTime.Parse("1989-12-07"), DateTimeKind.Utc), PhoneNumber = "0663078021" },
            new Client { ClientId = 5, FirstName = "Burya", LastName = "Kyryl", BirthDate = DateTime.SpecifyKind(DateTime.Parse("2001-12-14"), DateTimeKind.Utc), PhoneNumber = "0508830294" },
            new Client { ClientId = 6, FirstName = "Kaidash", LastName = "Volodymyr", BirthDate = DateTime.SpecifyKind(DateTime.Parse("1985-11-10"), DateTimeKind.Utc), PhoneNumber = "0997761290" },
            new Client { ClientId = 7, FirstName = "Levytskii", LastName = "Vladyslav", BirthDate = DateTime.SpecifyKind(DateTime.Parse("1991-04-02"), DateTimeKind.Utc), PhoneNumber = "0995370162" }
        );

        modelBuilder.Entity<Position>().HasData(
            new Position { PositionId = 1, PositionName = "Shop Owner" },
            new Position { PositionId = 2, PositionName = "Administrator" },
            new Position { PositionId = 3, PositionName = "Accountant" },
            new Position { PositionId = 4, PositionName = "Security" },
            new Position { PositionId = 5, PositionName = "Consultant Manager" },
            new Position { PositionId = 6, PositionName = "Technical Staff" }
        );

        modelBuilder.Entity<Employee>().HasData(
            new Employee { EmployeeId = 1, FirstName = "Vyshnevska", LastName = "Iryna", BirthDate = DateTime.SpecifyKind(DateTime.Parse("1986-07-16"), DateTimeKind.Utc), PhoneNumber = "0995647231", Schedule = "weekdays", PositionId = 1 },
            new Employee { EmployeeId = 2, FirstName = "Levytskyi", LastName = "Andrii", BirthDate = DateTime.SpecifyKind(DateTime.Parse("1984-12-11"), DateTimeKind.Utc), PhoneNumber = "0667735429", Schedule = "weekdays", PositionId = 2 },
            new Employee { EmployeeId = 3, FirstName = "Gavryl", LastName = "Kai", BirthDate = DateTime.SpecifyKind(DateTime.Parse("1985-08-22"), DateTimeKind.Utc), PhoneNumber = "0506723490", Schedule = "weekdays", PositionId = 3 },
            new Employee { EmployeeId = 4, FirstName = "Skrypal", LastName = "Anton", BirthDate = DateTime.SpecifyKind(DateTime.Parse("1980-09-13"), DateTimeKind.Utc), PhoneNumber = "0996654981", Schedule = "Monday, Tuesday, Friday, Saturday", PositionId = 4 },
            new Employee { EmployeeId = 5, FirstName = "Voznyak", LastName = "Lana", BirthDate = DateTime.SpecifyKind(DateTime.Parse("1979-01-24"), DateTimeKind.Utc), PhoneNumber = "0954311076", Schedule = "Wednesday, Thursday, Sunday", PositionId = 4 },
            new Employee { EmployeeId = 6, FirstName = "Sklyar", LastName = "Wonbin", BirthDate = DateTime.SpecifyKind(DateTime.Parse("1991-02-26"), DateTimeKind.Utc), PhoneNumber = "0669014463", Schedule = "Monday, Wednesday, Thursday, Saturday", PositionId = 5 },
            new Employee { EmployeeId = 7, FirstName = "Tkach", LastName = "Omar", BirthDate = DateTime.SpecifyKind(DateTime.Parse("1992-07-12"), DateTimeKind.Utc), PhoneNumber = "0952216598", Schedule = "Monday, Tuesday, Thursday, Sunday", PositionId = 5 },
            new Employee { EmployeeId = 8, FirstName = "Andruhovych", LastName = "Elina", BirthDate = DateTime.SpecifyKind(DateTime.Parse("1996-05-11"), DateTimeKind.Utc), PhoneNumber = "0508914269", Schedule = "Tuesday, Wednesday, Friday", PositionId = 5 },
            new Employee { EmployeeId = 9, FirstName = "Soya", LastName = "Yan", BirthDate = DateTime.SpecifyKind(DateTime.Parse("2000-02-18"), DateTimeKind.Utc), PhoneNumber = "0504012380", Schedule = "Friday, Saturday, Sunday", PositionId = 5 },
            new Employee { EmployeeId = 10, FirstName = "Yalivec", LastName = "Serhii", BirthDate = DateTime.SpecifyKind(DateTime.Parse("1990-03-10"), DateTimeKind.Utc), PhoneNumber = "0956439071", Schedule = "Monday, Wednesday, Friday", PositionId = 6 },
            new Employee { EmployeeId = 11, FirstName = "Komariv", LastName = "Dmytro", BirthDate = DateTime.SpecifyKind(DateTime.Parse("1993-09-23"), DateTimeKind.Utc), PhoneNumber = "0668789190", Schedule = "Tuesday, Thursday, Saturday, Sunday", PositionId = 6 }
        );

        modelBuilder.Entity<Order>().HasData(
            new Order { OrderId = 1, OrderDate = DateTime.SpecifyKind(DateTime.Parse("2024-03-25"), DateTimeKind.Utc), ProductId = 5, EmployeeId = 3, ClientId = 1 },
            new Order { OrderId = 2, OrderDate = DateTime.SpecifyKind(DateTime.Parse("2024-03-29"), DateTimeKind.Utc), ProductId = 8, EmployeeId = 7, ClientId = 2 },
            new Order { OrderId = 3, OrderDate = DateTime.SpecifyKind(DateTime.Parse("2024-04-04"), DateTimeKind.Utc), ProductId = 2, EmployeeId = 1, ClientId = 3 },
            new Order { OrderId = 4, OrderDate = DateTime.SpecifyKind(DateTime.Parse("2024-04-10"), DateTimeKind.Utc), ProductId = 9, EmployeeId = 10, ClientId = 4 },
            new Order { OrderId = 5, OrderDate = DateTime.SpecifyKind(DateTime.Parse("2024-04-18"), DateTimeKind.Utc), ProductId = 4, EmployeeId = 6, ClientId = 5 },
            new Order { OrderId = 6, OrderDate = DateTime.SpecifyKind(DateTime.Parse("2024-05-02"), DateTimeKind.Utc), ProductId = 7, EmployeeId = 2, ClientId = 6 },
            new Order { OrderId = 7, OrderDate = DateTime.SpecifyKind(DateTime.Parse("2024-05-09"), DateTimeKind.Utc), ProductId = 1, EmployeeId = 11, ClientId = 7 }
        );



    }
}
