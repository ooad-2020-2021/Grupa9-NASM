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
    [DisplayName("First Name: ")]
       public string Ime { get; set; }
    [Required]
    [DisplayName("Last name: ")]
    public string Prezime { get; set; }
    [Required]
    [DisplayName("E-mail: ")]
    public string Email { get; set; }
     [Required]
     [DisplayName("Username: ")]
    public string Username { get; set; }
    [Required]
    [DisplayName("Password: ")]
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
