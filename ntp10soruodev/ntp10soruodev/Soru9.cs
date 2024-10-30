using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ntp10soruodev
{
    using System;

    class Soru9
    {
        static int MinEnergyPath(int[,] energyMatrix)
        {
            int n = energyMatrix.GetLength(0);
            int[,] dp = new int[n, n];

            // Başlangıç noktasındaki enerji maliyetini ayarla
            dp[0, 0] = energyMatrix[0, 0];

            // İlk satırı doldur
            for (int j = 1; j < n; j++)
            {
                dp[0, j] = dp[0, j - 1] + energyMatrix[0, j];
            }

            // İlk sütunu doldur
            for (int i = 1; i < n; i++)
            {
                dp[i, 0] = dp[i - 1, 0] + energyMatrix[i, 0];
            }

            // Geri kalan hücreleri doldur
            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    // Sağdan, alttan ve çaprazdan gelen minimum enerjiyi seç
                    dp[i, j] = energyMatrix[i, j] + Math.Min(dp[i - 1, j], Math.Min(dp[i, j - 1], dp[i - 1, j - 1]));
                }
            }

            // Hedef hücreye en az enerji ile ulaşma maliyeti
            return dp[n - 1, n - 1];
        }

        static void Main()
        {
            int[,] energyMatrix = {
            { 4, 7, 8, 6, 4 },
            { 6, 7, 3, 9, 2 },
            { 3, 8, 1, 2, 4 },
            { 7, 1, 7, 3, 7 },
            { 2, 9, 8, 9, 3 }
        };

            int minEnergy = MinEnergyPath(energyMatrix);
            Console.WriteLine("En az enerji ile hedefe ulaşma maliyeti: " + minEnergy);
        }
    }

}
