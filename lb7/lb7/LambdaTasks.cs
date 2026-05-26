using System;
using System.Collections.Generic;
using System.Linq;

namespace lb5
{
    public static class LambdaTasks
    {
        public static List<int> FilterOddNumbers(List<int> numbers) =>
            numbers.Where(n => n % 2 != 0).ToList();

        public static double GetAverage(List<double> values) =>
            values.Any() ? values.Average() : 0;

        public static List<string> SortAlphabetically(List<string> strings) =>
            strings.OrderBy(s => s).ToList();

        public static int SumOfEvenNumbers(List<int> numbers) =>
            numbers.Where(n => n % 2 == 0).Sum();

        public static long CalculateFactorial(int n) =>
            n < 0 ? 0 : (n == 0 ? 1 : Enumerable.Range(1, n).Select(x => (long)x).Aggregate((a, b) => a * b));

        public static (long product, int sum) MultiplyAndSum(List<int> numbers) =>
            (numbers.Aggregate(1L, (a, b) => a * b), numbers.Sum());

        public static List<int> SquareNumbers(List<int> numbers) =>
            numbers.Select(n => n * n).ToList();

        public static List<string> SortByLength(List<string> strings) =>
            strings.OrderBy(s => s.Length).ToList();

        public static int CountWords(string sentence) =>
            sentence.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Count();

        public static string GetFirstNonEmpty(List<string> strings) =>
            strings.FirstOrDefault(s => !string.IsNullOrWhiteSpace(s)) ?? "Всі рядки порожні";

        public static bool AllStartWithUpper(List<string> strings) =>
            strings.All(s => !string.IsNullOrEmpty(s) && char.IsUpper(s[0]));

        public static int GetSecondLargest(List<int> numbers) =>
            numbers.Distinct().OrderByDescending(n => n).Skip(1).FirstOrDefault();

        public static int? GetMaxEven(List<int> numbers) =>
            numbers.Where(n => n % 2 == 0).Cast<int?>().Max();
    }
}