using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KomPas.Models 

{
  public class Dokument
  {
    #region Properties
    [Key]
    [Required]
    public int DokumentID { get; set; }
    [Required]
    public string Datoteka { get; set; }
    #endregion
    #region Konstruktori
    public Dokument() { }
    #endregion

  }
}
