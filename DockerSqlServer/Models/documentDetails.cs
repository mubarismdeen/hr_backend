using System;
using System.ComponentModel.DataAnnotations;

namespace DockerSqlServer.Models
{
    public class documentDetails
    {
        [Key]
        public Int32 Id { get; set; }
        public string narration { get; set; }
        public Int16? empCode { get; set; }
        public Byte docid { get; set; }
        public DateTime? dueDate { get; set; }
        public DateTime? renewedDate { get; set; }
        public Int16? creatBy { get; set; }
        public DateTime? creatDt { get; set; }
        public Int16? EditBy { get; set; }
        public DateTime? EditDt { get; set; }
    }

}
