using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KomPas.Models
{
  public class Korisnik
  {
    #region Properties
     [Key]
     [Required]
     public int ID { get; set; }
    [Required]
       public string Ime { get; set; }
    [Required]
    public string Prezime { get; set; }
    [Required]
    public string Email { get; set; }
     [Required]
    public string Username { get; set; }
    [Required]
    [RegularExpression(@"[0-9| |a-z|A-Z]*", ErrorMessage = "Dozvoljeno korištenje velikih i malih slova, te brojva i razmaka u passwordu")]
    public string Password { get; set; }
    [Required]
    public Pas Pas { get; set; }
    #endregion


    #region Konstruktori
    public Korisnik() { }
    #endregion
  }
}
