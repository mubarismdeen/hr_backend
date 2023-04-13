using DockerSqlServer.Models;
//using GRN.Models;
using Microsoft.EntityFrameworkCore;

namespace DockerSqlServer
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<docScreenDetails> docScreenDetails { get; set; }
        public DbSet<LeaveSalary> LeaveSalary { get; set; }
        public DbSet<user> users { get; set; }
        public DbSet<documentDetails> documentDetails { get; set; }
        public DbSet<Salary> Salary { get; set; }
        public DbSet<SalaryMaster> SalaryMaster { get; set; }  

    }

}
