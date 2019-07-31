using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharp_learning_console._1_3_finonachi
{
    class FibonachiI
    {
        public delegate void PrintIntMetod(int a);

        public static void PrintFibonachiRec(int a, int b, int N, PrintIntMetod Print)
        {
            int c = a + b;
            if(c<=N)
            {
                Print(c);
                PrintFibonachiRec(b, c, N, Print);
            }
        }
        public static void PrintFibonachiRec(int N, PrintIntMetod Print)
        {
            if (N >= 0)
            {
                Print(0);
            }
            if (N >= 1)
            {
                Print(1);
                PrintFibonachiRec(0, 1, N, Print);
            }            
        }
        public static void PrintFibonachiIter(int N, PrintIntMetod Print)
        {
            if (N >= 0)
            {
                Print(0);
            }
            if (N >= 1)
            {
                Print(1);
                int a = 0, b = 1, c = 1;
                while(c<=N)
                {
                    Print(c);
                    a = b;
                    b = c;
                    c = a + b;
                }
            }
            
        }

    }
}
