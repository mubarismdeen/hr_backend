using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DockerSqlServer.Models
{
    //[Table("salaryMaster", Schema = "hr")]
    //public class SalaryMaster
    //{
    //    [Key]
    //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //    [Column("id")]
    //    public int Id { get; set; }

    //    [Column("empCode")]
    //    public short EmpCode { get; set; }

    //    [Column("salary")]
    //    public decimal Salary { get; set; }

    //    [Column("attendance")]
    //    public short Attendance { get; set; }

    //    [Column("offdays")]
    //    public short OffDays { get; set; }

    //    [Column("lop")]
    //    public short Lop { get; set; }

    //    [Column("novt")]
    //    public string Novt { get; set; }

    //    [Column("sovt")]
    //    public string Sovt { get; set; }

    //    [Column("overseas")]
    //    public short Overseas { get; set; }

    //    [Column("anchorage")]
    //    public short Anchorage { get; set; }

    //    [Column("editBy")]
    //    public short EditBy { get; set; }

    //    [Column("editDt")]
    //    public DateTime EditDt { get; set; }

    //    [Column("creatBy")]
    //    public short CreatBy { get; set; }

    //    [Column("creatDt")]
    //    public DateTime CreatDt { get; set; }
    //}

    [Table("SalaryMaster", Schema = "hr")]
    public class SalaryMaster
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
        public byte Status { get; set; }

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
