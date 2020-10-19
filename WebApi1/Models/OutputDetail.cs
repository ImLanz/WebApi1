using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi1.Models
{
    public class OutputDetail
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string userId { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string userName { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string typeUser { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string boatName { get; set; }

        [Required]
        [Column(TypeName = "varchar(13)")]
        public string boatID { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string destiny { get; set; }

        [Required]
        [Column(TypeName = "varchar(10)")]
        public string fecha { get; set; }

        [Required]
        [Column(TypeName = "varchar(10)")]
        public string hora { get; set; }

        [Required]
        public double cuota { get; set; }

        [ForeignKey("boatID")]
        public virtual BarcoModel BarcoModel { get; set; }
    }
}
