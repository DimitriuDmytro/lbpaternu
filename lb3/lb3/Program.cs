using System;
using lb1.creational;
using lb1.structural;

namespace lb1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Налаштування для коректного відображення української мови
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            //lb1
            Console.WriteLine("=== ЛАБОРАТОРНА РОБОТА №1: ПОРОДЖУВАЛЬНІ ПАТЕРНИ ===\n");

            GarageManager.Instance.ShowStatus();
            var creationalFactory = new CarPartFactory();
            Console.WriteLine($"Factory: {creationalFactory.CreatePart("wheel")}");
            EngineFactory engFactory = new SportEngineFactory();
            Console.WriteLine($"Factory Method: {engFactory.CreateEngine().GetPower()}");
            IStyleFactory creationalInterior = new MPerformanceFactory();
            Console.WriteLine($"Abstract Factory: {creationalInterior.CreateSeat().GetMaterial()}, {creationalInterior.CreateDashboard().GetStyle()}");
            var builderCar = new CarConfigurator.Builder().SetModel("X6 F16").SetColor("Donington Grey").EnableShadowLine().Build();
            Console.WriteLine($"Builder: {builderCar.Model}, колір: {builderCar.Color}");
            var stage1 = new TuningStage { Stage = 1 };
            var stage2 = (TuningStage)stage1.Clone();
            stage2.Stage = 2;
            Console.WriteLine($"Prototype: Клоновано з Stage {stage1.Stage} у Stage {stage2.Stage}");

            Console.WriteLine("\n" + new string('=', 50) + "\n");

            //lb2
            Console.WriteLine("=== ЛАБОРАТОРНА РОБОТА №2: СТРУКТУРНІ ПАТЕРНИ ===\n");

            // 1. Adapter
            INewDiagnostic diagnostic = new DiagnosticAdapter(new OldDiagnostic());
            Console.WriteLine($"Adapter: {diagnostic.GetData()}");

            // 2. Bridge
            CarRemote remote = new BmwRemote(new AppControl());
            Console.WriteLine($"Bridge: {remote.PressButton()}");

            // 3. Composite
            var engineBlock = new Assembly();
            engineBlock.Add(new Detail("Поршні"));
            engineBlock.Add(new Detail("Колінвал"));
            var fullCar = new Assembly();
            fullCar.Add(engineBlock);
            fullCar.Add(new Detail("Кузов X5"));
            Console.WriteLine("Composite (Структура вузлів авто):");
            fullCar.Show(0);

            // 4. Decorator
            ICar tunedCar = new MPackageDecorator(new BasicCar());
            Console.WriteLine($"Decorator: {tunedCar.GetInfo()}");

            // 5. Facade
            Console.WriteLine("Facade (Запуск систем однією командою):");
            new CarFacade().ReadyToGo();

            // 6. Flyweight
            var sharedInfo = new CarModelType { Model = "M5", Color = "Marina Bay Blue" };
            new CarOnMap { X = 10, Type = sharedInfo }.Display();
            new CarOnMap { X = 55, Type = sharedInfo }.Display();

            // 7. Proxy
            Console.WriteLine("Proxy (Перевірка доступу до ЕБК):");
            Console.WriteLine($"Спроба 1: {new EcuProxy("wrong_password").Request()}");
            Console.WriteLine($"Спроба 2: {new EcuProxy("bmw_admin").Request()}");

            Console.WriteLine("\n--- Всі патерни виконано успішно ---");
            Console.WriteLine("Натисніть будь-яку клавішу для виходу...");
            Console.ReadKey();
        }
    }
}