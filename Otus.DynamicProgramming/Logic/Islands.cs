using System;
using System.Collections.Generic;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Otus.DynamicProgramming.Logic
{
    //Острова
    //https://www.robotsharp.info/index.php?page=TaskInfo&taskId=3708
    public class Islands
    {
        public static void Main()
        {
           var map = GetMap();

            var islandsCount = 0;
            for (var i = 0; i < map.GetUpperBound(0); i++)
            {
                for (var j = 0; j < map.GetUpperBound(0); j++)
                {
                    if (map[i, j] != 1) 
                        continue;

                    islandsCount++;
                    Walk(i, j, map);
                }
            }

            Console.WriteLine(islandsCount);
        }


        #region Support Methods

        private static int[,] GetMap()
        {
            var n = int.Parse(Console.ReadLine());
            var map = new int[n, n];

            for (var i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split(' ');
                for (var j = 0; j < n; j++)
                {
                    map[i, j] = int.Parse(line[j]);
                }
            }

            return map;
        }

        private static void Walk(int x, int y, int[,] map)
        {
            var n = map.GetUpperBound(0);

            if((x < 0 || x >= n) || (y < 0 || y >= n)) 
                return;
            if (map[x, y] == 0)
                return;

            map[x, y] = 0;

            Walk(x - 1, y, map);
            Walk(x + 1, y, map);
            Walk(x, y - 1, map);
            Walk(x, y + 1, map);
        }

        #endregion
    }
}
