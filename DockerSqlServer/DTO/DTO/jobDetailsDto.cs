using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DockerSqlServer.DTO
{
    public class JobDetailDto
    {
        public int Id { get; set; }
        public string Job { get; set; }
        public string Narration { get; set; }
        public string AssignedDate { get; set; }
        public string DueDate { get; set; }
        public string JobStatus { get; set; }
        public string AssignedTo { get; set; }
        public string EditBy { get; set; }
        public DateTime EditDt { get; set; }
        public string CreatBy { get; set; }
        public DateTime CreatDt { get; set; }
    }
}

