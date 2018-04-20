using Microsoft.EntityFrameworkCore;
using System;
using NGB.Domain;

namespace NGB.Data
{
    public class BeanContext : DbContext
    {
        public DbSet<Bean> Beans { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=tcp:sql-academykaffelab-dev.database.windows.net,1433;Initial Catalog=db-bonan;Persist Security Info=False;User ID={your_username};Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Authentication=\"Active Directory Password\";");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
