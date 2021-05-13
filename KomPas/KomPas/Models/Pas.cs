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
    [DisplayName("Name: ")]
    public string Ime { get; set; }
    
    [Required]
    [DisplayName("Gender: ")]
    public Spol Spol { get; set; }

    [Required]
    [DisplayName("Breed: ")]
    public string Rasa { get; set; }

    [Required]
    [DisplayName("Weight: ")]
    public int Tezina { get; set; }

    [Required]
    [DisplayName("Health problem: ")]
    public string ZdravstveniProblem { get; set; }

    [Required]
    [DisplayName("Castrated/Sterilized: ")]
    public Boolean KastriranSterilisan { get; set; }

    [Required]
    public string Slika { get; set; }


    #endregion

    #region Konstruktori
    public Pas() { }
    #endregion
  }
}
