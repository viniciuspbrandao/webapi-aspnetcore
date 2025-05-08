using Microsoft.EntityFrameworkCore;
using WebApi.Model;

namespace WebApi.Infra
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseMySQL(
                "Server=localhost;" +
                "Port=3306;" +
                "Database=exercicios_fixacao;" +
                "User=root;" +
                "Password=root;"
                );


    }
}