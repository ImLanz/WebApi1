using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi1.Models
{
    public class BarcoModel
    {
        [Key]
        [Column(TypeName = "varchar(13)")]
        public string boatID { get; set; }

        [Column(TypeName = "varchar(15)")]
        public string boatName { get; set; }

        [Column(TypeName = "varchar(13)")]
        public double boatFee { get; set; }

        [Column(TypeName = "varchar(13)")]
        public string mooringNumber { get; set; }

        public string credentialPatnerID { get; set; }
        [ForeignKey("credentialPatnerID")]
        public virtual SocioModel SocioModel { get; set; }
    }
}
