using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KomPas.Models;

namespace KomPas.Data
{
    public class KomPasContext : DbContext
    {
        public KomPasContext (DbContextOptions<KomPasContext> options)
            : base(options)
        {
        }

        public DbSet<KomPas.Models.Korisnik> Korisnik { get; set; }
    }
}
