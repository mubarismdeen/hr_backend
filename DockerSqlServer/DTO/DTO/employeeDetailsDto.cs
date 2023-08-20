using System;
using System.ComponentModel.DataAnnotations;

namespace DockerSqlServer.DTO
{
    public class EmployeeDetailsDto
    {
        [Key]
        public int Id { get; set; }
        public string EmpCode { get; set; }
        public string Name { get; set; }
        public string Mobile1 { get; set; }
        public string Mobile2 { get; set; }
        public string Department { get; set; }
        public string Status { get; set; }
        public string Nationality { get; set; }
        public DateTime BirthDt { get; set; }
        public DateTime JoinDt { get; set; }
        public string EditBy { get; set; }
        public DateTime EditDt { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDt { get; set; }
    }
}
