using System;
using System.ComponentModel.DataAnnotations;

namespace DockerSqlServer.Models
{
    public class LyCustomersModel
    {
        [Key]
        public string Cd { get; set; }
        public string Des { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string MName { get; set; }
        public string CoCd { get; set; }
        public bool Gender { get; set; }
        public DateTime? BirthDt { get; set; }
        public string Addr1 { get; set; }
        public string Addr2 { get; set; }
        public string Addr3 { get; set; }
        public int? CustCoCd { get; set; }
        public int? AreaCd { get; set; }
        public int? Religion { get; set; }
        public int? Profession { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string UID { get; set; }
        public string IDType { get; set; }
        public string Curr { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string CustGrp { get; set; }
        public string CardType { get; set; }
        public bool Active { get; set; }
        public bool BlackListed { get; set; }
        public bool CardIssued { get; set; }
        public string Remarks { get; set; }
        public string EntryBy { get; set; }
        public string EditBy { get; set; }
    }

}
