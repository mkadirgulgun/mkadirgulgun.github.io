namespace HesapMakinesiV3
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Sayı giriniz: ");
            //int inputSayi = int.Parse(Console.ReadLine());
            double inputSayi = Convert.ToDouble(Console.ReadLine());
            bool isNumber = true;

            while (isNumber)
            {

                Console.WriteLine("Yapmak istediğiniz işlemi seçin");
                Console.WriteLine("1- Toplama");
                Console.WriteLine("2- Çıkarma");
                Console.WriteLine("3-Çarpma");
                Console.WriteLine("4-Bölme");
                string inputSecim = Console.ReadLine();

                if (inputSecim == "1")
                {
                    Console.Write("Sayı giriniz: ");
                    double inputToplama = Convert.ToDouble(Console.ReadLine());
                    inputSayi += inputToplama;
                    Console.WriteLine("Toplama sonucu: " + inputSayi);

                }
                else if (inputSecim == "2")
                {
                    Console.WriteLine("Sayı giriniz: ");
                    double inputCikarma = Convert.ToDouble(Console.ReadLine());
                    inputSayi -= inputCikarma;
                    Console.WriteLine("Çıkarma sonucu: " + inputSayi);

                }
                else if (inputSecim == "3")
                {
                    Console.WriteLine("Sayı giriniz: ");
                    double inputCarpma = Convert.ToDouble(Console.ReadLine());
                    inputSayi *= inputCarpma;
                    Console.WriteLine("Çarpma Sonucu: " + inputSayi);
                }
                else if (inputSecim == "4")
                {
                    Console.WriteLine("Sayı giriniz: ");
                    double inputBölme = Convert.ToDouble(Console.ReadLine());
                    //int inputBölme = int.Parse(Console.ReadLine());
                    inputSayi /= inputBölme;
                    Console.WriteLine("Bölme Sonucu: " + inputSayi);
                }
                else if (inputSecim == "e")
                {
                    isNumber = false;
                    break;
                }





            }

            Console.WriteLine("Hesaplama sona erdi!!");
            Console.WriteLine("Hesap sonucu: " + inputSayi);


        }
    }
}
