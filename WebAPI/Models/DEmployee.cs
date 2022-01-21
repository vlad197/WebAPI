using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class DEmployee
    {
        [Key]
        public int id {get; set;}
        public long CNP { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string name { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string email { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string department { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string leader { get; set; }


    }
}
