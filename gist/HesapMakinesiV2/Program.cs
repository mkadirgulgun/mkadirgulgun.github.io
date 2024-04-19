namespace HesapMakinesiV2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hangi işlemi yapmak istiyorsun? ");
            Console.WriteLine("1-Toplama");
            Console.WriteLine("2-Çıkarma");
            Console.WriteLine("3-Çarpma");
            Console.WriteLine("4-Bölme");
            int inputSecim = int.Parse(Console.ReadLine());
            Console.Clear();

            int toplam = 0;
            int cıkarma = 0;
            int carpma = 1;
            int bölme = 0;

            if (inputSecim == 1)
            {
                Console.WriteLine("Kaç adet sayı ile işlem yapmak istiyorsun?");
                int adet = int.Parse(Console.ReadLine());
                Console.Clear();
                for (int i = 1; i <= adet; i++)
                {
                    Console.Write(i + ". sayıyı giriniz: ");
                    toplam += int.Parse(Console.ReadLine());
                    Console.Clear();
                }
                Console.WriteLine("Toplama sonucu: " + toplam);

            }
            else if (inputSecim == 2)
            {
                Console.WriteLine("Kaç adet sayı ile işlem yapmak istiyorsun?");
                int adet = int.Parse(Console.ReadLine());
                Console.Clear();

                for (int i = 1; i <= 1; i++)
                {
                    Console.Write(i + ". sayıyı giriniz: ");
                    cıkarma += int.Parse(Console.ReadLine());

                    for (int j = 2; j <= adet; j++)
                    {
                        Console.Write(j + ". sayıyı giriniz: ");
                        cıkarma -= int.Parse(Console.ReadLine());
                        Console.Clear();
                    }
                }
                Console.WriteLine("Çıkarma sonucu: " + cıkarma);

            }
            else if (inputSecim == 3)
            {
                Console.WriteLine("Kaç adet sayı ile işlem yapmak istiyorsun?");
                int adet = int.Parse(Console.ReadLine());
                Console.Clear();

                for (int i = 1; i <= adet; i++)
                {
                    Console.Write(i + ". sayıyı giriniz: ");
                    carpma *= int.Parse(Console.ReadLine());
                    Console.Clear();
                }
                Console.WriteLine(carpma);
            }
            else if (inputSecim == 4)
            {
                Console.WriteLine("Kaç adet sayı ile işlem yapmak istiyorsun?");
                int adet = int.Parse(Console.ReadLine());
                Console.Clear();

                for(int i = 1;i <= 1; i++)
                {
                    Console.Write(i + ". sayıyı giriniz: ");
                    bölme += int.Parse(Console.ReadLine());
                    Console.Clear() ;
                    for (int j = 2;j <= adet; j++)
                    {
                        Console.Write(j + ". sayıyı giriniz: ");
                        bölme /= int.Parse(Console.ReadLine());
                        Console.Clear() ;
                    }

                }
                Console.WriteLine("Bölme sonucu: " + bölme);
            }





        }
    }
}
