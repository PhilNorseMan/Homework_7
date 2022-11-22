/*Задача 50. Напишите программу, которая на вход принимает значение элемента в двумерном массиве,
и возвращает позицию этого элемента или же указание, что такого элемента нет.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
17 -> такого числа в массиве нет*/

void PrintMatrix(int[,] matr) // Принтер матрицы
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

void PrintIndexOf(int[,] matr) // Принтер результата с индексами (,)
{
    int count_x = matr.GetLength(0);
    int count_y = matr.GetLength(1);
    
    for (int i = 0; i < count_x; i++)
    {
        for (int j = 0; j < count_y; j++)
        {
             Console.Write(matr[i,j]);
            
            if (j != count_y - 1)
                Console.Write(",");
        }
        Console.WriteLine();
    }
}

void FillMatrix(int[,] matr) // Рандомайзер
{
    for (int i = 0; i < matr.GetLength(0); i++)
    {
        for (int j = 0; j < matr.GetLength(1); j++)
        {
            matr[i, j] = new Random().Next(1, 10);
        }
    }
}

int CountOfFind(int[,] matr, int find) // Подсчет кол-ва искомых значений в матрице
{
    int count = 0;
    for (int i = 0; i < matr.GetLength(0); i++)
    {
        for (int j = 0; j < matr.GetLength(1); j++)
        {
            if (matr[i,j] == find)
            {
                count++;
            }
        }
        
    }
    return count;
}

int[,] FindInMatrix(int[,] matr, int find)  // Поиск индексов искомых значений в контейнер
{
    int[,] positions = new int[CountOfFind(matr, find), 2];
    int positionString = 0;
    int positionColumn = 0;
    for (int i = 0; i < matr.GetLength(0); i++)
    {
        for (int j = 0; j < matr.GetLength(1); j++)
        {
            if (matr[i, j] == find)
            {
                positions[positionString, positionColumn] = i;
                positionColumn++;
                positions[positionString, positionColumn] = j;
                positionString++;
                positionColumn = positionColumn - 1;
            }
        }
        
    }
    return positions;
}


Console.WriteLine();
Console.WriteLine("First program will generate random matrix, using your information."); //Стартовое сообщение
Console.WriteLine();

InputNumber1: // Ввод размера матрицы 1

Console.WriteLine("Please, set the first dimension size of matrix:");
int firstDimension = int.Parse(Console.ReadLine()!);

if(firstDimension < 1) 
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"ERROR: Incorrect input! (The dimension size of matrix cannot be less than 1)");
        Console.ResetColor();
        goto InputNumber1;
    }

InputNumber2: // Ввод размера матрицы 2

Console.WriteLine("Please, set the second dimension size of matrix:");
int secondDimension = int.Parse(Console.ReadLine()!);

if(secondDimension < 1) 
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"ERROR: Incorrect input! (The dimension size of matrix cannot be less than 1)");
        Console.ResetColor();
        goto InputNumber2;
    }

Console.WriteLine();

int[,] matrix = new int[firstDimension, secondDimension]; // Инициализация матрицы

Console.WriteLine("Generated matrix is:");

FillMatrix(matrix); // Заполнение матрицы рандомом
PrintMatrix(matrix); // Вывод матрицы
Console.WriteLine();

Console.WriteLine("Now program will find nuber, that you enter, and show you it's position in matrix."); // Ввод числа для поиска
Console.WriteLine();

Console.WriteLine("Please, enter the number to find:");
int findNumber = int.Parse(Console.ReadLine()!);

int[,] result = FindInMatrix(matrix, findNumber); // Инициализация контейнера для индексов искомого элемента

Console.WriteLine();
if(CountOfFind(matrix, findNumber) == 0)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("There is no coincidence find!"); // Вывод, что ничего не найдено (если счетчик искомых элементов == 0) Выводится красным
    Console.ResetColor();
    Console.WriteLine();
}
else
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Position of the desired number is:"); // Вывод индексов искомого эл-та  Выводится зеленым
    PrintIndexOf(result);
    Console.ResetColor();
    Console.WriteLine();
}