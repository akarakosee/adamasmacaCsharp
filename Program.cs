using System;
using System.Collections.Generic;

class AdamAsmaca
{
    static void Main(string[] args)
    {
        // Kelimelerin listesi
        string[] kelimeler = { "elma", "muz", "kiraz", "incir", "böğürtlen", "üzüm", "kavun", "şeftali" };

        // Rastgele bir kelime seç
        string kelime = kelimeler[new Random().Next(kelimeler.Length)];

        // Kelimenin durumunu saklayan dizi
        char[] kelimeDurumu = new char[kelime.Length];
        for (int i = 0; i < kelime.Length; i++)
        {
            kelimeDurumu[i] = '_';
        }

        // Başlangıç can sayısı
        int canSayisi = 6;

        // Kullanıcının tahminlerini saklayan liste
        List<char> tahminler = new List<char>();

        while (canSayisi > 0)
        {
            Console.WriteLine("Kelime: " + new string(kelimeDurumu));
            Console.WriteLine("Kalan can sayısı: " + canSayisi);
            Console.Write("Bir harf tahmin edin: ");

            // Kullanıcının tahminini al ve küçük harfe çevir
            char tahmin = char.ToLower(Console.ReadKey().KeyChar);
            Console.WriteLine("\n");

            // Eğer tahmin daha önce yapıldıysa uyarı ver ve döngünün başına dön
            if (tahminler.Contains(tahmin))
            {
                Console.WriteLine("Bu harfi daha önce tahmin ettiniz. Başka bir harf deneyin.");
                Console.WriteLine("\n");
                continue;
            }

            // Tahmini listeye ekle
            tahminler.Add(tahmin);

            bool bulundu = false;
            for (int i = 0; i < kelime.Length; i++)
            {
                // Eğer tahmin kelimenin içinde varsa, kelime durumunu güncelle
                if (kelime[i] == tahmin)
                {
                    kelimeDurumu[i] = tahmin;
                    bulundu = true;
                }
            }

            // Eğer tahmin yanlışsa, can sayısını azalt
            if (!bulundu)
            {
                canSayisi--;
            }

            // Eğer kelime tamamen tahmin edildiyse, tebrik et ve programı bitir
            if (new string(kelimeDurumu) == kelime)
            {
                Console.WriteLine("Tebrikler, kelimeyi doğru tahmin ettiniz!");
                Console.ReadLine();
                return;
            }
        }

        // Eğer can hakkı tükendi ise, doğru kelimeyi göster
        Console.WriteLine("Can hakkınız tükendi. Kelime: " + kelime);
        Console.ReadLine();
    }
}
