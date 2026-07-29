// Program.cs (финальная версия с обработкой ошибок)
using System;
using AnimalProject.Models;
using AnimalProject.Managers;

namespace AnimalProject
{
    class Program
    {
        private static AnimalManager _manager = AnimalManager.Instance;

        static void Main(string[] args)
        {
            Console.Title = "Система управления животными";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Добро пожаловать в зоопарк!");
            Console.ResetColor();

            SeedData();

            bool exit = false;
            while (!exit)
            {
                try
                {
                    ShowMenu();
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            ShowAllAnimals();
                            break;
                        case "2":
                            ShowAnimalByName();
                            break;
                        case "3":
                            AddNewAnimal();
                            break;
                        case "4":
                            exit = true;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("До свидания! Спасибо за использование программы.");
                            Console.ResetColor();
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Ошибка: неверный выбор. Попробуйте снова.");
                            Console.ResetColor();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Произошла ошибка: {ex.Message}");
                    Console.ResetColor();
                }

                if (!exit)
                {
                    Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        static void ShowMenu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n╔════════════════════════════════════╗");
            Console.WriteLine("║   СИСТЕМА УПРАВЛЕНИЯ ЖИВОТНЫМИ   ║");
            Console.WriteLine("╚════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine("1. Показать всех животных");
            Console.WriteLine("2. Найти животное по имени");
            Console.WriteLine("3. Добавить новое животное");
            Console.WriteLine("4. Выход");
            Console.Write("\nВаш выбор: ");
        }

        static void SeedData()
        {
            Console.WriteLine("Загрузка тестовых данных...");
            _manager.AddAnimal(new Mammal("Барсик", 5, "лес", "хищник", true));
            _manager.AddAnimal(new Mammal("Рекс", 3, "дом", "всеядное", true));
            _manager.AddAnimal(new Bird("Кеша", 2, "город", "всеядное", 0.5));
            _manager.AddAnimal(new Bird("Орлан", 4, "горы", "хищник", 2.3));
            _manager.AddAnimal(new Fish("Немо", 1, "океан", "всеядное", "морская"));
            _manager.AddAnimal(new Fish("Золотая", 2, "аквариум", "травоядное", "пресная"));
            _manager.AddAnimal(new Reptile("Гоша", 3, "пустыня", "хищник", true));
            _manager.AddAnimal(new Reptile("Тортилла", 50, "водоём", "травоядное", false));
            _manager.AddAnimal(new Amphibian("Квакша", 1, "водоём", "насекомоядное", "высокая"));
            _manager.AddAnimal(new Amphibian("Тритон", 2, "лес", "хищник", "средняя"));
            Console.WriteLine($"Загружено {_manager.Count} животных.\n");
        }

        static void ShowAllAnimals()
        {
            _manager.ShowAllAnimals();
        }

        static void ShowAnimalByName()
        {
            Console.Write("Введите имя животного: ");
            string name = Console.ReadLine().Trim();

            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Имя не может быть пустым.");
                return;
            }

            _manager.ShowAnimalByName(name);
        }

        static void AddNewAnimal()
        {
            Console.WriteLine("\nВыберите тип животного:");
            Console.WriteLine("1. Млекопитающее");
            Console.WriteLine("2. Птица");
            Console.WriteLine("3. Рыба");
            Console.WriteLine("4. Пресмыкающееся");
            Console.WriteLine("5. Земноводное");
            Console.Write("Ваш выбор: ");

            string typeChoice = Console.ReadLine();

            try
            {
                Console.Write("Введите кличку: ");
                string name = Console.ReadLine().Trim();

                if (string.IsNullOrEmpty(name))
                {
                    Console.WriteLine("Кличка не может быть пустой!");
                    return;
                }

                Console.Write("Введите возраст (целое число): ");
                int age = int.Parse(Console.ReadLine());

                if (age < 0)
                {
                    Console.WriteLine("Возраст не может быть отрицательным!");
                    return;
                }

                Console.Write("Введите среду обитания: ");
                string habitat = Console.ReadLine().Trim();

                Console.Write("Введите тип питания (хищник/травоядное/всеядное): ");
                string diet = Console.ReadLine().Trim();

                Animal newAnimal = null;

                switch (typeChoice)
                {
                    case "1":
                        Console.Write("Есть ли шерсть? (да/нет): ");
                        bool hasFur = Console.ReadLine().ToLower() == "да";
                        newAnimal = new Mammal(name, age, habitat, diet, hasFur);
                        break;
                    case "2":
                        Console.Write("Введите размах крыльев (м): ");
                        double wingSpan = double.Parse(Console.ReadLine());
                        newAnimal = new Bird(name, age, habitat, diet, wingSpan);
                        break;
                    case "3":
                        Console.Write("Введите тип воды (пресная/морская): ");
                        string waterType = Console.ReadLine().Trim();
                        newAnimal = new Fish(name, age, habitat, diet, waterType);
                        break;
                    case "4":
                        Console.Write("Ядовито? (да/нет): ");
                        bool isVenomous = Console.ReadLine().ToLower() == "да";
                        newAnimal = new Reptile(name, age, habitat, diet, isVenomous);
                        break;
                    case "5":
                        Console.Write("Введите влажность кожи (низкая/средняя/высокая): ");
                        string skinMoisture = Console.ReadLine().Trim();
                        newAnimal = new Amphibian(name, age, habitat, diet, skinMoisture);
                        break;
                    default:
                        Console.WriteLine("Ошибка: неверный тип животного!");
                        return;
                }

                if (newAnimal != null)
                {
                    _manager.AddAnimal(newAnimal);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"✓ Животное '{name}' успешно добавлено в зоопарк!");
                    Console.ResetColor();
                }
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ошибка: введено некорректное значение. Пожалуйста, введите число.");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Ошибка при добавлении животного: {ex.Message}");
                Console.ResetColor();
            }
        }
    }
}