using System;
using System.Collections.Generic;
using System.Linq;

namespace lb5
{
    public static class PatternTasks
    {
        public static List<string> ApplyStrategy(List<string> items, Func<string, object> strategy)
            => items.OrderBy(strategy).ToList();

        public static Func<string, string> CreateCarFactory(string brand)
            => model => $"{brand} {model}";

        public static string Decorate(string input, Func<string, string> decorator)
            => decorator(input);

        public static void ExecuteWithLog(string name, Action action)
        {
            Console.WriteLine($"--- [{name} START] ---");
            action();
            Console.WriteLine($"--- [{name} END] ---");
        }
    }
}