using System;
using System.ComponentModel.DataAnnotations;

namespace DockerSqlServer.Models
{
    public class LyCusTransUpdate
    {
        [Key]

        public string CustId { get; set; }
        public decimal BillNo { get; set; }
        public int TrnPosId { get; set; }
        public string TrnDt { get; set; }
        public char Typ { get; set; }
        public string Loc { get; set; }
    }

}
