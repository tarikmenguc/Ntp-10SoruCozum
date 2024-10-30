using System;
using System.Collections.Generic;
using System.Linq;

class Soru2
{
    static void Main()
    {
        List<int> sayilar = new List<int>();
        int girilenSayi;

        // Kullanıcıdan pozitif tam sayılar alınması
        Console.WriteLine("Pozitif tam sayılar girin (Ortamayı ve medyanı görmek için 0 girin):");

        do
        {
            girilenSayi = int.Parse(Console.ReadLine());

            if (girilenSayi > 0)
                sayilar.Add(girilenSayi);

        } while (girilenSayi != 0);

        // Sayı dizisi boşsa, programdan çıkış
        if (sayilar.Count == 0)
        {
            Console.WriteLine("Hiçbir pozitif sayı girilmedi.");
            return;
        }

        // Ortalama hesaplama
        double ortalama = sayilar.Average();

        // Medyan hesaplama
        sayilar.Sort();
        double medyan;

        if (sayilar.Count % 2 == 1) // Eleman sayısı tek ise
            medyan = sayilar[sayilar.Count / 2];
        else // Eleman sayısı çift ise
            medyan = (sayilar[(sayilar.Count / 2) - 1] + sayilar[sayilar.Count / 2]) / 2.0;

        // Sonuçları ekrana yazdırma
        Console.WriteLine($"Ortalama: {ortalama}");
        Console.WriteLine($"Medyan: {medyan}");
    }
}
