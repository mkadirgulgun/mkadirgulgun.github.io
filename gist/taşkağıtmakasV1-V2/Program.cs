using System;

namespace taşkağıtmakasV1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rastgele = new Random();
            string[] Options = ["Taş", "Kağıt", "Makas"];
            bool isGameContinue = true;
            Console.WriteLine("Taş, Kağıt, Makas Oyununa Hoş Geldiniz!!");
            Console.Write("Oyuncu adınızı giriniz: ");
            string inputKullaniciAdi = Console.ReadLine();

            int playerSkor = 0;
            int bilgisayarSkor = 0;
            while (isGameContinue)
            {
                Console.WriteLine("Lütfen bir seçim yapınız");
                Console.WriteLine("1 - Taş");
                Console.WriteLine("2 - Kağıt");
                Console.WriteLine("3 - Makas");
                Console.WriteLine("0 - Oyundan Çıkış");
                int inputPlayerChoice = int.Parse(Console.ReadLine());

                if (inputPlayerChoice == 0)

                {
                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine("Oyundan çıkılıyor...");
                    isGameContinue = false;
                    break;
                } 
                while (inputPlayerChoice > 3)
                {
                    Console.WriteLine("Hatalı değer");
                    inputPlayerChoice = int.Parse(Console.ReadLine());

                };
                Console.Clear();



                int bilgisayarSecimIndex = rastgele.Next(0, 3);
                string bilgisayarSecim = Options[bilgisayarSecimIndex];
                string inputPlayerSecim = Options[(inputPlayerChoice - 1)];

                Console.WriteLine("Bilgisayarın Seçimi: " + bilgisayarSecim);

                if (inputPlayerSecim == bilgisayarSecim)
                {

                    Console.ForegroundColor = ConsoleColor.Blue;

                    Console.WriteLine("Berabere");
                    Console.ResetColor();

                }
                else if (inputPlayerSecim == "Taş" && bilgisayarSecim == "Makas")
                {
                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.WriteLine("Tebrikler! Kazandınız");
                    Console.ResetColor();

                    playerSkor++;
                }
                else if (inputPlayerSecim == "Kağıt" && bilgisayarSecim == "Taş")
                {
                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.WriteLine("Tebrikler! Kazandınız");
                    Console.ResetColor();

                    playerSkor++;
                }
                else if (inputPlayerSecim == "Makas" && bilgisayarSecim == "Kağıt")
                {
                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.WriteLine("Tebrikler! Kazandınız");
                    Console.ResetColor();

                    playerSkor++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Üzgünüz! Kaybettiniz");
                    bilgisayarSkor++;
                    Console.ResetColor();
                }
                Console.WriteLine($"Skor: {inputKullaniciAdi} : {playerSkor} -- Bilgisayar  : {bilgisayarSkor}");

                Console.WriteLine("--------------------------------------------------------");






            }
            Console.WriteLine($"Toplam skor: {inputKullaniciAdi} : {playerSkor} -- Bilgisayar  : {bilgisayarSkor}");

            if (playerSkor > bilgisayarSkor)
            {
                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine($"Tebrikler {inputKullaniciAdi} oyunu kazandın.");
                Console.ResetColor();

            }
            else if (playerSkor == bilgisayarSkor)
            {
                Console.ForegroundColor = ConsoleColor.Blue;

                Console.WriteLine("Oyun berabere bitti.");
                Console.ResetColor();

            }
            else if (playerSkor < bilgisayarSkor)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine($"Üzgünüm {inputKullaniciAdi} oyunu kaybettin.");
                Console.ResetColor();

            }
        }
    }
}
