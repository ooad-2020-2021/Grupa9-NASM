using KomPas.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace KomPAsAutentifikacija1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    public DbSet<KomPas.Models.Korisnik> Korisnik { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

      modelBuilder.Entity<Korisnik>().ToTable("Korisnik");
      base.OnModelCreating(modelBuilder);
    }

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
