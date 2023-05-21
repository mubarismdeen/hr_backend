using DockerSqlServer.DTO;
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
        public DbSet<LeaveSalaryPay> leaveSalaryPay { get; set; }
        public DbSet<user> users { get; set; }
        public DbSet<DocumentDetails> DocumentDetails { get; set; }
        public DbSet<Salary> Salary { get; set; }
        public DbSet<SalaryMaster> SalaryMaster { get; set; }
        public DbSet<Attendance> Attendance { get; set; }
        public DbSet<EmpMaster> EmpMaster { get; set; }
        public DbSet<AttendanceDto> AttendanceDto { get; set; }
        public DbSet<SalaryPayable> SalaryPayable { get; set; }
        public DbSet<SalaryPaid> SalaryPaid { get; set; }
        public DbSet<SalaryPay> SalaryPay { get; set; }
        public DbSet<SalaryMasterDto> SalaryMasterDto { get; set; }
        public DbSet<DocType> DocType { get; set; }
        public DbSet<QuotationDetail> QuotationDetail { get; set; }
        public DbSet<JobDetail> jobDetail { get; set; }
        public DbSet<JobDetailDto> jobDetailDto { get; set; }
        public DbSet<QuotationDetailDto> QuotationDetailDto { get; set; }
        public DbSet<EmployeeDetailsDto> EmployeeDetailsDto { get; set; }
        public DbSet<ClientDetails> ClientDetails { get; set; }

    }

}
