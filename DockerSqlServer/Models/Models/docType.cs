using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DockerSqlServer.Models
{
        [Table("hr.documentType")]
        public class DocType
        {
            [Key]
            [Column("id")]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public byte Id { get; set; }

            [Column("description")]
            public string description { get; set; }

        }
}
