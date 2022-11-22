/*Задача HARD SORT необязательная. Считается за три обязательных
Задайте двумерный массив из целых чисел. Количество строк и столбцов задается с клавиатуры.
Отсортировать элементы по возрастанию слева направо и сверху вниз.
Например, задан массив:
1 4 7 2
5 9 10 3
После сортировки
1 2 3 4
5 7 9 10
*/

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

void FillMatrix(int[,] matr) // Рандомайзер
{
    for (int i = 0; i < matr.GetLength(0); i++)
    {
        for (int j = 0; j < matr.GetLength(1); j++)
        {
            matr[i, j] = new Random().Next(0, 10);
        }
    }
}

int[,] MatrixSortingUp(int[,] original) //Сортировщик
{
    int originalCount_x = original.GetLength(0); // Размеры матрицы
    int originalCount_y = original.GetLength(1);

    int[] tempArray = new int[originalCount_x * originalCount_y]; // Ввод временного одномерного массива для складывания туда всех эл-тов матрицы (размер х*у)
    int tempIndex = 0;

    for (int i = 0; i < originalCount_x; i++)  // Заполняем временный одномерный массив пошагово
    {
        for (int j = 0; j < originalCount_y; j++)
        {
            tempArray[tempIndex] = original[i,j];
            tempIndex++;
        }
    }

    Array.Sort(tempArray); // Сортируем одномерный массив по возрастанию

    int[,] result = new int[originalCount_x, originalCount_y]; // Вводим новый массив для отображения

    tempIndex = 0; // Обнуляем для новой пробежки

    for (int i = 0; i < originalCount_x; i++) // Крутим новый массив пошагово заполняя сортированным одномерным массивом
    {
        for (int j = 0; j < originalCount_y; j++)
        {
            result[i,j] = tempArray[tempIndex];
            tempIndex++;
        }
    }

    return result;
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

Console.WriteLine("Sorted up matrix is:"); 

int[,] result = MatrixSortingUp(matrix); //Инициализация нового массива с сортировкой
PrintMatrix(result); // Вывод матрицы
Console.WriteLine();