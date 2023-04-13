using System;
using System.ComponentModel.DataAnnotations;

namespace DockerSqlServer.Models
{
    public class docScreenDetails
    {
        [Key]
        public Int32 Id { get; set; }
        public string narration { get; set; }
        public string docType { get; set; }
        public DateTime? dueDate { get; set; }
        public DateTime? renewedDate { get; set; }
        public string? creatBy { get; set; }
        public DateTime? creatDt { get; set; }
        public string? EditBy { get; set; }
        public DateTime? EditDt { get; set; }
    }

}
