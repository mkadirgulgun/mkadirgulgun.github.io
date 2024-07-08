using System.ComponentModel.DataAnnotations;

namespace UrunlerApp.Models
{
                                                                                
    public class SatisModel
    {
        [Required]
        public string Ad { get; set; }

    }   

    public class Urun
    {
        public string Ad { get; set; }

        public int Fiyat { get; set; }

        public int Stok { get; set; }   
    }
}
