using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DockerSqlServer.Models
{
    [Table("salaryPaid", Schema = "hr")]
    public  class SalaryPaid
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public short? EmpCode { get; set; }

        [Required]
        public byte Type { get; set; }

        [Column(TypeName = "decimal(8, 2)")]
        public decimal Payable { get; set; }

        [Column(TypeName = "decimal(8, 2)")]
        public decimal Totalpaid { get; set; }

        [Column(TypeName = "decimal(8, 2)")]
        public decimal? Due { get; set; }

        [Required]
        [StringLength(7)]
        public string? Date { get; set; }

        [Required]
        public short? PaidBy { get; set; }

        [Required]
        public bool? Paid { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? PaidDt { get; set; }

        [Required]
        public short? EditBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? EditDt { get; set; }

        [Required]
        public short? CreatBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatDt { get; set; }
    }
}
