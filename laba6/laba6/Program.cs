using System;
using System.Collections.Generic;
using lb5;

Console.OutputEncoding = System.Text.Encoding.UTF8;

var nums = new List<int> { 1, 2, 3, 4, 10, 8, 5 };
var words = new List<string> { "BMW", "Audi", "Mercedes", "X6" };

Console.WriteLine("--- РЕЗУЛЬТАТИ ЛБ №5 ---");
Console.WriteLine($"3. Алфавіт: {string.Join(", ", LambdaTasks.SortAlphabetically(words))}");

Console.WriteLine("--- РЕЗУЛЬТАТИ ЛБ №6 (Патерни) ---");

var sorted = PatternTasks.ApplyStrategy(words, w => w.Length);
Console.WriteLine($"Стратегія (за довжиною): {string.Join(", ", sorted)}");

var bmwFactory = PatternTasks.CreateCarFactory("BMW");
Console.WriteLine($"Фабрика: {bmwFactory("X6")}");

PatternTasks.ExecuteWithLog("Аналіз", () => {
    Console.WriteLine("Тут виконується бізнес-логіка...");
});