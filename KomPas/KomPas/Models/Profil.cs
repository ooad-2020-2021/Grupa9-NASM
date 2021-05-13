using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KomPas.Models
{
  public class Profil
  {
 
    #region Properties
    [Required]
    [Key]
    public int ProfilID { get; set; }
     [Required]

    public Korisnik Korisnik { get; set; }
    [Required]
    public Pas Pas { get; set; }

    [NotMapped]
    public List<Podsjetnik>podsjetnici { get; set; }
    #endregion

    #region Konstruktori
    public Profil() { }
    #endregion
  }
}
