using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DockerSqlServer.Models
{
    [Table("leaveSalary", Schema = "hr")]
    public class LeaveSalary
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public String EmpCode { get; set; }

        [Required]
        [Column(TypeName = "decimal(8,2)")]
        public decimal Salary { get; set; }

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
        [StringLength(5)]
        public string Year { get; set; }

        [Required]
        public String EditBy { get; set; }

        [Required]
        public DateTime EditDate { get; set; }

        [Required]
        public String CreatBy { get; set; }

        [Required]
        public DateTime CreatDate { get; set; }
    }
}
