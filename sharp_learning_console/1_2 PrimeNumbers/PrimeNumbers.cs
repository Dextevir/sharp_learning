using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharp_learning_console._1_2_PrimeNumbers
{
    class PrimeNumbers
    {
        public delegate void PrintIntMetod(int a);
        public static void PrintPrimeNumbers(int N, PrintIntMetod Print)
        {
            List<int> Primes = GetPrimeNumbers(N);
            foreach(int k in Primes)
            {
                Print(k);
            }
        }
        public static List<int> GetPrimeNumbers(int N)
        {
            List<int> Primes = new List<int> { 2 };

            for (int i = 3; i <= N; i++)
            {
                bool prime = true;
                foreach (int k in Primes)
                {
                    if (i % k == 0)
                    {
                        prime = false;
                        break;
                    }
                }
                if (prime)
                {
                    Primes.Add(i);
                }
            }
            return Primes;
        }
    }
}
