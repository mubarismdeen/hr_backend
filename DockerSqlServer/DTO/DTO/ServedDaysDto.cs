using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DockerSqlServer.Models
{

    public class ServedDaysDto
    {
        [Key]
        [Column("ServedDays")]
        public decimal ServedDays { get; set; }
    }
}


