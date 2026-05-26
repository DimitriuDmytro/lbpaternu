using System;

namespace lb7 
{
    public class Logger { public void Log(string msg) => Console.WriteLine(msg); }
    public class Config { public string Name = "AppConfig"; }
    public class DataProvider { public string GetData() => "Дані завантажено"; }

    public class Repository
    {
        private readonly Logger _logger;
        private readonly DataProvider _data;
        public Repository(Logger logger, DataProvider data)
        {
            _logger = logger;
            _data = data;
        }
        public string GetInfo() => _data.GetData();
    }

    public class Service
    {
        private readonly Repository _repo;
        private readonly Logger _logger;
        private readonly Config _config;

        public Service(Repository repo, Logger logger, Config config)
        {
            _repo = repo;
            _logger = logger;
            _config = config;
        }

        public void Run()
        {
            _logger.Log("Сервіс запущено!");
            Console.WriteLine($"Конфігурація: {_config.Name}");
            Console.WriteLine($"Результат: {_repo.GetInfo()}");
        }
    }
}