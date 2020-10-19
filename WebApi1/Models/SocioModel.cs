using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi1.Models
{
    public class SocioModel
    {
        [Key]
        [Required]
        [Column(TypeName = "nvarchar(13)")]
        public string credentialID { get; set; }

        [Required]
        [Column(TypeName ="varchar(50)")]
        public string name { get; set; }

        [Required]
        [Column(TypeName ="varchar(50)")]
        public string address { get; set; }

        [Required]
        [Column(TypeName ="varchar(12)")]
        public string phone { get; set; }
    }
}
