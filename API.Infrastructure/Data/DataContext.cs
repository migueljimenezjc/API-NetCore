using API.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace API.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        const string connectionString = "Server=tcp:miserverjc.database.windows.net,1433; Initial Catalog=Receipts; Persist Security Info=False; User ID = adminJC; Password = febrero2020*; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30";
        //const string connectionString = "Data Source=DESKTOP-BCK5MF7\\ROOT; Initial Catalog=Receipts;User ID=Miguel; Password=123456; Integrated Security=SSPI;Persist Security Info=False;";

        public DataContext() : base() { }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

    }
}
