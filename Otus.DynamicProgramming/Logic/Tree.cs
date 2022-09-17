using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Otus.DynamicProgramming.Logic
{
    //Цифровая ёлочка +1 байт
    //https://www.robotsharp.info/index.php?page=TaskInfo&taskId=3707
    // Наибольший общий делитель
    public class Tree
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var tree = new int[n, n];

            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j <= i; j++)
                {
                    tree[i, j] = int.Parse(Console.ReadLine());
                }
            }

            var result = Run(tree, n);

            Console.WriteLine(result);
        }

        public static int Run(int[,] tree, int n)
        {
            for (var i = n - 2; i >= 0; i--)
            {
                for (var j = 0; j <= i; j++)
                {
                    var upperLevel = i + 1;
                    tree[i, j] += Math.Max(tree[upperLevel, j], tree[upperLevel, j + 1]);
                }
            }

            return tree[0, 0];
        }
    }
}
