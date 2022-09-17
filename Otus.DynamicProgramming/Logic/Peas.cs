using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Otus.DynamicProgramming.Logic
{
    //Раз/два горох
    //https://www.robotsharp.info/index.php?page=TaskInfo&taskId=3704
    // Наибольший общий делитель
    public class Peas
    {
        //public static void Main()
        //{
        //    var line = Console.ReadLine().Split('+', '/');
        //    var firstNumerator = Convert.ToInt16(line[0]);
        //    var firstDenominator = Convert.ToInt16(line[1]);
        //    var secondNumerator = Convert.ToInt16(line[2]);
        //    var secondDenominator = Convert.ToInt16(line[3]);
            
        //    var first = firstNumerator * secondDenominator + firstDenominator * secondNumerator;
        //    var second = firstDenominator * secondDenominator;
            
        //    var nod = NOD(first, second);

        //    first = first / nod;
        //    second = second / nod;

        //    //Console.WriteLine($"{first} / {second}");
        //    Console.WriteLine(first + "/" + second);
        //}

        public static int NOD(int first, int second)
        {
            if (first == second) return first;
            if (first == 0) return second;
            if (second == 0) return first;

            if (IsEven(first) && IsEven(second)) 
                return NOD(first / 2, second / 2) * 2;

            if (IsEven(first) && IsOdd(second))
                return NOD(first / 2, second);

            if (IsOdd(first) && IsEven(second))
                return NOD(first, second / 2);

            return first > second 
                ? NOD((first - second) / 2, second) 
                : NOD(first, (second - first) / 2);
        }

        
        #region Support Methods

        private static bool IsEven(int number)
        {
            return number % 2 == 0;
        }

        private static bool IsOdd(int number)
        {
            return !IsEven(number);
        }

        #endregion
    }
}
