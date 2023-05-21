using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DockerSqlServer.Models
{

        public class AttendanceDto
        {
            [Key]
            [Column("id")]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }

            [Column("empCode")]
            public Int16 empCode { get; set; }

            [Column("name")]
            public String name { get; set; }

            [Column("attendance")]
            public decimal attendance { get; set; }

            [Column("offdays")]
            public decimal OffDays { get; set; }

            [Column("lop")]
            public decimal Lop { get; set; }

            [Column("novt")]
            public decimal Novt { get; set; }

            [Column("sovt")]
            public decimal Sovt { get; set; }

            [Column("overseas")]
            public decimal Overseas { get; set; }

            [Column("anchorage")]
            public decimal Anchorage { get; set; }

            [Column("date")]
            [MaxLength(7)]
            public String date { get; set; }

            [Column("editBy")]
            public string EditBy { get; set; }

            [Column("editDt")]
            public DateTime EditDate { get; set; }

            [Column("creatBy")]
            public String CreatBy { get; set; }

            [Column("creatDt")]
            public DateTime CreateDate { get; set; }
        }
}


