namespace Paraüstü
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Para üstü hesaplama programı");
            Console.Write("Sipariş tutarını giriniz: ");
            int siparisTutar = int.Parse(Console.ReadLine());
           Console.Write("Ödeme türü (Nakit / Kredi Kartı) (N/K): ");
            string odemeSekli = Console.ReadLine();
            if (odemeSekli == "N" || odemeSekli == "n")
            {
                Console.Write("Verdiğiniz miktarı giriniz: ");
                int miktar = int.Parse(Console.ReadLine());
                int paraUstu = miktar - siparisTutar;
                Console.WriteLine("Para üstü: " + paraUstu + " TL.");
            }
            else
            {
                Console.Write("Lütfen ödeyeceğiniz miktarı giriniz: ");
                int krediKarti = int.Parse(Console.ReadLine());
                Console.WriteLine("Kartınızdan " + krediKarti + " TL tutarında ödeme alınmıştır.");
            }
        }
    }
}
