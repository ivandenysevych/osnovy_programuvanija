using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8; // Щоб українська коректно відображалась
        string root = Directory.GetCurrentDirectory();
        Console.WriteLine($"Поточна директорія: {root}\n");

        // === Базовий рівень ===
        Console.WriteLine("=== Базовий рівень ===");

        string infoPath = Path.Combine(root, "info.txt");
        if (!File.Exists(infoPath))
        {
            File.Create(infoPath).Close();
            Console.WriteLine("Файл info.txt створено!");
        }
        else
        {
            Console.WriteLine("Файл info.txt вже існує!");
        }

        string dataDir = Path.Combine(root, "Data");
        if (!Directory.Exists(dataDir))
        {
            Directory.CreateDirectory(dataDir);
            Console.WriteLine("Каталог Data створено!");
        }
        else
        {
            Console.WriteLine("Каталог Data вже існує!");
        }

        // Видалення файлу info.txt
        if (File.Exists(infoPath))
        {
            File.Delete(infoPath);
            Console.WriteLine("Файл info.txt видалено!");
        }

        // Видалення каталогу Data
        if (Directory.Exists(dataDir))
        {
            Directory.Delete(dataDir, true);
            Console.WriteLine("Каталог Data видалено разом із вмістом!");
        }

        // Створення numbers.txt і запис чисел 1..10
        using (StreamWriter writer = new StreamWriter("numbers.txt"))
        {
            for (int i = 1; i <= 10; i++)
                writer.WriteLine(i);
        }
        Console.WriteLine("Числа 1–10 записані у файл numbers.txt!\n");


        // === Середній рівень ===
        Console.WriteLine("=== Середній рівень ===");

        string digitsPath = "digits.txt";
        if (File.Exists("numbers.txt"))
        {
            File.Move("numbers.txt", digitsPath, true);
            Console.WriteLine("Файл перейменовано на digits.txt!");
        }

        string backupDir = Path.Combine(root, "Backup");
        if (!Directory.Exists(backupDir))
        {
            Directory.CreateDirectory(backupDir);
            Console.WriteLine("Каталог Backup створено!");
        }

        string backupFile = Path.Combine(backupDir, "digits.txt");
        File.Move(digitsPath, backupFile, true);
        Console.WriteLine("Файл переміщено у каталог Backup!");

        string copyDir = Path.Combine(root, "CopyData");
        Directory.CreateDirectory(copyDir);
        string copyFile = Path.Combine(copyDir, "digits.txt");
        File.Copy(backupFile, copyFile, true);
        Console.WriteLine("Файл скопійовано у каталог CopyData!\n");


        // === Підвищений рівень ===
        Console.WriteLine("=== Підвищений рівень ===");

        Console.Write("Введіть шлях до файлу для перегляду інформації: ");
        string filePath = Console.ReadLine();

        if (File.Exists(filePath))
        {
            FileInfo fi = new FileInfo(filePath);
            Console.WriteLine($"Ім'я файлу: {fi.Name}");
            Console.WriteLine($"Розмір: {fi.Length} байт");
            Console.WriteLine($"Дата створення: {fi.CreationTime}");
            Console.WriteLine($"Останній доступ: {fi.LastAccessTime}");
        }
        else
        {
            Console.WriteLine("Файл не існує!");
        }

        Console.WriteLine("\n=== Рекурсивне копіювання ===");
        Console.Write("Введіть шлях вихідного каталогу: ");
        string srcDir = Console.ReadLine();
        Console.Write("Введіть шлях каталогу призначення: ");
        string dstDir = Console.ReadLine();

        if (Directory.Exists(srcDir))
        {
            CopyDirectory(srcDir, dstDir);
            Console.WriteLine("Каталог успішно скопійовано рекурсивно!");
        }
        else
        {
            Console.WriteLine("Вихідний каталог не існує!");
        }
    }

    static void CopyDirectory(string sourceDir, string destDir)
    {
        Directory.CreateDirectory(destDir);
        foreach (string file in Directory.GetFiles(sourceDir))
        {
            string fileName = Path.GetFileName(file);
            string destFile = Path.Combine(destDir, fileName);
            File.Copy(file, destFile, true);
        }
        foreach (string subDir in Directory.GetDirectories(sourceDir))
        {
            string dirName = Path.GetFileName(subDir);
            string destSubDir = Path.Combine(destDir, dirName);
            CopyDirectory(subDir, destSubDir);
        }
    }
}
