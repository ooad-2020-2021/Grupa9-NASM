using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KomPas.Models
{
  public class Podsjetnik
  {
    #region Properties
    [Key]
    [Required]
    public int PodsjetnikID { get; set; }
    [Required]
    public string Tekst { get; set; }
    [DataType(DataType.Date)]
    [Required]
    public DateTime Termin { get; set; }


    #endregion

    #region Konstruktor
    public Podsjetnik() { }
    #endregion
  }
}
