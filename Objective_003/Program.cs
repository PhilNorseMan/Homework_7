/*Задача 52. Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
Среднее арифметическое каждого столбца: 4,6; 5,6; 3,6; 3.
*/

void PrintMatrix(int[,] arr)
{
    int count_x = arr.GetLength(0);
    int count_y = arr.GetLength(1);
    
    for (int i = 0; i < count_x; i++)
    {
        for (int j = 0; j < count_y; j++)
            Console.Write(arr[i, j] + "    ");
        Console.WriteLine();
    }
}

void PrintArray(double[] arr)
{  
    for (int i = 0; i < arr.Length; i++)
    {
        Console.Write(arr[i]);

        if (i != arr.Length - 1)
            Console.Write("; ");
    }

}

void FillArray(int[,] matr)
{
    for (int i = 0; i < matr.GetLength(0); i++)
    {
        for (int j = 0; j < matr.GetLength(1); j++)
        {
            matr[i, j] = new Random().Next(1, 10);
        }
    }
}

double[] AverageColumns(int[,] arr)
{
    int count_x = arr.GetLength(0);
    int count_y = arr.GetLength(1);
    double[] result = new double[count_y];
    double temp = 0;
    int position = 0;
    
    for (int j = 0; j < count_y; j++)
    {
        for (int i = 0; i < count_x; i++)
        {
            temp += arr[i,j];
        }
        result[position] = Math.Round( temp / count_x, 2, MidpointRounding.AwayFromZero);
        position++;
    }
    return result;
}

Console.WriteLine();
Console.WriteLine("The program will generate random two-dimensional array, using your information.");
Console.WriteLine();

Console.WriteLine("Please, set the first dimension size of array:");
int firstDimension = int.Parse(Console.ReadLine()!);

Console.WriteLine("Please, set the second dimension size of array:");
int secondDimension = int.Parse(Console.ReadLine()!);
Console.WriteLine();

int[,] matrix = new int[firstDimension, secondDimension];

Console.WriteLine("Generated array is:");

FillArray(matrix);
PrintMatrix(matrix);
Console.WriteLine();


Console.WriteLine("Arithmetical mean for each column is:");
double[] result = AverageColumns(matrix);
PrintArray(result);