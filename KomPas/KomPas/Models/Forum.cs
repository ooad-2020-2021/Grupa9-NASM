using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KomPas.Models
{
  public class Forum
  {
    [Required]
    [Key]
    public int ForumID { get; set; }
    #region Properties
     [Required]
    public int BrojAktivnihKorisnika { get; set; }
      [NotMapped]
    public List<Post> Post { get; set; }
    #endregion

    #region Konstruktor
    public Forum() { }
    #endregion
  }
}
