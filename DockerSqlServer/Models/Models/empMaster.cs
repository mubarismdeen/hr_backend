using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DockerSqlServer.Models
{
    [Table("empMaster", Schema = "hr")]
    public class EmpMaster
    {
            [Key]
            [Column("id")]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }

            [Column("empCode")]
            public String EmpCode { get; set; }

            [Column("name")]
            public string Name { get; set; }
            
            [Column("status")]
            public byte Status { get; set; }

            [Column("mobile1")]
            public string Mobile1 { get; set; }

            [Column("mobile2")]
            public string Mobile2 { get; set; }

            [Column("depId")]
            public byte DepId { get; set; }

            [Column("statusId")]
            public byte StatusId { get; set; }

            [Column("natianalityId")]
            public byte NatianalityId { get; set; }
        
            [Column("joinDt")]
            public DateTime JoinDt { get; set; }

            [Column("resignDt")]
            public DateTime? ResignDt { get; set; }

            [Column("birthDt")]
            public DateTime BirthDt { get; set; }

            [Column("editBy")]
            public String EditBy { get; set; }

            [Column("editDate")]
            public DateTime EditDate { get; set; }

            [Column("creatBy")]
            public String CreatBy { get; set; }

            [Column("creatDate")]
            public DateTime CreatDate { get; set; }
    }
}
