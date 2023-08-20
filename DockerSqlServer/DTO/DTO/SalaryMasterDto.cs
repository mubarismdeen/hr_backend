using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DockerSqlServer.Models
{
   
    public class SalaryMasterDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public String EmpCode { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        [Column(TypeName = "decimal(8,2)")]
        public decimal Salary { get; set; }

        [Required]
        [Column(TypeName = "decimal(8,2)")]
        public decimal NOtr { get; set; }

        [Required]
        [Column(TypeName = "decimal(8,2)")]
        public decimal SOtr { get; set; }

        [Required]
        [Column(TypeName = "decimal(8,2)")]
        public decimal Overseas { get; set; }

        [Required]
        [Column(TypeName = "decimal(8,2)")]
        public decimal Anchorage { get; set; }

        [Required]
        public string EditBy { get; set; }

        [Required]
        public DateTime EditDt { get; set; }

        [Required]
        public string CreatBy { get; set; }

        [Required]
        public DateTime CreatDt { get; set; }
    }
}
