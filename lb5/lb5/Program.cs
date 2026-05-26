using System;
using System.Collections.Generic;
using lb5;

Console.OutputEncoding = System.Text.Encoding.UTF8;
var nums = new List<int> { 1, 2, 3, 4, 10, 8, 5 };
var words = new List<string> { "BMW", "Audi", "Mercedes", "X6" };

Console.WriteLine("--- РЕЗУЛЬТАТИ ЛБ №5 ---");
Console.WriteLine($"1. Непарні: {string.Join(", ", LambdaTasks.FilterOddNumbers(nums))}");
Console.WriteLine($"2. Середнє (1.5, 2.5): {LambdaTasks.GetAverage(new List<double> { 1.5, 2.5 })}");
Console.WriteLine($"3. Алфавіт: {string.Join(", ", LambdaTasks.SortAlphabetically(words))}");
Console.WriteLine($"4. Сума парних: {LambdaTasks.SumOfEvenNumbers(nums)}");
Console.WriteLine($"5. Факторіал 5: {LambdaTasks.CalculateFactorial(5)}");
var (prod, sum) = LambdaTasks.MultiplyAndSum(new List<int> { 2, 3, 4 });
Console.WriteLine($"6. Добуток і Сума (2,3,4): {prod}, {sum}");
Console.WriteLine($"7. Квадрати: {string.Join(", ", LambdaTasks.SquareNumbers(new List<int> { 2, 5 }))}");
Console.WriteLine($"8. За довжиною: {string.Join(", ", LambdaTasks.SortByLength(words))}");
Console.WriteLine($"9. Слів у 'BMW X6 M': {LambdaTasks.CountWords("BMW X6 M")}");
Console.WriteLine($"10. Перший текст: {LambdaTasks.GetFirstNonEmpty(new List<string> { "", "  ", "Hello" })}");
Console.WriteLine($"11. Всі з великої: {LambdaTasks.AllStartWithUpper(words)}");
Console.WriteLine($"12. Друге за вел.: {LambdaTasks.GetSecondLargest(nums)}");
Console.WriteLine($"13. Макс. парне: {LambdaTasks.GetMaxEven(nums)}");