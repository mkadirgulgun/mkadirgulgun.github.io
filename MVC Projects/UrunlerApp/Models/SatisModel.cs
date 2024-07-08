using System.ComponentModel.DataAnnotations;

namespace UrunlerApp.Models
{
    public class SatisModel
    {
        [Required]
        public string Ad { get; set; }

        [Required]
        public int Fiyat { get; set; }
    }
}
