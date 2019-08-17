using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sharp_learning_console._1_2_PrimeNumbers;
using sharp_learning_console._1_3_finonachi;
using sharp_learning_console._1_1_Diary;

namespace sharp_learning_console
{
    class Program
    {
        static void Main(string[] args)
        {

            //_1_3_finonachi.FibonachiI.PrintFibonachiIter(1000, delegate(int a)
            // {
            //     Console.Write($"{a} ");
            // });
            //Console.WriteLine();
            //_1_3_finonachi.FibonachiI.PrintFibonachiRec(1000, delegate (int a)
            //{
            //    Console.Write($"{a} ");
            //});

            //_1_2_PrimeNumbers.PrimeNumbers.PrintPrimeNumbers(1000, delegate (int a)
            //{
            //     Console.Write($"{a} ");
            //});


            //calc 321 + (23*4)-7*(3+(78-3/2)/4)

            //string expStr = Console.ReadLine();
            //try
            //{
            //    CalculatorLib.Expression exp = new CalculatorLib.Expression(expStr);
            //    exp.ConsolePrint();
            //    Console.WriteLine();
            //    exp.ConsolePrintRPN();
            //    Console.WriteLine();
            //    Console.WriteLine(exp.SolveDouble());
            //    Console.WriteLine(exp.SolveInt());
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}


            //diary
            //Diary.ShawNotesListConsole();
            //Diary.ShawNote(DateTime.Now);
            //DateTime d = DateTime.Now;
            //d = d.AddDays(-10);
            //Diary.ShawNote(d);
            Console.ReadKey();


        }
    }
}
