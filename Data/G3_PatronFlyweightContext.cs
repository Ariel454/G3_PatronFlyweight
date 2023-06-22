using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using G3_PatronFlyweight.Models;

namespace G3_PatronFlyweight.Data
{
    public class G3_PatronFlyweightContext : DbContext
    {
        public DbSet<Producto> Productos { get; set; }

        public G3_PatronFlyweightContext (DbContextOptions<G3_PatronFlyweightContext> options)
            : base(options)
        {
        }

        public DbSet<G3_PatronFlyweight.Models.Producto> Producto { get; set; } = default!;
    }
}
