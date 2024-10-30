using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ntp10soruodev
{
    using System;
    using System.Collections.Generic;

    class Soru8
    {
        static void Main()
        {
            string encryptedMessage = "şifreli mesaj"; // Şifrelenmiş mesajı burada girin
            string decryptedMessage = DecryptMessage(encryptedMessage);
            Console.WriteLine($"Çözülmüş Mesaj: {decryptedMessage}");
        }

        // Mesajı çözmek için ana fonksiyon
        static string DecryptMessage(string encryptedMessage)
        {
            List<int> fibonacciSeries = GenerateFibonacciSeries(encryptedMessage.Length);
            List<int> primePositions = GeneratePrimePositions(encryptedMessage.Length);

            char[] decryptedChars = new char[encryptedMessage.Length];

            for (int i = 0; i < encryptedMessage.Length; i++)
            {
                int encryptedValue = (int)encryptedMessage[i];
                int fibValue = fibonacciSeries[i];
                int decryptedValue;

                // Mod işlevini tersine çevir
                if (primePositions.Contains(i + 1)) // Asal pozisyon
                {
                    decryptedValue = encryptedValue;
                    while (decryptedValue < 100) decryptedValue += 100;
                }
                else // Asal olmayan pozisyon
                {
                    decryptedValue = encryptedValue;
                    while (decryptedValue < 256) decryptedValue += 256;
                }

                // Fibonacci etkisini kaldırmak için böl
                decryptedValue /= fibValue;

                // ASCII karakterini geri dönüştür
                decryptedChars[i] = (char)decryptedValue;
            }

            return new string(decryptedChars);
        }

        // Fibonacci serisi oluşturucu
        static List<int> GenerateFibonacciSeries(int length)
        {
            List<int> fibonacci = new List<int> { 1, 1 };
            for (int i = 2; i < length; i++)
            {
                fibonacci.Add(fibonacci[i - 1] + fibonacci[i - 2]);
            }
            return fibonacci;
        }

        // Pozisyonların asal olup olmadığını belirleme
        static List<int> GeneratePrimePositions(int length)
        {
            List<int> primes = new List<int>();
            for (int i = 1; i <= length; i++)
            {
                if (IsPrime(i))
                {
                    primes.Add(i);
                }
            }
            return primes;
        }

        // Asallık kontrolü
        static bool IsPrime(int num)
        {
            if (num <= 1) return false;
            if (num == 2 || num == 3) return true;
            if (num % 2 == 0 || num % 3 == 0) return false;

            for (int i = 5; i * i <= num; i += 6)
            {
                if (num % i == 0 || num % (i + 2) == 0) return false;
            }
            return true;
        }
    }

}
