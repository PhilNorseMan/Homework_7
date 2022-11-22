/*задача 2 HARD необязательная. Считается за четыре обязательных ) то есть три этих и одна с будущего семинара
Сгенерировать массив случайных целых чисел размерностью m*n (размерность вводим с клавиатуры) , причем чтоб количество элементов было четное. 
Вывести на экран красивенько таблицей. Перемешать случайным образом элементы массива, 
причем чтобы каждый ГАРАНТИРОВАННО переместился на другое место и выполнить это за m*n / 2 итераций. 
И после этого чтоб каждый уже перемещенный элемент не трогали.
То есть если массив три на четыре, то надо выполнить не более 6 итераций. 
И далее в конце опять вывести на экран как таблицу.*/


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
            matr[i, j] = new Random().Next(1, 10);
        }
    }
}

int[,] CreationOfMatrix(int x, int y)
{
    if (x % 2 > 0 && y % 2 > 0)
    {
        y++;

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("!For correct number of elemets second dimension was corrected by + 1!");
        Console.ResetColor();
        Console.WriteLine();
    }

    int[,] result = new int[x, y];

    return result;

}

// ФУНКЦИИ ДЛЯ ПЕРЕМЕШИВАНИЯ МАТРИЦЫ
void FillMatrixZero(int[,] matr) // Заполнение матрицы контрольными значениями
{
    for (int i = 0; i < matr.GetLength(0); i++)
    {
        for (int j = 0; j < matr.GetLength(1); j++)
        {
            matr[i, j] = int.MinValue;
        }
    }
}

// ФУНКЦИЯ ПЕРЕМЕШИВАНИЯ
int[,] RandomMixedMatrix(int[,] matr)
{
    int side1 = matr.GetLength(0);
    int side2 = matr.GetLength(1);
    int[,] resultMatrix = new int[side1, side2]; // инициализация конечной матрицы
    FillMatrixZero(resultMatrix); // заполнение конечной матрицы контрольными значениями
    int controlValue = int.MinValue; // объявление контрольного значения для сверки использования позиции

    int step = 0; //счетчик итераций
    int stepsLimit = side1 * side2 / 2; // определение половины кол-ва эл-тов для ограничения итераций

    while (step < stepsLimit)  // счетчик итераций до половины размера матрицы
    {

        InputValue: // определение первого элемента для перестановки
        int position_xA = new Random().Next(0, side1); // рандом позиции по х для первого элемента
        int position_yA = new Random().Next(0, side2); // рандом позиции по у для первого элемента

        int position_xB = new Random().Next(0, side1); // рандом позиции по х для второго элемента
        int position_yB = new Random().Next(0, side2); // рандом позиции по у для второго элемента

        if (position_xA == position_xB && position_yA == position_yB) 
            goto InputValue; // проверка на совпадение позиций. Если совпали - возврат к рандому позции.
        
        if (resultMatrix[position_xA, position_yA] != controlValue || resultMatrix[position_xB, position_yB] != controlValue) 
            goto InputValue; // проверка на пустоту позиции. Если не пустое - возврат к рандому позции.
        
        resultMatrix[position_xA, position_yA] = matr[position_xB, position_yB];
        resultMatrix[position_xB, position_yB] = matr[position_xA, position_yA];
        step++;
    }

    return resultMatrix;
}


//ПРОГРАММА
Console.WriteLine();
Console.WriteLine("First program will generate random matrix, using your information."); //Стартовое сообщение
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("At least one of entered numbers must be even");
Console.ResetColor();
Console.WriteLine();

InputNumber1: // Ввод размера матрицы 1

Console.WriteLine("Please, set the first dimension size of matrix:");
int firstDimension = int.Parse(Console.ReadLine()!);

if (firstDimension < 1)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"ERROR: Incorrect input! (The dimension size of matrix cannot be less than 1)");
    Console.ResetColor();
    goto InputNumber1;
}

InputNumber2: // Ввод размера матрицы 2

Console.WriteLine("Please, set the second dimension size of matrix:");
int secondDimension = int.Parse(Console.ReadLine()!);

if (secondDimension < 1)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"ERROR: Incorrect input! (The dimension size of matrix cannot be less than 1)");
    Console.ResetColor();
    goto InputNumber2;
}

int[,] matrix = CreationOfMatrix(firstDimension, secondDimension); // Инициализация матрицы

Console.WriteLine("Generated matrix is:");

FillMatrix(matrix); // Заполнение матрицы рандомом
PrintMatrix(matrix); // Вывод матрицы
Console.WriteLine();

Console.WriteLine("Mixed matrix is:");
int[,] mixedMatrix = RandomMixedMatrix(matrix);
PrintMatrix(mixedMatrix); // Вывод новой матрицы
Console.WriteLine();
