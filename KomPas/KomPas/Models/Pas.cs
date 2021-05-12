using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KomPas.Models
{

  public enum Spol
  {
    MALE, FEMALE
  }
  public class Pas
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
    public Spol Spol { get; set; }

    [Required]
    public string Rasa { get; set; }

    [Required]
    public int Tezina { get; set; }

    [Required]
    public string ZdravstveniProblem { get; set; }

    [Required]
    public Boolean KastriranSterilisan { get; set; }

    [Required]
    public string Slika { get; set; }


    #endregion

    #region Konstruktori
    public Pas() { }
    #endregion
  }
}
