using System;
using System.IO;

struct Student
{
    public string Name;
    public string Group;
    public double Average;

    public Student(string name, string group, double average)
    {
        Name = name;
        Group = group;
        Average = average;
    }

    public void DisplayIfHigh()
    {
        if (Average > 90)
            Console.WriteLine($"{Name} ({Group}) — середній бал: {Average:F1}");
    }
}

struct Book
{
    public string Title;
    public string Author;
    public int Year;

    public Book(string title, string author, int year)
    {
        Title = title;
        Author = author;
        Year = year;
    }

    public void DisplayIfRecent()
    {
        if (Year > 2010)
            Console.WriteLine($"\"{Title}\" — {Author}, {Year} рік");
    }
}

struct Worker
{
    public string Name;
    public string Position;
    public int Experience;

    public Worker(string name, string position, int experience)
    {
        Name = name;
        Position = position;
        Experience = experience;
    }

    public void DisplayIfExperienced()
    {
        if (Experience > 10)
            Console.WriteLine($"{Name} — {Position}, стаж: {Experience} років");
    }
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("=== 1. Студенти з середнім балом > 90 ===");

        Student[] students = new Student[]
        {
            new Student("Форманюк Валерій", "КН-3/1", 96.7),
            new Student("Гарлінський Кирило", "КН-3/1", 85.3),
            new Student("Кириловець Крістіна", "КН-3/1", 88.9),
            new Student("Кузьмич Сергій", "КН-3/1", 74.2),
            new Student("Купець Олексій", "КН-3/1", 81.6),
            new Student("Орешко Руслан", "КН-3/1", 92.4),
            new Student("Чубок Богдан", "КН-3/1", 79.5),
            new Student("Соборайчук Віктор", "КН-3/1", 90.1),
            new Student("Балаян Станіслав", "КН-3/1", 86.8),
            new Student("Денисевич Іван", "КН-3/1", 94.0)
        };

        foreach (var s in students)
            s.DisplayIfHigh();

        Console.WriteLine("\n=== 2. Книги, видані після 2010 року ===");

        Book[] books = new Book[]
        {
            new Book("Чистий код", "Роберт Мартін", 2008),
            new Book("Програмування на C#", "Ендрю Троелсен", 2017),
            new Book("Алгоритми. Будова та аналіз", "Томас Кормен", 2013),
            new Book("Основи штучного інтелекту", "Сергій Литвиненко", 2022)
        };

        foreach (var b in books)
            b.DisplayIfRecent();

        Console.WriteLine("\n=== 3. Робітники зі стажем понад 10 років ===");

        Worker[] workers = new Worker[]
        {
            new Worker("Іван Петренко", "інженер", 12),
            new Worker("Оксана Коваль", "менеджер", 7),
            new Worker("Петро Савчук", "слюсар", 15),
            new Worker("Ірина Мельник", "бухгалтер", 9),
            new Worker("Андрій Волинець", "водій", 14)
        };

        foreach (var w in workers)
            w.DisplayIfExperienced();
    }
}
