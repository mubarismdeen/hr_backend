using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DockerSqlServer.Models
{
    [Table("documentDetails", Schema = "hr")]
    public class DocumentDetails
    {
        [Key]
        public Int32 Id { get; set; }
        public string narration { get; set; }
        public String empCode { get; set; }
        public Byte docid { get; set; }
        public DateTime? dueDate { get; set; }
        public DateTime? renewedDate { get; set; }
        public byte Status { get; set; }
        public String creatBy { get; set; }
        public DateTime? creatDt { get; set; }
        public String EditBy { get; set; }
        public DateTime? EditDt { get; set; }
    }

}
