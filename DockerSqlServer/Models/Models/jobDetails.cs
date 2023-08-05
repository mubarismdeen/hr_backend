using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DockerSqlServer.Models
{
    [Table("jobDetails", Schema = "hr")]
    public class JobDetail
    {
        public int Id { get; set; }
        public string Job { get; set; }
        public string Narration { get; set; }
        public string AssignedDate { get; set; }
        public string DueDate { get; set; }
        public byte JobStatus { get; set; }
        public byte Status { get; set; }
        public short AssignedTo { get; set; }
        public short EditBy { get; set; }
        public DateTime EditDt { get; set; }
        public short CreatBy { get; set; }
        public DateTime CreatDt { get; set; }
    }
}

