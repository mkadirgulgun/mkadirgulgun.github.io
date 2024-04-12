namespace yetkikontrol
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Yetki Kontrolü'ne Hoşgeldiniz!");
            Console.Write("Kullanıcı adı: ");
            string kullaniciAdi = Console.ReadLine();
            Console.Write("Şifre: ");
            string kullaniciSifre = Console.ReadLine();

            string nickname = "kadirgulgun";
            string password = "kadirg";
            if (kullaniciAdi == nickname && kullaniciSifre == password)
            {
                Console.WriteLine("Giriş Başarılı. Sisteme Hoşgeldiniz");
            } else 
            {
                Console.WriteLine("Kullanıcı adı veya şifre hatalı. Lütfen tekrar deneyin!");
            }
        }
    }
}
