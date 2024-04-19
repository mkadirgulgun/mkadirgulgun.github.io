string[] Urunler = ["1) Laptop ", "2) Telefon ", "3) Televizyon ", "4) Hoparlör ", "5) Elektrikli Süpürge ", "6) Saat ", "7) Elbise ", "8) Ayakkabı ", "9) Kahve Makinesi ", "10) Kulaklık "];
int[] Fiyatlar = [4500, 2500, 4000, 300, 800, 1500, 1200, 400, 600, 300];

int alınanUrunFiyatları = 0;
string alınanUrunler = "";
int toplamFiyat = 0;


while (true)
{
    for (int j = 0; j < Urunler.Length; j++)
    {

        Console.Write(Urunler[j] + " - ");
        Console.Write(Fiyatlar[j] + " TL.");
        Console.WriteLine();
    }

    Console.Write("Almak istediğin ürünlerin numarasını seçebilirsin. İşlemi tamamlamak için x tuşuna basın ");

    string input = Console.ReadLine();

    if (input == "x")
    {
        Console.Write("Ödeme yapacağınız tutarı giriniz: ");
        int nakitOdeme = int.Parse(Console.ReadLine());
        if (nakitOdeme < toplamFiyat)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine((toplamFiyat - nakitOdeme) + " TL daha vermeniz lazım.");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("Para üstü: " + (nakitOdeme - toplamFiyat) + " TL.");
            Console.ResetColor ();
        }
        break;
    }
    int inputUrun = int.Parse(input);
    inputUrun += -1;
    Console.Write("Kaç adet almak istediğinizi seçin: ");
    int adet = int.Parse(Console.ReadLine());
    Console.Clear();



    alınanUrunFiyatları += Fiyatlar[inputUrun];
    alınanUrunler += Urunler[inputUrun];
    toplamFiyat = alınanUrunFiyatları * adet;
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Toplam ürün fiyatı: " + toplamFiyat);
    Console.ResetColor();
    Console.ForegroundColor = ConsoleColor.Magenta;

    Console.WriteLine("Alınan ürünler : " + adet + " adet " + alınanUrunler);
    Console.ResetColor();

}
