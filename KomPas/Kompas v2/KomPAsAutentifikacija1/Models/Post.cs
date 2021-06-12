using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KomPas.Models
{
  public class Post
  {
    #region Properties
    [Required]
    [Key]
    public int PostID { set; get; }
    [Required]
    public string Tekst { set; get; }
    [Required]
    public int BrojKomentara { get; set; }
    [Required]
    public int BrojReakcija { get; set; }
      [NotMapped]
    public List<Komentar>Komentari { get; set; }

    [Required]
    public Korisnik AutorPosta { get; set; }
    [Required]
    public Dokument Dokument { get; set; }

    #endregion

    #region Konstruktori
    public Post() { }
    #endregion
  }
}
