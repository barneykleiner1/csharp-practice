using System;
using System.Collections.Generic;
using System.Linq;

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

        while (true)
        {
            Console.WriteLine("\n--- МЕНЮ ---");
            Console.WriteLine("1. Показать все задачи");
            Console.WriteLine("2. Показать по приоритету");
            Console.WriteLine("3. Найти задачу");
            Console.WriteLine("4. Добавить задачу");
            Console.WriteLine("5. Удалить задачу");
            Console.WriteLine("6. Статистика");
            Console.WriteLine("7. Поиск по части названия");
            Console.WriteLine("0. Выход");
            Console.Write("Выбор: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    PrintAll(tasks, priorities);
                    break;
                case "2":
                    var sortedTasks = SortByPriority(tasks, priorities);
                    Console.WriteLine("По убыванию приоритета:");
                    PrintAll(sortedTasks, priorities);
                    break;
                case "3":
                    FindTask(priorities);
                    break;
                case "4":
                    AddTaskInteractive(tasks, priorities);
                    break;
                case "5":
                    RemoveTaskInteractive(tasks, priorities);
                    break;
                case "6":
                    PrintStats(tasks, priorities);
                    break;
                case "7":
                    SearchTasks(tasks, priorities);
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Неверный выбор");
                    break;
            }
        }
    }


    // добавление задачи в список и словарь приоритетов
    public static void AddTask(List<string> tasks, Dictionary<string, int> priorities, string task, int priority)
    {
        // Проверка на дубликат
        if (priorities.ContainsKey(task))
        {
            Console.WriteLine("Такая задача уже есть");
            return;
        }

        tasks.Add(task);
        priorities[task] = priority;
        Console.WriteLine($"Задача '{task}' добавлена с приоритетом {priority}");
    }
    public static void RemoveTask(List<string> tasks, Dictionary<string, int> priorities, string task)
    {
        if (!priorities.ContainsKey(task))
        {
            Console.WriteLine("Такой задачи нет");
            return;
        }
        tasks.Remove(task);
        priorities.Remove(task);

        Console.WriteLine($"Задача {task} удалена");
    }
    public static List<string> SortByPriority(List<string> tasks, Dictionary<string, int> priorities)
    {
        return tasks.OrderByDescending(t => priorities[t]).ToList();
    }


    public static void PrintStats(List<string> tasks, Dictionary<string, int> priorities)
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("Список задач пуст");
            return;
        }
        int total = tasks.Count;
        int sum = tasks.Sum(t => priorities[t]);
        double average = tasks.Average(t => priorities[t]);
        int max = tasks.Max(t => priorities[t]);
        int min = tasks.Min(t => priorities[t]);
        string mostImportant = tasks.OrderBy(t => priorities[t]).Last();
        string leastImportant = tasks.OrderBy(t => priorities[t]).First();
        Console.WriteLine("\n--- Статистика ---");
        Console.WriteLine($"Всего задач: {total}");
        Console.WriteLine($"Средний приоритет: {average:F2}");
        Console.WriteLine($"Самая важная: [{max}] {mostImportant}");
        Console.WriteLine($"Самая неприоритетная: [{min}] {leastImportant}");
    }
    public static void AddTaskInteractive(List<string> tasks, Dictionary<string, int> priorities)
    {
        Console.Write("Введите название задачи: ");
        string task = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(task))
        {
            Console.WriteLine("Название задачи не может быть пустым");
            return;
        }
        Console.Write("Введите приоритет задачи (целое число): ");
        if (!int.TryParse(Console.ReadLine(), out int priority))
        {
            Console.WriteLine("Приоритет должен быть целым числом");
            return;
        }
        AddTask(tasks, priorities, task, priority);
    }
    public static void RemoveTaskInteractive(List<string> tasks, Dictionary<string, int> priorities)
    {
        Console.Write("Введите задачу для удаления: ");
        string task = Console.ReadLine();
        RemoveTask(tasks, priorities, task);
    }
    public static void PrintAll(List<string> tasks, Dictionary<string, int> priorities)
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("Список задач пуст");
            return;
        }

        foreach (var task in tasks)
        {
            Console.WriteLine($"  [{priorities[task]}] {task}");
        }
    }
    public static void FindTask(Dictionary<string, int> priorities)
    {
        Console.Write("Введите задачу: ");
        string input = Console.ReadLine();

        if (priorities.TryGetValue(input, out int found))
        {
            Console.WriteLine($"Приоритет: {found}");
        }
        else
        {
            Console.WriteLine("Такой задачи нет");
        }
    }
    public static void SearchTasks(List<string> tasks, Dictionary<string, int> priorities)
    {
        Console.WriteLine("Введите часть названия:");
        string input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Пустой ввод");
            return;
        }
        var foundTasks = tasks.Where(t => t.Contains(input, StringComparison.OrdinalIgnoreCase)).ToList();
        if (foundTasks.Count == 0)
        {
            Console.WriteLine("Задачи не найдены");
        }
        else
        {
            Console.WriteLine("Найденные задачи:");
            foreach (var task in foundTasks)
            {
                Console.WriteLine($"  [{priorities[task]}] {task}");
            }
        }
    }
}