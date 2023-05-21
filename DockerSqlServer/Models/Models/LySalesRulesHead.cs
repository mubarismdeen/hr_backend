using System;
using System.ComponentModel.DataAnnotations;

namespace DockerSqlServer.Models
{
    public class LySalesRulesHead
    {
        [Key]
        public decimal RuleId { get; set; }
        public string CoCd { get; set; }
        public string Des { get; set; }
        public string CustGrp { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public decimal Points { get; set; }
        public decimal DiscPerc { get; set; }
        public string? EntryBy { get; set; }
        public DateTime? EntryDt { get; set; }
        public string? EditBy { get; set; }
        public DateTime? EditDt { get; set; }
    }

}
