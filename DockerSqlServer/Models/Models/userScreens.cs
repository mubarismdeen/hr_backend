using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DockerSqlServer.Models
{
    [Table("hr.userScreens")]
    public class UserScreens
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 Id { get; set; }

        [Column("userId")]
        public Int16 userId { get; set; }

        [Column("dashboard")]
        public bool dashboard { get; set; }

        [Column("employees")]
        public bool employees { get; set; }

        [Column("attendance")]
        public bool attendance { get; set; }

        [Column("salaryMaster")]
        public bool salaryMaster { get; set; }

        [Column("salaryPayout")]
        public bool salaryPayout { get; set; }

        [Column("leaveSalary")]
        public bool leaveSalary { get; set; }

        [Column("clients")]
        public bool clients { get; set; }

        [Column("gratuity")]
        public bool gratuity { get; set; }

    }
}
