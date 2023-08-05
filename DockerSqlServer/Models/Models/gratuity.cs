using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DockerSqlServer.Models
{
    [Table("gratuity", Schema = "hr")]
    public class Gratuity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public short EmpCode { get; set; }

        [Required]
        public decimal ServedYears { get; set; }

        [Required]
        public byte Type { get; set; }

        [Required]
        public bool Paid { get; set; }

        [Required]
        [Column(TypeName = "decimal(8,2)")]
        public decimal GratuityAmt { get; set; }

        [Required]
        public short EditBy { get; set; }

        [Required]
        public DateTime EditDate { get; set; }

        [Required]
        public short CreatBy { get; set; }

        [Required]
        public DateTime CreatDate { get; set; }
    }
}
