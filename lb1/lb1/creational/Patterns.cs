using System;

namespace lb1.creational
{
    // 1. Singleton (Одинак)
    public sealed class GarageManager
    {
        private static GarageManager _instance;
        private GarageManager() { Console.WriteLine("Менеджер гаража ініціалізований."); }
        public static GarageManager Instance => _instance ??= new GarageManager();
        public void ShowStatus() => Console.WriteLine("Всі системи працюють стабільно.");
    }

    // 2. Factory (Фабрика)
    public class CarPartFactory
    {
        public string CreatePart(string type) => type.ToLower() switch
        {
            "wheel" => "Спортивне колесо R20",
            "spoiler" => "Карбоновий спойлер",
            _ => "Стандартна деталь"
        };
    }

    // 3. Factory Method (Фабричний метод)
    public abstract class EngineFactory { public abstract IEngine CreateEngine(); }
    public interface IEngine { string GetPower(); }

    public class SportEngine : IEngine { public string GetPower() => "600 к.с. (V8 Turbo)"; }
    public class SportEngineFactory : EngineFactory
    {
        public override IEngine CreateEngine() => new SportEngine();
    }

    // 4. Abstract Factory (Абстрактна фабрика)
    public interface IStyleFactory { ISeat CreateSeat(); IDashboard CreateDashboard(); }
    public interface ISeat { string GetMaterial(); }
    public interface IDashboard { string GetStyle(); }

    public class MPerformanceFactory : IStyleFactory
    {
        public ISeat CreateSeat() => new AlcantaraSeat();
        public IDashboard CreateDashboard() => new CarbonDashboard();
    }

    public class AlcantaraSeat : ISeat { public string GetMaterial() => "Алькантара з синьою прошивкою"; }
    public class CarbonDashboard : IDashboard { public string GetStyle() => "Матовий карбон"; }

    // 5. Builder (Будівельник)
    public class CarConfigurator
    {
        public string Model { get; set; }
        public string Color { get; set; }
        public bool ShadowLine { get; set; }

        public class Builder
        {
            private readonly CarConfigurator _car = new();
            public Builder SetModel(string model) { _car.Model = model; return this; }
            public Builder SetColor(string color) { _car.Color = color; return this; }
            public Builder EnableShadowLine() { _car.ShadowLine = true; return this; }
            public CarConfigurator Build() => _car;
        }
    }

    // 6. Prototype (Прототип)
    public abstract class CarSpecs { public abstract CarSpecs Clone(); }

    public class TuningStage : CarSpecs
    {
        public int Stage { get; set; }
        public override CarSpecs Clone() => (CarSpecs)this.MemberwiseClone();
    }
}