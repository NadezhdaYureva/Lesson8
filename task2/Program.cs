// Задайте прямоугольный двумерный массив. 
// Напишите программу, которая будет находить строку с наименьшей суммой элементов.

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

int SumOfRow(int[,] matrix, int row)
{
    int sum = 0;
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        sum = sum + matrix[row, j];
    }
    return sum;
}

int[] MinimumSumRow(int[,] matrix)
{
    int[] RowNumberAndSum = new int[2];
    RowNumberAndSum[1] = SumOfRow(matrix, RowNumberAndSum[0]);
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        if (RowNumberAndSum[1] > SumOfRow(matrix, i))
        {
            RowNumberAndSum[0] = i;
            RowNumberAndSum[1] = SumOfRow(matrix, RowNumberAndSum[0]);
        }
    }
    return RowNumberAndSum;
}

void Solve()
{
    int n = 5;
    int m = 3;
    int min = 0;
    int max = 10;
    int[,] newMatrix = CreateRandomMatrix(n, m, min, max);
    PrintArray(newMatrix);
    System.Console.WriteLine();
    Console.WriteLine($"Номер строки с наименьшей суммой элементов {MinimumSumRow(newMatrix)[0] + 1}. Сумма элементов в этой строке равна {MinimumSumRow(newMatrix)[1]}");
}

Solve();
