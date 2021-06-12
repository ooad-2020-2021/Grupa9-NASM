using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KomPas.Models
{
  public class Komentar
  {
    #region Properties
    [Key]
    [Required]
    public int KomentarID { get; set; }
    [Required]
    public Korisnik AutorKomentara { get; set; }
    [DataType(DataType.Date)]
    public DateTime VrijemeObjave { get; set; }
    [Required]
    public string Tekst { get; set; }
    [Required]
    public Dokument Dokument { get; set; }

    #endregion

    #region Konsturktori
    public Komentar() { }
    #endregion
  }
}
