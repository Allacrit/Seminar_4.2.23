Console.Clear();
Console.WriteLine("2. Написать программу, упорядочивания по убыванию элементы каждой строки двумерной массива.");

Console.Write("Введите число строк массива: ");
int n = int.Parse(Console.ReadLine());

Console.Write("Введите число столбцов массива: ");
int m = int.Parse(Console.ReadLine());

Console.Write("Введите минимальное число для заполнения массива: ");
int minRandom = int.Parse(Console.ReadLine());

Console.Write("Введите максимальное число для заполнения массива: ");
int maxRandom = int.Parse(Console.ReadLine());

int[,] newArray = CreateArray(n, m, minRandom, maxRandom);

Console.WriteLine($"Создан массив {n}x{m}:");
PrintArray(newArray);

Console.WriteLine($"Массив после сортировки чисел в строках:");

SortDescending2DArray(newArray);

PrintArray(newArray);


int[,] CreateArray(int line, int column, int min, int max)
{
    int[,] array = new int[line, column];
    for (int i = 0; i < array.GetLength(0); i++)
        for (int j = 0; j < array.GetLength(1); j++)
            array[i, j] = new Random().Next(min, max + 1);
    return array;
}

void PrintArray(int[,] array)
{
    int stringLength = FindMaxVarLengthInArr(array) + 1;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
            PrintVarToLength(array[i, j], stringLength);
        Console.WriteLine();
    }
    Console.WriteLine();
}

int FindMaxVarLengthInArr(int[,] array)
{
    int maxLen = array[0, 0].ToString().Length;
    for (int i = 0; i < array.GetLength(0); i++)
        for (int j = 0; j < array.GetLength(1); j++)
        {
            int curLen = array[i, j].ToString().Length;
            if (maxLen < curLen) maxLen = curLen;
        }
    return maxLen;
}

void PrintVarToLength(int var, int length)
{
    int spacesLength = length - var.ToString().Length;
    for (int i = 0; i < spacesLength; i++) Console.Write(" ");
    Console.Write(var);
}

int[,] SortDescending2DArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        int[] newArray = new int[array.GetLength(1)];
        for (int j = 0; j < array.GetLength(1); j++)
        { newArray[j] = array[i, j]; }
        newArray = SortDescendingArray(newArray);
        for (int j = 0; j < array.GetLength(1); j++)
        { array[i, j] = newArray[j]; }
    }
    return array;
}

int[] SortDescendingArray(int[] array)
{
    for (int i = 0; i < array.Length - 1; i++)
        for (int j = 0; j < array.Length - i - 1; j++)
        {
            if (array[j] > array[j + 1])
            {
                int temp = array[j];
                array[j] = array[j + 1];
                array[j + 1] = temp;
            }
        }
    return array;
}