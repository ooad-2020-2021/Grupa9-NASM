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

        public DbSet<KomPas.Models.ZahtjevZaUdomljavanje> ZahtjevZaUdomljavanje { get; set; }

        public DbSet<KomPas.Models.Profil> Profil { get; set; }

        public DbSet<KomPas.Models.Dokument> Dokument { get; set; }

        public DbSet<KomPas.Models.Forum> Forum { get; set; }

        public DbSet<KomPas.Models.Pas> Pas { get; set; }

        public DbSet<KomPas.Models.Komentar> Komentar { get; set; }

        public DbSet<KomPas.Models.Podsjetnik> Podsjetnik { get; set; }

        public DbSet<KomPas.Models.Post> Post { get; set; }
    }
}
