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
        public int row = 6;
        public int columns = 6;
        public double[][] matrix;
        public double[] answer;
        public static void Main(string[] args)
        {
            var element = new Program();
            var start = new CreateNewRandomMatrix();
            (var matrix, var freeMembers) = start.CreateRandomSystemWithLinearlyDependentRows(element.row, false);
            element.matrix = matrix;
            element.answer = freeMembers;
            PrintMatrix.Print(matrix, freeMembers);

            for (int i = 0; i < element.row - 1; i++)
            {
                element.SortRows(i);
                for (int j = i + 1; j < element.row; j++)
                {
                    if (matrix[i][i] != 0) //если главный элемент не 0, то производим вычисления
                    {
                        double MultElement = matrix[j][i] / matrix[i][i];
                        for (int k = i; k < element.columns; k++)
                            matrix[j][k] -= matrix[i][k] * MultElement;
                        freeMembers[j] -= freeMembers[i] * MultElement;
                    }                    
                }
            }
            //Обратный ход (Зануление верхнего правого угла)
            for (int k = element.row - 1; k > -1; k--)
            {
                for (int i = k - 1; i > -1; i--)
                {
                    double K = matrix[i][k] / matrix[k][k];                   
                    matrix[i][k] = matrix[i][k] - matrix[k][k] * K;
                    freeMembers[i] -= matrix[k][k] * K;                    
                }
            }

            for (int i =element.row - 1; i >= 0; i--)
            {
                element.answer[i] = freeMembers[i];

                for (int j = element.row - 1; j > i; j--)
                    element.answer[i] -= matrix[i][j] * element.answer[j];

                if (matrix[i][i] == 0)
                    if (freeMembers[i] == 0)
                        throw new Exception(" 2; //множество решений");
                    else
                        throw new Exception(" 1; //нет решения");

                element.answer[i] /= matrix[i][i];
            }

        Console.WriteLine("\n\n\n");
            PrintMatrix.Print(matrix,freeMembers);
            Console.ReadKey();

        }
        private void SortRows(int SortIndex)
        {

            double MaxElement = matrix[SortIndex][SortIndex];
            int MaxElementIndex = SortIndex;
            for (int i = SortIndex + 1; i < row; i++)
            {
                if (matrix[i][SortIndex] > MaxElement)
                {
                    MaxElement = matrix[i][SortIndex];
                    MaxElementIndex = i;
                }
            }

            //теперь найден максимальный элемент ставим его на верхнее место
            if (MaxElementIndex > SortIndex)//если это не первый элемент
            {
                double Temp;

                Temp = answer[MaxElementIndex];
                answer[MaxElementIndex] = answer[SortIndex];
                answer[SortIndex] = Temp;

                for (int i = 0; i < columns; i++)
                {
                    Temp = matrix[MaxElementIndex][i];
                    matrix[MaxElementIndex][i] = matrix[SortIndex][i];
                    matrix[SortIndex][i] = Temp;
                }
            }
        }
    }
}
