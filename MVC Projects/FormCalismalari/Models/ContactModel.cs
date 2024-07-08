using System.ComponentModel.DataAnnotations;

namespace FormCalismalari.Models
{
    public class ContactModel
    {
        [Required]
        public string Ad { get; set; }

        [Required]
        public string Soyad { get; set; }

        [Required]
        public string EPosta { get; set; }

        [Required]
        public string Cinsiyet { get; set; }

        [Required]
        public string Adres { get; set; }

        [Required]
        public string AranmaSaati { get; set; }

        [Required]
        public bool SozlesmeOnay { get; set; }  
    }
}
