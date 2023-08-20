using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DockerSqlServer.Models
{
    [Table("salary", Schema = "hr")]
    public class Salary
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public short EmpCode { get; set; }

        [Required]
        [Column(TypeName = "decimal(8, 2)")]
        public decimal salary { get; set; }

        [Required]
        [MaxLength(25)]
        public string molId { get; set; }

        [Required]
        public short attendance { get; set; }

        [Required]
        public short OffDays { get; set; }

        [Required]
        public short Lop { get; set; }

        [Required]
        [MaxLength(5)]
        public string Novt { get; set; }

        [Required]
        [MaxLength(5)]
        public string Sovt { get; set; }

        [Required]
        public short Overseas { get; set; }

        [Required]
        public short Anchorage { get; set; }

        [Required]
        public String EditBy { get; set; }

        [Required]
        public DateTime EditDt { get; set; }

        [Required]
        public String CreatBy { get; set; }

        [Required]
        public DateTime CreatDt { get; set; }
    }
}
