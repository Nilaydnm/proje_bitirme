using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace proje_bitirme.Models
{
    public class Arac
{
    [Key]
    public int Id { get; set; }
    public string Ad { get; set; }
    public string Tip { get; set; }
    public int Yil { get; set; }
    public double MotorHacmi { get; set; } // Liters
    public int BeygirGucu { get; set; } // HP
    public int AgirlikKg { get; set; }
    public string Sanziman { get; set; }
    public double Mpg { get; set; }
    public double Litre100Km { get; set; }
}


}