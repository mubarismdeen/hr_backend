using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DockerSqlServer.Models
{
    public class LeaveSalaryPay
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public String EmpCode { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public decimal salary { get; set; }

        [Required]
        public decimal Attendance { get; set; }

        [Required]
        public decimal SickLeave { get; set; }

        [Required]
        public decimal PayAmt { get; set; }

        [Required]
        public decimal PaidAmt { get; set; }

        [Required]
        public decimal PendingAmt { get; set; }

        [Required]
        public string EditBy { get; set; }

        public string CreatBy { get; set; }

        [Required]
        public DateTime EditDate { get; set; }

        [Required]
        public DateTime CreatDate { get; set; }
    }
}
