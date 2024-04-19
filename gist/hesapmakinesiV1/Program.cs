namespace hesapmakinesiV1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kaç tane sayı toplamak istiyorsun? ");
            int adet = int.Parse(Console.ReadLine());
            int toplam = 0;
            Console.Clear();

            for (int i = 1; i <= adet; i++)
            {
                Console.Write(i + ". sayıyı giriniz: ");
                toplam += int.Parse(Console.ReadLine());
                Console.Clear() ;
            }
            Console.WriteLine("Sonuç: " + toplam);
            Console.WriteLine("Ortalama: " + (toplam / adet));

        }
    }
}
