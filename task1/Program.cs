// Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.

int[,] CreateRandomMatrix(int row, int column, int min, int max)
{
    var rnd = new Random();
    int[,] newMatrix = new int[row, column];
    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < column; j++)
        {
            newMatrix[i, j] = rnd.Next(min, max + 1);
        }
    }
    return newMatrix;
}

void PrintArray(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i, j]}" + "\t");
        }
        Console.WriteLine();
    }
}

void DecreasingOrder(int[,] matrix)
{
    int j = 0;
    int k = 0;
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (j = 0; j < matrix.GetLength(1); j++)
        {
            int max = j;
            for (k = j; k < matrix.GetLength(1); k++)
            {
                if (matrix[i, max] < matrix[i, k])
                {
                    max = k;
                }
            }
            var temp = matrix[i, max];
            matrix[i, max] = matrix[i, j];
            matrix[i, j] = temp;
        }
    }
}


void Solve()
{
    int n = 5;
    int m = 5;
    int min = 0;
    int max = 10;
    int[,] newMatrix = CreateRandomMatrix(n, m, min, max);
    PrintArray(newMatrix);
    System.Console.WriteLine();
    DecreasingOrder(newMatrix);
    PrintArray(newMatrix);
}

Solve();
