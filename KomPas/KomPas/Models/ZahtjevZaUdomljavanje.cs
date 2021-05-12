using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KomPas.Models
{
  public class ZahtjevZaUdomljavanje
  {
    #region Properties
    [Required]
    public string Grad { get; set; }
    [Required]
    public string Adresa { get; set; }
    [Required]
    public Korisnik Korisnik { get; set; }
    [Required]
    public Boolean ImaPsa { get; set; }
    [Required]
    public Pas IzabraniPas { get; set; }
      #endregion

    #region Konstruktori
    public ZahtjevZaUdomljavanje() { }

    #endregion
  }
}
