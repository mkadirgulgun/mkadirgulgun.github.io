namespace Sale.Models
{
    public class Urun
    {
        public string Ad { get; set; }
        public int Fiyat { get; set; }
        public int Stok { get; set; }
        public string ImgUrl { get; set; }
    }

    public class SatisModel
    {
        public string Ad { get; set; }
        public int Para { get; set; }
    }
}
