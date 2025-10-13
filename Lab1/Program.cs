using System;
using System.IO;

class Program
{
    static void Main()
    {
        string inputPath = "numbers.txt";
        string outputPath = "result.txt";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Файл з вхідними даними не знайдено!");
            return;
        }

        string[] numbersText = File.ReadAllText(inputPath).Split(' ', StringSplitOptions.RemoveEmptyEntries);
        int[] numbers = Array.ConvertAll(numbersText, int.Parse);

        int max = numbers[0];
        foreach (int num in numbers)
            if (num > max)
                max = num;

        Console.WriteLine($"Максимальне число: {max}");
        File.WriteAllText(outputPath, $"Максимальне число: {max}");
    }
}