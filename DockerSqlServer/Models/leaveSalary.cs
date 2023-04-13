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
        public short EmpCode { get; set; }

        [Required]
        [Column(TypeName = "decimal(8,2)")]
        public decimal Salary { get; set; }

        [Required]
        public short Attendance { get; set; }

        [Required]
        public short OffDays { get; set; }

        [Required]
        public short SickLeave { get; set; }

        [Required]
        public short PayAmt { get; set; }

        [Required]
        public short LsDays { get; set; }

        [Required]
        public short PaidAmt { get; set; }

        [Required]
        [StringLength(5)]
        public string Year { get; set; }

        [Required]
        public short EditBy { get; set; }

        [Required]
        public DateTime EditDt { get; set; }

        [Required]
        public short CreatBy { get; set; }

        [Required]
        public DateTime CreatDt { get; set; }
    }
}
