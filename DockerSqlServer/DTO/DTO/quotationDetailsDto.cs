using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;

namespace DockerSqlServer.DTO
{
    public class QuotationDetailDto
    {
        [Key]
        public int Id { get; set; }
        public string ClientName { get; set; }
        public string Narration { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public int QuotationNo { get; set; }
        public int InvoiceNo { get; set; }
        public string PoStatus { get; set; }
        public string InvStatus { get; set; }
        public string Type { get; set; }
        public byte DocId { get; set; }
        public string DueDate { get; set; }
        public string EditBy { get; set; }
        public DateTime EditDt { get; set; }
        public string CreatBy { get; set; }
        public DateTime CreatDt { get; set; }
    }
}
