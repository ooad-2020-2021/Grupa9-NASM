using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KomPas.Models
{
  public class ZahtjevZaUdomljavanje
  {
    #region Properties

    [Required]
    [Key]
    public int ZahtjevZaUdomljavanjeID { get; set; }
    [Required]
    [DisplayName("Grad: ")]
    public string Grad { get; set; }
    [Required]
    [DisplayName("Adresa: ")]
    public string Adresa { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    [DisplayName("Već imate psa: ")]

    public Boolean ImaPsa { get; set; }
    [Required]
    [DisplayName("Broj izabranog psa: ")]
    public int IzabraniPas { get; set; }
      #endregion

    #region Konstruktori
    public ZahtjevZaUdomljavanje() { }

    #endregion
  }
}
