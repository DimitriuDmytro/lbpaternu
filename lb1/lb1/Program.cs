using System;
using lb1.creational; // Підключаємо нашу папку з патернами

namespace lb1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Налаштування для коректного відображення української мови в консолі
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== ЛАБОРАТОРНА РОБОТА №1: ПОРОДЖУВАЛЬНІ ПАТЕРНИ ===\n");

            // 1. Singleton (Одинак)
            // Використовується для створення єдиного екземпляра менеджера
            GarageManager.Instance.ShowStatus();

            // 2. Factory (Фабрика)
            // Створює деталі за назвою
            var factory = new CarPartFactory();
            Console.WriteLine($"Factory: {factory.CreatePart("wheel")}");

            // 3. Factory Method (Фабричний метод)
            // Визначає, який тип двигуна створювати через спеціальну фабрику
            EngineFactory engFactory = new SportEngineFactory();
            Console.WriteLine($"Factory Method: {engFactory.CreateEngine().GetPower()}");

            // 4. Abstract Factory (Абстрактна фабрика)
            // Створює ціле сімейство елементів інтер'єру (сидіння + панель)
            IStyleFactory interior = new MPerformanceFactory();
            Console.WriteLine($"Abstract Factory (салон): {interior.CreateSeat().GetMaterial()}, {interior.CreateDashboard().GetStyle()}");

            // 5. Builder (Будівельник)
            // Покрокова збірка конкретної моделі з налаштуваннями
            var customCar = new CarConfigurator.Builder()
                .SetModel("X6 F16")
                .SetColor("Donington Grey")
                .EnableShadowLine()
                .Build();
            Console.WriteLine($"Builder (конфігурація): {customCar.Model}, колір: {customCar.Color}, Shadow Line: {customCar.ShadowLine}");

            // 6. Prototype (Прототип)
            // Клонування існуючих налаштувань для створення нового рівня тюнінгу
            var stage1 = new TuningStage { Stage = 1 };
            var stage2 = (TuningStage)stage1.Clone();
            stage2.Stage = 2;
            Console.WriteLine($"Prototype: Оригінал - Stage {stage1.Stage}, Клон - Stage {stage2.Stage}");

            Console.WriteLine("\n--- Всі 6 патернів продемонстровано ---");
            Console.WriteLine("Натисніть будь-яку клавішу, щоб завершити...");
            Console.ReadKey();
        }
    }
}