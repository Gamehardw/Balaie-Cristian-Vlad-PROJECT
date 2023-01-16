using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Balaie_Cristian_Vlad_PROJECT.Models;

namespace Balaie_Cristian_Vlad_PROJECT.Data
{
    public class Balaie_Cristian_Vlad_PROJECTContext : DbContext
    {
        public Balaie_Cristian_Vlad_PROJECTContext (DbContextOptions<Balaie_Cristian_Vlad_PROJECTContext> options)
            : base(options)
        {
        }

        public DbSet<Balaie_Cristian_Vlad_PROJECT.Models.Compound> Compound { get; set; } = default!;

        public DbSet<Balaie_Cristian_Vlad_PROJECT.Models.Metalloid> Metalloid { get; set; }

        public DbSet<Balaie_Cristian_Vlad_PROJECT.Models.Metal> Metal { get; set; }

        public DbSet<Balaie_Cristian_Vlad_PROJECT.Models.NonMetal> NonMetal { get; set; }
    }
}
