// Managers/AnimalManager.cs (дополненный)
using System;
using System.Collections.Generic;
using System.Linq;
using AnimalProject.Models;

namespace AnimalProject.Managers
{
    public class AnimalManager
    {
        private static AnimalManager _instance;
        private List<Animal> _animals;

        private AnimalManager()
        {
            _animals = new List<Animal>();
        }

        public static AnimalManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AnimalManager();
                }
                return _instance;
            }
        }

        public void AddAnimal(Animal animal)
        {
            _animals.Add(animal);
            Console.WriteLine($"Животное {animal.Name} успешно добавлено!");
        }

        public void ShowAllAnimals()
        {
            if (_animals.Count == 0)
            {
                Console.WriteLine("Список животных пуст.");
                return;
            }

            Console.WriteLine("\n=== Список всех животных ===");
            for (int i = 0; i < _animals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_animals[i].GetInfo()}");
            }
        }

        public void ShowAnimalByName(string name)
        {
            var animal = _animals.FirstOrDefault(a => a.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (animal == null)
            {
                Console.WriteLine($"Животное с именем '{name}' не найдено.");
                return;
            }

            Console.WriteLine($"\n=== Информация о животном '{name}' ===");
            Console.WriteLine(animal.GetInfo());
        }

        public Animal GetAnimalByIndex(int index)
        {
            if (index >= 0 && index < _animals.Count)
            {
                return _animals[index];
            }
            return null;
        }

        public int Count => _animals.Count;
    }
}