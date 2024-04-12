namespace weather
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Merhaba! Bugün hava nasıl? İşte hava durumu giyim önerileri programı size günlük olarak hava koşullarına göre nasıl giyinmeniz gerektiği konusunda yardımcı olacak.");
            Console.Write("Sıcaklık: ");
            int derece = int.Parse(Console.ReadLine());
            if (derece <= 0)
            {
                Console.WriteLine("Hava çok soğuk! Kalın mont, kazak, atkı, bere ve eldiven gibi yün veya polar malzemelerle vücudunuzu sıcak tutun.");
                Console.WriteLine("Su geçirmez botlar giyin ve uzun çoraplar tercih edin.");
                Console.WriteLine("Yüzünüzü ve başınızı korumak için bere ve eşarplar kullanın.");
            } else if (derece <= 15)
            {
                Console.WriteLine("Soğuk bir gün! Kalın bir mont veya palto, kazak, pantolon ve atkı gibi katmanlı giysiler giyin.");
                Console.WriteLine("Kafa üşümesini önlemek için bere veya şapka takın.");
                Console.WriteLine("Ayakkabı seçimine dikkat edin, su geçirmeyen veya suya dayanıklı modeller tercih edin.");
            }
            else
            {
                Console.WriteLine("Sıcak bir gün! Tişört, şort, hafif elbiseler veya yazlık kıyafetler giyin.");
                Console.WriteLine("Açık renkli ve ince kumaşlı giysiler tercih ederek serin kalın.");
                Console.WriteLine("Şapka, güneş gözlüğü ve güneş kremi kullanarak güneşten korunun.");
            }



        }
    }
}
