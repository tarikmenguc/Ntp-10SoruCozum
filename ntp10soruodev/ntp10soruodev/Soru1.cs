using System;
using System.Linq;

class Soru1
{
    static void Main()
    {
        // Kullanıcıdan dizi boyutunu ve elemanlarını al
        Console.Write("Dizideki eleman sayısını girin: ");
        int n = int.Parse(Console.ReadLine());

        int[] dizi = new int[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write("Dizinin " + (i + 1) + ". elemanını girin: ");
            dizi[i] = int.Parse(Console.ReadLine());
        }

        // Diziyi sıralama
        Array.Sort(dizi);

        // Kullanıcıdan aranan sayıyı al
        Console.Write("Aramak istediğiniz sayıyı girin: ");
        int arananSayi = int.Parse(Console.ReadLine());

        // İkili arama algoritması ile aranan sayıyı bul
        bool sonuc = IkiliArama(dizi, arananSayi);

        // Sonucu ekrana yazdır
        if (sonuc)
            Console.WriteLine($"{arananSayi} dizide mevcut.");
        else
            Console.WriteLine($"{arananSayi} dizide bulunamadı.");
    }

    // İkili arama metodu
    static bool IkiliArama(int[] dizi, int aranan)
    {
        int sol = 0;
        int sag = dizi.Length - 1;

        while (sol <= sag)
        {
            int orta = (sol + sag) / 2;

            if (dizi[orta] == aranan)
                return true;
            else if (dizi[orta] < aranan)
                sol = orta + 1;
            else
                sag = orta - 1;
        }

        return false;
    }
}
