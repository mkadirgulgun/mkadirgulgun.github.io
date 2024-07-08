namespace quiz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] sorular = ["gökyüzü ne renktir?", "Türkiye'nin başkenti neresidir?"];
            string[] cevaplar = ["Mavi", "Ankara"];
            string[] secenekler = ["kırmızı|Mavi|Pembe|Mor", "Ankara|İstanbul|İzmir"];
            bool isContinue = true;


            Console.WriteLine("Bilgi Yarışmasına Hoş Geldiniz!!");
            Console.Write("Adınızı Giriniz: ");
            string inputPlayerName = Console.ReadLine();
            Console.WriteLine("Yarışmaya başlamak için rastgele bir tuşa tıklayınız!!");
            Console.ReadLine();
            Console.Clear();

            int dogruSkor = 0;
            int yanlisSkor = 0;

            for (int i = 0; i < sorular.Length; i++)
            {
                
                Console.WriteLine(sorular[i]);

                string[] secenek = secenekler[i].Split("|");

                for (int j = 0; j < secenek.Length; j++)
                {
                    Console.WriteLine(j + 1 + "." + secenek[j]);
                }

                Console.WriteLine("Cevap");
                string cevap = Console.ReadLine();
                string gercekCevap = cevaplar[i];

                if (cevap == gercekCevap || secenek[int.Parse(cevap) - 1] == gercekCevap)
                {
                    Console.WriteLine("Cevap doğru.");
                    dogruSkor++;
                    Console.WriteLine("---------------------------------------------");
                }
                else
                {
                    Console.WriteLine("Cevap yanlış.");
                        yanlisSkor ++;
                    Console.WriteLine("---------------------------------------------");

                }

            }

            Console.WriteLine(dogruSkor + " Doğru.");
            Console.WriteLine(yanlisSkor + " Yanlış.");
        }
    }
}

