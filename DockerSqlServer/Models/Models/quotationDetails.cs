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
        public int ClientId { get; set; }
        public string Narration { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public byte Status { get; set; }
        public int InvoiceNo { get; set; }
        public int PoNo { get; set; }
        public decimal InvoiceAmt { get; set; }
        public int PoRefNo { get; set; }
        public int ReportNo { get; set; }
        public byte PoStatus { get; set; }
        public byte InvStatus { get; set; }
        public byte Type { get; set; }
        public string DueDate { get; set; }
        public String EditBy { get; set; }
        public DateTime EditDt { get; set; }
        public String CreatBy { get; set; }
        public DateTime CreatDt { get; set; }
    }
}
