using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DockerSqlServer.Models
{
    public class GratuityDetailsDto
    {
        [Key]
        public int Id { get; set; }

        public String EmpCode { get; set; }
            
        public string Name { get; set; }

        public decimal ServedYears { get; set; }

        public string Type { get; set; }
 
        public bool Paid { get; set; }

        public decimal GratuityAmt { get; set; }

        public string EditBy { get; set; }

        public DateTime EditDate { get; set; }

        public string CreatBy { get; set; }

        public DateTime CreatDate { get; set; }
    }
}
