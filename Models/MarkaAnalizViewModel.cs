namespace proje_bitirme.Models
{
    public class MarkaAnalizViewModel
{
    public double OrtalamaMotorHacmi { get; set; }
        public int OrtalamaSilindir { get; set; }
        public double OrtalamaEmisyon { get; set; }
        public double OrtalamaLitre100Km { get; set; }
        public double OrtalamaTahminiTuketim { get; set; }

        public double MinEmisyon { get; set; }
        public double MaxEmisyon { get; set; }

        public int ToplamKayit { get; set; }

        public Dictionary<string, int> SanzimanDagilimi { get; set; }
        public Dictionary<string, int> YakitTuruDagilimi { get; set; }
        public Dictionary<string, int> AracSinifiDagilimi { get; set; }

}
}
