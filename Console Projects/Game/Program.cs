namespace Game
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Adınızı yazın: ");
            string ad = Console.ReadLine();

            Console.Write("Cinsiyetinz (E/K): ");
            string cinsiyet = Console.ReadLine();

            if (cinsiyet == "E" || cinsiyet == "e")
            {
                Console.WriteLine("Hoşgeldiniz " + ad + " " + "Bey");

            }
            else
            {
                Console.WriteLine("Hoşgeldiniz " + ad + " " + "Hanım");
            }



            

            Console.WriteLine("Bilim laboratuvarında deneylere tabi tutulan " + ad + ", uzun süreli kapalı bir odada yaşamıştır. " +
                "Bir gün, beklenmedik bir fırsatla kaçmayı başarır ve labirentin gizemli koridorlarında özgürlüğüne kavuşmak için maceraya atılır.");

            Console.WriteLine(ad + ", deney odasından kaçarak labirentin ilk odasına ulaşır. " +
                                "Önünde sol ve sağ olmak üzere iki koridor bulunmaktadır:");
            Console.Write("Hangisini koridordan gideceksin (Sol/Sağ): ");
            string secim1 = Console.ReadLine();

            Console.Clear();

            if (secim1 == "Sol" || secim1 == "sol")
            {
                Console.WriteLine("Kilitli bir kapıyla sonlanmıştır." + ad + ", etrafa bakarak anahtarı bulur ve kapıyı açar. " +
                    "Ardından koridorda ilerleyerek başka bir yol ayrımına denk gelir. Karşısında sol ve sağ olmak üzere 2 farklı yol seçeneği vardır. ");
                Console.WriteLine("Hangisini seçeceksin (Sol/Sağ): ");
                string secim2 = Console.ReadLine();
                Console.Clear();
                if (secim2 == "Sol" || secim2 == "sol")
                {
                    Console.WriteLine(ad + ", labirentin derinliklerinde ilerlerken farklı geçitler ve odalar keşfeder. " +
                        "Odalardaki ipuçları ve bulmacalar, laboratuvarın geçmişi ve deneylerle ilgili gizemleri aydınlatmaya başlar. " +
                         ad + ", laboratuvarın amacını ve kendisiyle ilgili gerçekleri keşfetmeye çalışır.");
                    Console.WriteLine("Koridorun sonunda başka bir yol ayrımına gelir. Bu seferki yol ayrımı diğerlerinden biraz farklıdır." +
                        "Soldaki koridorun ucunda bir ışık hüzmesi görünmektedir. Fakat sağdaki koridor çok karanlıktır.");
                    Console.WriteLine("Hangisini seçeceksin (Sol/Sağ): ");
                    string secim3 = Console.ReadLine();
                    Console.Clear();
                    if (secim3 == "sol" || secim3 == "Sol")
                    {
                        Console.WriteLine("Soldaki ışık hüzmesine doğru ilerleyen " + ad +
                            " özgürlüğe kavuşmanın mutluluğunu yaşamaktadır." +
                            " Fakat bu mutluluk fazla uzun sürmeyecektir. Çünkü bu ışık mağaralardaki ufak birkaç delikten gelen küçük bir ışık hüzmesidir." +
                            "Bu deliklere yaklaşıp dışarıya bakmak istediğinde mağarada ki birkaç taş yerinden oynayarak " + ad + " o mağaraya hapsolur. Ve kısa bir süre sonra nefessiz kalarak can verir.");
                    } 
                    else
                    {
                        Console.WriteLine("Sağdaki karanlık koridorda ilerlemeyi seçen " + ad + " labirentin içi çok karanlık olduğu için duvarlara tutunarak ilerlemeye başlar." +" Umudunu kaybetmeye başladığı sırada bir su sesi duymaya başlar." +
                            " Bu ses " + ad + " umudunu tekrar kazanmasına yeterli olmuştur. Ve daha da hızlanarak bu su sesinin kaynağına ilerlemeye başlar." +
                            " İlerledikçe su sesi daha da gürleşir. Artık sadece ses değil suyun kendisini de görmeye başlar. " +
                            "Bu görüntü labirentten kurtulduğunun işaretidir. " +
                            "Şelaleden çıkarak özgürlüğüne kavuşur. ");
                    }

                } else

                {
                    Console.WriteLine("Odalardaki bulmacaları çözerek laboratuvarın gizli amacını ortaya çıkarmaya çalışır. " +
                        "Tuzaklar ve engellerle başa çıkarak labirentin sonuna doğru ilerler.");
                    Console.WriteLine("Labirentin sonuna gittikçe bir ışık hüzmesi " + ad + " gözlerini kamaştırmaktadır." +
                        "Işığa yaklaştıkça herşey netleşmeye başlar." + ad + " karşısında aşağı ve yukarı doğru giden bir merdiven görmektedir.");
                    Console.Write("Hangisini seçeceksin (Yukarı/Aşağı): ");
                    string secim4 = Console.ReadLine();
                    Console.Clear();

                    if (secim4 == "Aşağı" || secim4 == "aşağı")
                    {
                        Console.WriteLine("Yıllardır hiç havanın girmediği bir yere doğru ilerledin. Aşağıya doğru gittikçe havadaki oksijen miktarı iyice azaldı." +
                            "Hiç nefes almayan " + ad + " bitkin düşerek baylır ve özgürlüğüne kavuşamaz.");
                    } else
                    {
                        Console.WriteLine(ad + " yorgun ancak umut dolu bir şekilde merdivenleri tırmanmaya başlar. Her adımında özgürlüğe biraz daha yaklaştığını hisseder. " +
                            "Merdivenlerin sonunda ise güneş ışığı ve taze hava onu karşılar. " + ad +
                            ", dış dünyaya adımını atar atmaz, etrafında yeşilliklerle kaplı bir manzara ve özgür bir atmosferle karşılaşır.");
                    }
                }

            }
            else
            {
                Console.WriteLine("Devasa bir taş blokla kapanmıştır. " +
                    ad + ", bloğu hareket ettirmek için bir mekanizma arar, bulduktan sonra bloğu iterek koridorun sonundaki odaya geçer." +
                    "Karşısında sol ve sağ olmak üzere 2 farklı yol seçeneği vardır. "
                    );
                Console.WriteLine("Hangisini seçeceksin (Sol/Sağ): ");
                string secim5 = Console.ReadLine();
                Console.Clear();

                if (secim5 == "Sol" || secim5 == "sol")
                {
                    Console.WriteLine("Soldaki karanlık koridorda ilerlemeyi seçen " + ad + " labirentin içi çok karanlık olduğu için duvarlara tutunarak ilerlemeye başlar." +
                        " Umudunu kaybetmeye başladığı sırada bir su sesi duymaya başlar." +
                        " Bu ses " + ad + " umudunu tekrar kazanmasına yeterli olmuştur. Ve daha da hızlanarak bu su sesinin kaynağına ilerlemeye başlar." +
                        " İlerledikçe su sesi daha da gürleşir. Artık sadece ses değil suyun kendisini de görmeye başlar. " +
                        "Bu görüntü labirentten kurtulduğunun işaretidir. " +
                        "Şelaleden çıkarak özgürlüğüne kavuşur. ");
                }
                else
                {
                    Console.WriteLine("Sağdaki koridorda ilerleyen " + ad +
                        " özgürlüğe kavuşmanın hayalini kurmaktadır." +
                        " Fakat bu hayal fazla uzun sürmeyecektir." +
                        " Sağdaki koridordan ilerlemeyi seçen " + ad + " yüz yıllardır hiç kimsenin girmediği bir yola girmiştir." +
                        " Karanlık olduğu için duvarlara sürünerek giden " + ad +
                        " bu mağaranın zayıflığının farkında değildir. Biraz daha ilerlemişken kafasna bir taş düşer ve orada can verir. "
                        );
                }
            }
        }
    }
}
