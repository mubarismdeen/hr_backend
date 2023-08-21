using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DockerSqlServer.Models
{
    [Table("hr.user")]
    public class user
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 Id { get; set; }

        [Column("userCd")]
        public Int16 userCd { get; set; }

        [Column("password")]
        public string password { get; set; }
        
        [Column("name")]
        public string name { get; set; }

        [Column("creatBy")] 
        public String creatBy { get; set; }

        [Column("creatDt")]
        public DateTime? creatDt { get; set; }

        [Column("editBy")]
        public String EditBy { get; set; }

        [Column("editDt")]
        public DateTime? EditDt { get; set; }

        [Column("empCode")]
        public String EmpCode { get; set; }
    }

}
