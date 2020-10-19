using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi1.Models
{
    public class SocioModelContext : DbContext
    {
        public SocioModelContext(DbContextOptions<SocioModelContext> options) : base(options) { }
        public DbSet<SocioModel> SocioModels { get; set; }
        public DbSet<BarcoModel> BarcoModels { get; set; }
        public DbSet<PatronModel> PatronModels { get; set; }
        public DbSet<OutputDetail> outputDetails { get; set; }
    }
}
