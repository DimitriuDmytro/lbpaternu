using System;
using System.Collections.Generic;

namespace lb1.structural
{
    // 1. Адаптер (Adapter) - адаптує стару діагностику під новий інтерфейс
    public interface INewDiagnostic { string GetData(); }
    public class OldDiagnostic { public string GetLegacyInfo() => "Дані зі старого OBD-I"; }
    public class DiagnosticAdapter : INewDiagnostic
    {
        private readonly OldDiagnostic _old;
        public DiagnosticAdapter(OldDiagnostic old) => _old = old;
        public string GetData() => $"Адаптовано: {_old.GetLegacyInfo()}";
    }

    // 2. Міст (Bridge) - розділяє керування та тип авто
    public interface ICarControl { string Apply(); }
    public class AppControl : ICarControl { public string Apply() => "через мобільний додаток"; }
    public abstract class CarRemote
    {
        protected ICarControl control;
        protected CarRemote(ICarControl ctrl) => control = ctrl;
        public abstract string PressButton();
    }
    public class BmwRemote : CarRemote
    {
        public BmwRemote(ICarControl ctrl) : base(ctrl) { }
        public override string PressButton() => $"Запуск BMW {control.Apply()}";
    }

    // 3. Компонувальник (Composite) - дерево деталей авто
    public abstract class CarPart { public abstract void Show(int indent); }
    public class Detail : CarPart
    {
        private string _name;
        public Detail(string name) => _name = name;
        public override void Show(int indent) => Console.WriteLine(new string('-', indent) + _name);
    }
    public class Assembly : CarPart
    {
        private List<CarPart> _parts = new();
        public void Add(CarPart p) => _parts.Add(p);
        public override void Show(int indent)
        {
            foreach (var p in _parts) p.Show(indent + 2);
        }
    }

    // 4. Декоратор (Decorator) - додавання опцій тюнінгу
    public interface ICar { string GetInfo(); }
    public class BasicCar : ICar { public string GetInfo() => "BMW X5"; }
    public class MPackageDecorator : ICar
    {
        private readonly ICar _car;
        public MPackageDecorator(ICar car) => _car = car;
        public string GetInfo() => _car.GetInfo() + " + M-Package";
    }

    // 5. Фасад (Facade) - швидкий запуск складних систем
    public class CarEngine { public void Start() => Console.WriteLine("Двигун працює."); }
    public class FuelSystem { public void Check() => Console.WriteLine("Паливо в нормі."); }
    public class CarFacade
    {
        private CarEngine _e = new(); private FuelSystem _f = new();
        public void ReadyToGo() { _f.Check(); _e.Start(); }
    }

    // 6. Легковаговик (Flyweight) - спільні дані для багатьох авто на карті
    public class CarModelType
    { // Спільний стан
        public string Model { get; set; }
        public string Color { get; set; }
    }
    public class CarOnMap
    {
        public int X { get; set; }
        public CarModelType Type { get; set; }
        public void Display() => Console.WriteLine($"Авто {Type.Model} ({Type.Color}) на позиції {X}");
    }

    // 7. Замісник (Proxy) - контроль доступу до ЕБК (комп'ютера авто)
    public interface IEcu { string Request(); }
    public class RealEcu : IEcu { public string Request() => "Доступ до налаштувань двигуна відкрито."; }
    public class EcuProxy : IEcu
    {
        private RealEcu _real;
        private string _password;
        public EcuProxy(string pw) => _password = pw;
        public string Request()
        {
            if (_password != "bmw_admin") return "Відмовлено в доступі!";
            _real ??= new RealEcu();
            return _real.Request();
        }
    }
}