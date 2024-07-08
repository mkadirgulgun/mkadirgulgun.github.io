namespace MVCMagaza.Models
{
    public class Shop
    {   
        public string Product { get; set; }
        public string Currency { get; set; }
        public int Price { get; set; }
        public string ImgUrl { get; set; }  
        public string Slug { get; set; }
    }
    public class ViewModel
    {
        public List<Shop> Products { get; set; }
        public List<Shop> Banner { get; set; }
    }
}
