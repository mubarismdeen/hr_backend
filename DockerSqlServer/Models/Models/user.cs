﻿using System;
using System.ComponentModel.DataAnnotations;

namespace DockerSqlServer.Models
{
    public class user
    {
        [Key]
        public Int32 Id { get; set; }
        public Int16 userCd { get; set; }
        public string password { get; set; }
        public Int16? creatBy { get; set; }
        public DateTime? creatDt { get; set; }
        public Int16? EditBy { get; set; }
        public DateTime? EditDt { get; set; }
    }

}
