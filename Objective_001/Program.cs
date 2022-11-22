/*Задача 47. Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.
m = 3, n = 4.
0,5 7 -2 -0,2
1 -3,3 8 -9,9
8 7,8 -7,1 9
*/

void FillMatrix(double[,] matr)
{
    for (int i = 0; i < matr.GetLength(0); i++)
    {
        for (int j = 0; j < matr.GetLength(1); j++)
        {
            Random x = new Random();
            matr[i, j] = Convert.ToDouble(x.Next(-100, 100)/10.0);
        }
    }
}

void PrintMatrix(double[,] matr)
{
    int count_x = matr.GetLength(0);
    int count_y = matr.GetLength(1);
    
    for (int i = 0; i < count_x; i++)
    {
        for (int j = 0; j < count_y; j++)
            Console.Write(matr[i, j] + "    ");
        Console.WriteLine();
    }
}

Console.WriteLine();
Console.WriteLine("The program will generate random two-dimensional array, using your information.");
Console.WriteLine();

Console.WriteLine("Please, set the first dimension size of array:");
int firstDimension = int.Parse(Console.ReadLine()!);

Console.WriteLine("Please, set the second dimension size of array:");
int secondDimension = int.Parse(Console.ReadLine()!);
Console.WriteLine();

double[,] matrix = new double[firstDimension, secondDimension];

Console.WriteLine("Generated array is:");

FillMatrix(matrix);
PrintMatrix(matrix);
Console.WriteLine();