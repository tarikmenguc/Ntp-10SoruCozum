using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ntp10soruodev
{
    using System;
    using System.Collections.Generic;

    class Soru6
    {
        static void Main()
        {
            int startYear = DateTime.Now.Year; // Şimdiki yıldan başlıyor
            int endYear = 3000; // Hedef yıl aralığı sonu
            var validDates = new List<string>();

            for (int year = startYear; year <= endYear; year++)
            {
                if (!IsYearValid(year)) continue;

                for (int month = 1; month <= 12; month++)
                {
                    if (!IsMonthValid(month)) continue;

                    for (int day = 2; day <= DateTime.DaysInMonth(year, month); day++) // Asal sayı günleri kontrol et
                    {
                        if (!IsPrime(day)) continue;

                        validDates.Add($"{day:00}/{month:00}/{year}");
                    }
                }
            }

            Console.WriteLine("Geçerli Tarihler:");
            foreach (var date in validDates)
            {
                Console.WriteLine(date);
            }
            Console.WriteLine($"\nToplam {validDates.Count} geçerli tarih bulundu.");
        }

        // Günün asal olup olmadığını kontrol eder
        static bool IsPrime(int number)
        {
            if (number < 2) return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }

        // Ayın basamaklarının toplamının çift olup olmadığını kontrol eder
        static bool IsMonthValid(int month)
        {
            int sumOfDigits = 0;
            while (month > 0)
            {
                sumOfDigits += month % 10;
                month /= 10;
            }
            return sumOfDigits % 2 == 0;
        }

        // Yılın rakamları toplamının, yılın dörtte birinden küçük olup olmadığını kontrol eder
        static bool IsYearValid(int year)
        {
            int sumOfDigits = 0;
            int originalYear = year;

            while (year > 0)
            {
                sumOfDigits += year % 10;
                year /= 10;
            }

            return sumOfDigits < (originalYear / 4);
        }
    }

}
