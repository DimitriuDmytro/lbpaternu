using System;
using lb3.behavioral;

namespace lb3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== ЛАБОРАТОРНА РОБОТА №3: ПОВЕДІНКОВІ ПАТЕРНИ ===\n");

            // 1. Chain of Responsibility
            var fuel = new FuelHandler();
            fuel.Handle("FuelOK");
            Console.WriteLine("1. Chain: Перевірка пройдена.");

            // 2. Command
            ICommand beep = new BeepCommand();
            beep.Execute();

            // 3. Iterator
            var history = new ServiceHistory();
            Console.Write("3. Iterator (Сервіс): ");
            foreach (var rec in history.GetRecords()) Console.Write($"{rec} | ");
            Console.WriteLine();

            // 4. Mediator
            var med = new CarMediator();
            med.Notify("Obstacle");

            // 5. Memento
            var seat = new Seat { Position = "Memory 1: Dmytro" };
            var saved = seat.Save();
            seat.Position = "Memory 2: Guest";
            seat.Restore(saved);
            Console.WriteLine($"5. Memento: Повернуто позицію: {seat.Position}");

            // 6. Observer
            var sensor = new TyreSensor();
            sensor.OnLowPressure += (msg) => Console.WriteLine($"6. Observer: {msg}");
            sensor.Check();

            // 7. State
            IGearState gear = new ParkingState();
            gear.Shift();

            // 8. Strategy
            IDriveStrategy mode = new SportStrategy();
            mode.Drive();

            // 9. Template Method
            CarWash wash = new PremiumWash();
            wash.Wash();

            // 10. Visitor
            var engine = new Engine();
            engine.Accept(new DiagnosticVisitor());

            Console.WriteLine("\n--- Всі 10 поведінкових патернів активовано ---");
            Console.ReadKey();
        }
    }
}