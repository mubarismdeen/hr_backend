using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;

namespace DockerSqlServer.Models
{
    [Table("quotationDetails", Schema = "hr")]
    public class QuotationDetail
    {
        [Key]
        public int Id { get; set; }
        public string ClientName { get; set; }
        public string Narration { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public int QuotationNo { get; set; }
        public int InvoiceNo { get; set; }
        public byte PoStatus { get; set; }
        public byte InvStatus { get; set; }
        public byte Type { get; set; }
        public byte DocId { get; set; }
        public string DueDate { get; set; }
        public short EditBy { get; set; }
        public DateTime EditDt { get; set; }
        public short CreatBy { get; set; }
        public DateTime CreatDt { get; set; }
    }
}
