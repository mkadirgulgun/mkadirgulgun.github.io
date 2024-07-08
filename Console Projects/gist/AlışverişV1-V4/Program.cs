namespace AlışverişV1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string[] Urunler = ["1- Yumurta", "2- Ekmek", "3- Sosis", "4- Salam", "5- Meyve Suyu"];
            int[] Fiyatlar = [3, 10, 6, 8, 20];
            int[] stok = [20, 25, 30, 17, 23];
            bool isShopping = true;
            int toplam = 0;


            while (isShopping)
            {
                
                Console.WriteLine("Almak istediğiniz ürünü seçiniz: ");
                for (int i = 0; i < Urunler.Length; i++)
                {
                    Console.WriteLine($"{Urunler[i]}  -  Adet'i {Fiyatlar[i]} TL  - {stok[i]} adet ürün bulunmaktadır.");
                }


                
                Console.WriteLine("Toplam tutarı görmek için (t) basınız. ");
                string inputSecim = Console.ReadLine();

                if (inputSecim == "1")
                {
                    Console.Clear();
                    Console.Write("Kaç adet almak istiyorsunuz: ");
                   int adet = int.Parse(Console.ReadLine());

                    if (adet > stok[0])
                    {
                        Console.WriteLine("Stokta bu kadar ürün yok.");
                        
                    }
                    else
                    {
                    toplam += (Fiyatlar[0] * adet);
                    stok[0] -= adet;
                    Console.WriteLine($"Stokta {stok[0]} adet ürün kaldı.");
                             
                    }

                    Console.WriteLine("---------------------------------------------------------------------");




                }
                else if (inputSecim == "2")
                {
                    Console.Clear();

                    Console.Write("Kaç adet almak istiyorsunuz: ");
                    int adet = int.Parse(Console.ReadLine());

                    if (adet > stok[1])
                    {
                        Console.WriteLine("Stokta bu kadar ürün yok.");

                    }
                    else
                    {
                    toplam += (Fiyatlar[1] * adet);
                    stok[1] -= adet;
                    Console.WriteLine($"Stokta {stok[1]} adet ürün kaldı.");

                    }

                    Console.WriteLine("---------------------------------------------------------------------");
                }
                else if (inputSecim == "3")
                {
                    Console.Clear();
                    Console.Write("Kaç adet almak istiyorsunuz: ");
                    int adet = int.Parse(Console.ReadLine());


                    if (adet > stok[2])
                    {
                        Console.WriteLine("Stokta bu kadar ürün yok.");

                    } else
                    {

                    toplam += (Fiyatlar[2] * adet);
                    stok[2] -= adet;
                    Console.WriteLine($"Stokta {stok[2]} adet ürün kaldı.");
                    }



                    Console.WriteLine("---------------------------------------------------------------------");
                }
                else if (inputSecim == "4")
                {
                    Console.Clear();
                    Console.Write("Kaç adet almak istiyorsunuz: ");
                    int adet = int.Parse(Console.ReadLine());

                    if (adet > stok[3])
                    {

                        Console.WriteLine("Stokta bu kadar ürün yok.");
                    }
                    else
                    {

                    toplam += (Fiyatlar[3] * adet);
                    stok[3] -= adet;
                    Console.WriteLine($"Stokta {stok[3]} adet ürün kaldı.");
                    }



                    Console.WriteLine("---------------------------------------------------------------------");
                }
                else if (inputSecim == "5")
                {
                    Console.Clear();
                    Console.Write("Kaç adet almak istiyorsunuz: ");
                    int adet = int.Parse(Console.ReadLine());

                    if (adet > stok[4])
                    {

                        Console.WriteLine("Stokta bu kadar ürün yok.");
                    } else
                    {

                    toplam += (Fiyatlar[4] * adet);
                    stok[4] -= adet;
                    Console.WriteLine($"Stokta {stok[4]} adet ürün kaldı.");
                    }


                    Console.WriteLine("---------------------------------------------------------------------");
                }
                else if (inputSecim == "t" || inputSecim == "T")
                {
                    isShopping = false;
                    Console.WriteLine("Alışverişiniz toplam: " + toplam + "TL tutmuştur.");
                    break;
                }





            }
            

        }
    }
}
