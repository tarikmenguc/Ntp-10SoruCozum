using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ntp10soruodev
{
    using System;
    using System.Collections.Generic;

    class Soru7
    {
        static void Main()
        {
            int M = 5; // Labirent boyutları (örneğin 5x5)
            int N = 5;

            if (BFS(M, N))
            {
                Console.WriteLine("Şehre ulaşıldı!");
            }
            else
            {
                Console.WriteLine("Şehir kayboldu!");
            }
        }

        // BFS Algoritması ile yol bulma
        static bool BFS(int M, int N)
        {
            bool[,] visited = new bool[M, N];
            Queue<(int x, int y, List<(int, int)> path)> queue = new Queue<(int, int, List<(int, int)>)>();
            queue.Enqueue((0, 0, new List<(int, int)> { (0, 0) })); // Başlangıç noktasını kuyrukta sıraya koy

            while (queue.Count > 0)
            {
                var (x, y, path) = queue.Dequeue();

                // Şehre ulaşıldı mı?
                if (x == M - 1 && y == N - 1)
                {
                    Console.WriteLine("Şehre ulaşmak için izlenecek yol:");
                    foreach (var step in path)
                    {
                        Console.WriteLine($"({step.Item1}, {step.Item2})");
                    }
                    return true;
                }

                // Ziyaret Edildi olarak işaretle
                visited[x, y] = true;

                // 4 Komşuyu kontrol et
                foreach (var (nx, ny) in new (int, int)[] { (x + 1, y), (x - 1, y), (x, y + 1), (x, y - 1) })
                {
                    if (nx >= 0 && nx < M && ny >= 0 && ny < N && !visited[nx, ny] && IsValidCell(nx, ny))
                    {
                        var newPath = new List<(int, int)>(path) { (nx, ny) };
                        queue.Enqueue((nx, ny, newPath));
                    }
                }
            }

            return false; // Şehre ulaşma başarısız
        }

        // Hücrenin geçerli olup olmadığını kontrol etme
        static bool IsValidCell(int x, int y)
        {
            return AreDigitsPrime(x) && AreDigitsPrime(y) && ((x + y) % (x * y) == 0);
        }

        // Basamakların asal olup olmadığını kontrol etme
        static bool AreDigitsPrime(int num)
        {
            foreach (char digit in num.ToString())
            {
                int d = digit - '0';
                if (!(d == 2 || d == 3 || d == 5 || d == 7)) // Sadece 2, 3, 5, 7 asal basamaklar
                    return false;
            }
            return true;
        }
    }

}
