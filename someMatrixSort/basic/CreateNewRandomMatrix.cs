using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace someMatrixSort.basic
{
    class CreateNewRandomMatrix
    {
        Random random = new Random();
        public (double[][] matrix, double[] freeMembers) CreateRandomSystemWithLinearlyDependentRows(int matrixSize, bool isSolvable)
        {

            var matrix = CreateRandomMatrix(matrixSize, matrixSize);
            var freeMembers = GetRandomFreeMembers(matrix);
            
            return (matrix, freeMembers);
        }
        private double[] GetRandomFreeMembers(double[][] matrix)
        {
            const int max = 100;
            var xs = Enumerable.Range(0, matrix[0].Length).Select(c => random.Next(-max, max));
            var freeMembers = matrix.Select(row => row.Zip(xs, (f, s) => f * s).Sum()).ToArray();
            return freeMembers;
        }

        private double[][] CreateRandomMatrix(int rows, int columns, int valuesRange = 1000)
        {
            return Enumerable.Range(0, rows).Select(r => CreateRandomRow(columns, valuesRange)).ToArray();
        }
        private double[] CreateRandomRow(int columns, int maxValue)
        {
            double[] row;
            do
            {
                row = Enumerable.Range(0, columns).Select(c => (double)random.Next(-maxValue, maxValue)).ToArray();
            } while (row.All(x => Math.Abs(x) < 1e-3));
            return row;
        }        
    }
}
