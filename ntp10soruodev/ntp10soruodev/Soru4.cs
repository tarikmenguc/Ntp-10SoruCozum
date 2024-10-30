using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ntp10soruodev
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    class Soru4
    {
        static void Main()
        {
            Console.WriteLine("Polinom hesaplayıcıya hoş geldiniz! Çıkmak için 'exit' yazın.");

            while (true)
            {
                Console.WriteLine("\nBirinci polinomu girin (örn. 2x^2 + 3x - 5):");
                string polinom1 = Console.ReadLine();
                if (polinom1.ToLower() == "exit") break;

                Console.WriteLine("İkinci polinomu girin (örn. x^2 - 4):");
                string polinom2 = Console.ReadLine();
                if (polinom2.ToLower() == "exit") break;

                var poly1 = ParsePolinom(polinom1);
                var poly2 = ParsePolinom(polinom2);

                var toplam = ToplaPolinomlar(poly1, poly2);
                var fark = CikarPolinomlar(poly1, poly2);

                Console.WriteLine("\nToplam: " + PolinomToString(toplam));
                Console.WriteLine("Fark: " + PolinomToString(fark));
            }
        }

        // Polinomu sözlük formatında ayrıştırma (katsayı ve derece)
        static Dictionary<int, int> ParsePolinom(string polinom)
        {
            Dictionary<int, int> poly = new Dictionary<int, int>();
            string pattern = @"([+-]?\s*\d*)x\^(\d+)|([+-]?\s*\d*)x|([+-]?\s*\d+)";

            foreach (Match match in Regex.Matches(polinom.Replace(" ", ""), pattern))
            {
                int katsayi = 1;
                int derece = 0;

                if (match.Groups[1].Success) // x^n formatında terim
                {
                    katsayi = int.Parse(match.Groups[1].Value.Replace("+", ""));
                    derece = int.Parse(match.Groups[2].Value);
                }
                else if (match.Groups[3].Success) // x formatında terim
                {
                    katsayi = int.Parse(match.Groups[3].Value.Replace("+", ""));
                    derece = 1;
                }
                else if (match.Groups[4].Success) // sabit terim
                {
                    katsayi = int.Parse(match.Groups[4].Value.Replace("+", ""));
                }

                if (poly.ContainsKey(derece))
                    poly[derece] += katsayi;
                else
                    poly[derece] = katsayi;
            }

            return poly;
        }

        // Polinomları toplama
        static Dictionary<int, int> ToplaPolinomlar(Dictionary<int, int> poly1, Dictionary<int, int> poly2)
        {
            Dictionary<int, int> result = new Dictionary<int, int>(poly1);

            foreach (var term in poly2)
            {
                if (result.ContainsKey(term.Key))
                    result[term.Key] += term.Value;
                else
                    result[term.Key] = term.Value;
            }

            return result;
        }

        // Polinomları çıkarma
        static Dictionary<int, int> CikarPolinomlar(Dictionary<int, int> poly1, Dictionary<int, int> poly2)
        {
            Dictionary<int, int> result = new Dictionary<int, int>(poly1);

            foreach (var term in poly2)
            {
                if (result.ContainsKey(term.Key))
                    result[term.Key] -= term.Value;
                else
                    result[term.Key] = -term.Value;
            }

            return result;
        }

        // Polinomu string olarak formatlama
        static string PolinomToString(Dictionary<int, int> poly)
        {
            List<string> terms = new List<string>();

            foreach (var term in poly)
            {
                int katsayi = term.Value;
                int derece = term.Key;

                if (katsayi == 0) continue;

                string termStr = katsayi > 0 && terms.Count > 0 ? $"+{katsayi}" : katsayi.ToString();

                if (derece == 1)
                    termStr += "x";
                else if (derece > 1)
                    termStr += $"x^{derece}";

                terms.Add(termStr);
            }

            return terms.Count > 0 ? string.Join(" ", terms) : "0";
        }
    }

}
