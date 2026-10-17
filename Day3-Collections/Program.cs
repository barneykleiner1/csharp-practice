using System;
using System.Collections.Generic;

class Program
{
    public static void Main()
    {
        var tasks = new List<string>
        {
            "Купить хлеб",
            "Помыть посуду",
            "Сделать зарядку",
            "Прочитать статью"
        };

        var priorities = new Dictionary<string, int>
        {
            ["Купить хлеб"] = 1,
            ["Помыть посуду"] = 3,
            ["Сделать зарядку"] = 2,
            ["Прочитать статью"] = 5
        };

        Console.WriteLine("Все задачи:");
        foreach (var task in tasks)
        {
            int priority = priorities[task];
            Console.WriteLine($"  [{priority}] {task}");
        }

        Console.Write("\nВведите задачу для проверки приоритета: ");
        string input = Console.ReadLine();

        if (priorities.TryGetValue(input, out int foundPriority))
        {
            Console.WriteLine($"Приоритет: {foundPriority}");
        }
        else
        {
            Console.WriteLine("Такой задачи нет");
        }
    }
    public static void AddTask(List<string> tasks, Dictionary<string, int> priorities, string task, int priority)
    {
        tasks.Add(task);
        priorities[task] = priority;
    }
}