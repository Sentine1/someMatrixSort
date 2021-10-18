using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace someMatrixSort.basic
{
    class PrintMatrix
    {
        public static void Print(double[][]   input)
        {
            var n = input.Length;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (j + 1 != n) 
                        Console.Write(input[i][j]+ "\t");
                    else Console.WriteLine(input[i][j]+"\n");
                }              
            }
        }
    }
}
