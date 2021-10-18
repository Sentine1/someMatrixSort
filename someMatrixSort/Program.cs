using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using someMatrixSort.basic;

namespace someMatrixSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int row = 8;
            int columns;
            var start = new CreateNewRandomMatrix();

            (var matrix, var freeMembers) = start.CreateRandomSystemWithLinearlyDependentRows(row, true);

            PrintMatrix.Print(matrix);

             // make some magick for GaussianAlgoritm (clear for push)

            Console.WriteLine("\n\n\n");
            PrintMatrix.Print(matrix);
            Console.ReadKey();
        }
    }
}
