Console.Clear();
Console.WriteLine("3. В прямоугольной матрице найти строку с наименьшей суммой элементов.");

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

FindingMinimumSumArrayString(newArray);


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

void FindingMinimumSumArrayString(int[,] array)
{
    int index = 0, sum = 99999999;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        int[] tempArray = new int[array.GetLength(1)];
        for (int j = 0; j < array.GetLength(1); j++)
        { tempArray[j] = array[i, j]; }

        if (sum > SumArrayString(tempArray))
        {
            sum = SumArrayString(tempArray);
            index = i;
        }
    }
    Console.WriteLine($"Сумма строки №{index} является наименьшей в данном массиве и равна: {sum}.");
}

int SumArrayString(int[] array)
{
    int sum = 0;
    for (int i = 0; i < array.Length; i++)
    {
        sum += array[i];
    }
    return sum;
}