using System;
using System.Collections.Generic;
using System.Linq;

namespace lb5
{
    public static class LambdaTasks
    {
        // 1. Відфільтрувати непарні числа
        public static List<int> FilterOddNumbers(List<int> numbers) =>
            numbers.Where(n => n % 2 != 0).ToList();

        // 2. Знайти середнє зі списку дійсних значень
        public static double GetAverage(List<double> values) =>
            values.Any() ? values.Average() : 0;

        // 3. Сортування списку рядків в алфавітному порядку
        public static List<string> SortAlphabetically(List<string> strings) =>
            strings.OrderBy(s => s).ToList();

        // 4. Обчислення суми всіх парних чисел
        public static int SumOfEvenNumbers(List<int> numbers) =>
            numbers.Where(n => n % 2 == 0).Sum();

        // 5. Обчислити факторіал заданого числа
        public static long CalculateFactorial(int n) =>
            n < 0 ? 0 : (n == 0 ? 1 : Enumerable.Range(1, n).Select(x => (long)x).Aggregate((a, b) => a * b));

        // 6. Множення та підсумовування всіх елементів
        public static (long product, int sum) MultiplyAndSum(List<int> numbers) =>
            (numbers.Aggregate(1L, (a, b) => a * b), numbers.Sum());

        // 7. Розрахуйте квадрат кожного числа
        public static List<int> SquareNumbers(List<int> numbers) =>
            numbers.Select(n => n * n).ToList();

        // 8. Сортування рядків на основі їх довжини (зростання)
        public static List<string> SortByLength(List<string> strings) =>
            strings.OrderBy(s => s.Length).ToList();

        // 9. Підрахуйте кількість слів у реченні
        public static int CountWords(string sentence) =>
            sentence.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Count();

        // 10. Знайти перший непорожній рядок
        public static string GetFirstNonEmpty(List<string> strings) =>
            strings.FirstOrDefault(s => !string.IsNullOrWhiteSpace(s)) ?? "Всі рядки порожні";

        // 11. Перевірити, чи всі рядки починаються з великої літери
        public static bool AllStartWithUpper(List<string> strings) =>
            strings.All(s => !string.IsNullOrEmpty(s) && char.IsUpper(s[0]));

        // 12. Знайти друге за величиною число
        public static int GetSecondLargest(List<int> numbers) =>
            numbers.Distinct().OrderByDescending(n => n).Skip(1).FirstOrDefault();

        // 13. Знайти найбільше парне число
        public static int? GetMaxEven(List<int> numbers) =>
            numbers.Where(n => n % 2 == 0).Cast<int?>().Max();
    }
}