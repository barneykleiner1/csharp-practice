using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;

class Program
{
    public static async Task Main() // Main теперь async
    {
        var stopwatch = Stopwatch.StartNew();

        Console.WriteLine("Начинаем загрузку данных...");

        // Запускаем все три задачи ОДНОВРЕМЕННО
        var userTask = LoadUserDataAsync();
        var ordersTask = LoadOrdersDataAsync();
        var productsTask = LoadProductsDataAsync();

        // Ждём, пока ВСЕ три завершатся
        await Task.WhenAll(userTask, ordersTask, productsTask);
        
        // Достать результат:
        string userName = await userTask;
        int ordersCount = await ordersTask;
        var products = await productsTask;

        stopwatch.Stop();
        Console.WriteLine($"Пользователь: {userName}, Заказы: {ordersCount}, Товары: {string.Join(", ", products)}");
        Console.WriteLine($"Всё загружено за {stopwatch.ElapsedMilliseconds} мс");
    }

    public static async Task<string> LoadUserDataAsync()
    {
        Console.WriteLine("Загрузка пользователей...");
        await Task.Delay(2000); // Асинх. 2 секунды
        return "Кирилл";
    }

    public static async Task<int> LoadOrdersDataAsync()
    {
        Console.WriteLine("Загрузка заказов...");
        await Task.Delay(2000);
        Console.WriteLine("Заказы загружены");
        return 5; // Возвращаем количество заказов
    }

    public static async Task<List<string>> LoadProductsDataAsync()
    {
        Console.WriteLine("Загрузка товаров...");
        await Task.Delay(2000);
        Console.WriteLine("Товары загружены");
        return new List<string> { "Товар 1", "Товар 2", "Товар 3" };
    }
}