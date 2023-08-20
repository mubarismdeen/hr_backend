using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DockerSqlServer.Models
{
    public class SalaryPay
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public String EmpCode { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public decimal Basic { get; set; }

        [Required]
        public decimal Attendance { get; set; }

        [Required]
        public decimal Novt { get; set; }

        [Required]
        public decimal Sovt { get; set; }

        [Required]
        public decimal Overseas { get; set; }

        [Required]
        public decimal Anchorage { get; set; }

        [Required]
        public decimal due { get; set; }

        [Required]
        public decimal Total { get; set; }

        [Required]
        [MaxLength(7)]
        public string Date { get; set; }

        [Required]
        public DateTime EditDt { get; set; }

        [Required]
        public DateTime CreatDt { get; set; }
    }
}
