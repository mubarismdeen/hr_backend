using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DockerSqlServer.Models
{
    [Table("userPrivileges", Schema="hr")]
    public class UserPrivileges
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Column("userId")]
        public short userId { get; set; }

        [Column("privilegeName")]
        public string privilegeName { get; set; }

        [Column("viewPrivilege")]
        public bool? viewPrivilege { get; set; }

        [Column("addPrivilege")]
        public bool? addPrivilege { get; set; }

        [Column("editPrivilege")]
        public bool? editPrivilege { get; set; }

        [Column("deletePrivilege")]
        public bool? deletePrivilege { get; set; }

        [Column("creatBy")]
        public String creatBy { get; set; }

        [Column("creatDt")]
        public DateTime? creatDt { get; set; }

        [Column("editBy")]
        public String EditBy { get; set; }

        [Column("editDt")]
        public DateTime? EditDt { get; set; }

    }
}
