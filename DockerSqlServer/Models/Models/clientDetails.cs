using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DockerSqlServer.Models
{
        [Table("clientDetails", Schema ="hr")]
        public class ClientDetails
        {
            [Key]
            [Column("id")]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }

            [Column("name")]
            public string Name { get; set; }

            [Column("address")]
            public string Address { get; set; }

            [Column("mobile1")]
            public string Mobile1 { get; set; }

            [Column("mobile2")]
            public string Mobile2 { get; set; }

            [Column("editBy")]
            public short EditBy { get; set; }

            [Column("editDt")]
            public DateTime EditDt { get; set; }

            [Column("creatBy")]
            public short CreatBy { get; set; }

            [Column("creatDt")]
            public DateTime CreatDt { get; set; }
        }
}
