using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
namespace proje_bitirme.Models
{
    public class AracVerisi
    {
        [Key]
        public int Id { get; set; }
        public double MotorHacmi { get; set; }
        public int Yil { get; set; }
        public int Silindir { get; set; }
        public string Sanziman { get; set; }
        public string YakitTuru { get; set; }
        public string AracSinifi { get; set; }
        public double Emisyon { get; set; }
        public double Litre100Km { get; set; }
        public double? TahminiTuketim { get; set; }

        
        
        
    

}

    
}