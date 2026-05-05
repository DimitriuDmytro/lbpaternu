using System;
using System.Collections.Generic;

namespace lb3.behavioral
{
    // 1. Ланцюжок обов’язків (Chain of Responsibility) - Перевірка систем перед стартом
    public abstract class Handler
    {
        protected Handler next;
        public void SetNext(Handler n) => next = n;
        public abstract void Handle(string request);
    }
    public class FuelHandler : Handler
    {
        public override void Handle(string req)
        {
            if (req == "FuelOK") next?.Handle("OilOK");
            else Console.WriteLine("Зупинка: немає палива.");
        }
    }

    // 2. Команда (Command) - Кнопки на кермі
    public interface ICommand { void Execute(); }
    public class BeepCommand : ICommand { public void Execute() => Console.WriteLine("BMW: BEEP!"); }

    // 3. Ітератор (Iterator) - Перегляд сервісної історії
    public class ServiceHistory
    {
        private string[] records = { "Заміна масла", "Тюнінг Stage 2", "Детейлінг" };
        public IEnumerable<string> GetRecords() { foreach (var r in records) yield return r; }
    }

    // 4. Посередник (Mediator) - Координація сенсорів паркування та гальм
    public class CarMediator
    {
        public void Notify(string ev)
        {
            if (ev == "Obstacle") Console.WriteLine("Mediator: Перешкода! Активуємо гальма.");
        }
    }

    // 5. Знімок (Memento) - Збереження налаштувань сидіння
    public class SeatMemento { public string Pos { get; } public SeatMemento(string p) => Pos = p; }
    public class Seat
    {
        public string Position { get; set; }
        public SeatMemento Save() => new SeatMemento(Position);
        public void Restore(SeatMemento m) => Position = m.Pos;
    }

    // 6. Спостерігач (Observer) - Датчик тиску в шинах
    public class TyreSensor
    {
        public event Action<string> OnLowPressure;
        public void Check() => OnLowPressure?.Invoke("Низький тиск у задньому лівому!");
    }

    // 7. Стан (State) - Режими коробки передач
    public interface IGearState { void Shift(); }
    public class ParkingState : IGearState { public void Shift() => Console.WriteLine("Gear: Drive Mode"); }

    // 8. Стратегія (Strategy) - Режими їзди
    public interface IDriveStrategy { void Drive(); }
    public class SportStrategy : IDriveStrategy { public void Drive() => Console.WriteLine("Режим: SPORT+ (Вихлоп відкрито)"); }

    // 9. Шаблонний метод (Template Method) - Процес миття авто
    public abstract class CarWash
    {
        public void Wash() { Soak(); Scrub(); Dry(); }
        protected abstract void Scrub();
        private void Soak() => Console.WriteLine("Замочування піною...");
        private void Dry() => Console.WriteLine("Сушіння повітрям.");
    }
    public class PremiumWash : CarWash { protected override void Scrub() => Console.WriteLine("Ручна мийка мікрофіброю."); }

    // 10. Відвідувач (Visitor) - Техогляд різних частин
    public interface ICarElement { void Accept(IVisitor v); }
    public interface IVisitor { void Visit(Engine e); }
    public class Engine : ICarElement { public void Accept(IVisitor v) => v.Visit(this); }
    public class DiagnosticVisitor : IVisitor { public void Visit(Engine e) => Console.WriteLine("Visitor: Діагностика двигуна пройдена."); }
}