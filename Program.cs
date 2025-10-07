using System;
using Plants;
using Gardens;

namespace Program
{
    class Program
    {
        private static Garden myGarden = new Garden();

        static void Main(string[] args)
        {
            Menu();
        }

        public static void Menu()
        {
            string? choice;
            while (true)
            {
                Console.WriteLine("\n=== МЕНЮ САДА ===");
                Console.WriteLine("1. Добавить дерево");
                Console.WriteLine("2. Добавить куст");
                Console.WriteLine("3. Показать все растения");
                Console.WriteLine("4. Ухаживать за деревом");
                Console.WriteLine("5. Собрать урожай с дерева");
                Console.WriteLine("6. Вырастить куст");
                Console.WriteLine("7. Использовать деконструктор дерева");
                Console.WriteLine("0. Выход");
                Console.Write("Выберите пункт меню: ");

                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddTree();
                        break;
                    case "2":
                        AddShrub();
                        break;
                    case "3":
                        myGarden.ShowPlants();
                        break;
                    case "4":
                        CareForTree();
                        break;
                    case "5":
                        HarvestFromTree();
                        break;
                    case "6":
                        GrowShrub();
                        break;
                    case "7":
                        DeconstructTree();
                        break;
                    case "0":
                        Console.WriteLine("Выход из программы...");
                        return;
                    default:
                        Console.WriteLine("Неверный выбор!");
                        break;
                }
            }
        }

        private static void AddTree()
        {
            string? input;
            int typeChoice;
            double height;
            Tree tree;
            try
            {
                Console.WriteLine("\n--- Добавление дерева ---");
                
                tree = new Tree();
                
                Console.WriteLine("Выберите тип дерева:");
                Console.WriteLine("1. Oak");
                Console.WriteLine("2. Pine"); 
                Console.WriteLine("3. Birch");
                Console.WriteLine("4. Maple");
                Console.Write("Ваш выбор: ");

                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Неверный ввод!");
                    return;
                }
                typeChoice = int.Parse(input);
                tree.Type = typeChoice switch
                {
                    1 => TreeType.Oak,
                    2 => TreeType.Pine,
                    3 => TreeType.Birch,
                    4 => TreeType.Maple,
                    _ => TreeType.Oak
                };
                
                Console.Write("Введите высоту дерева (0-150 м): ");

                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Неверный ввод!");
                    return;
                }
                height = double.Parse(input);
                tree.Height = new Height(height);
                
                
                Console.Write("Введите возраст дерева (0-5000 лет): ");
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Неверный ввод!");
                    return;
                }
                tree.Age = int.Parse(input);
                
                myGarden.AddPlant(tree);
                Console.WriteLine("Дерево успешно добавлено!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        private static void AddShrub()
        {
            string? input;
            int typeChoice;
            double height;
            Shrub shrub;
            try
            {
                Console.WriteLine("\n--- Добавление куста ---");
                
                shrub = new Shrub();
                
                Console.WriteLine("Выберите тип куста:");
                Console.WriteLine("1. Oak");
                Console.WriteLine("2. Pine");
                Console.WriteLine("3. Birch"); 
                Console.WriteLine("4. Maple");
                Console.Write("Ваш выбор: ");
                input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Неверный ввод!");
                    return;
                }
                typeChoice = int.Parse(input);  
                shrub.Type = typeChoice switch
                {
                    1 => TreeType.Oak,
                    2 => TreeType.Pine,
                    3 => TreeType.Birch,
                    4 => TreeType.Maple,
                    _ => TreeType.Oak
                };
                
                Console.Write("Введите высоту куста (0-10 м): ");
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Неверный ввод!");
                    return;
                }
                height = double.Parse(input);
                shrub.Height = new Height(height);
                
                myGarden.AddPlant(shrub);
                Console.WriteLine("Куст успешно добавлен!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        private static void CareForTree()
        {
            int index;
            string? input;
            try
            {
                Console.Write("Введите индекс дерева для ухода: ");
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Неверный ввод!");
                    return;
                }
                index = int.Parse(input) - 1;
                myGarden.CareForTree(index);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        private static void HarvestFromTree()
        {
            int index;
            string? input;
            try
            {
                Console.Write("Введите индекс дерева для сбора урожая: ");
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Неверный ввод!");
                    return;
                }
                index = int.Parse(input) - 1;
                myGarden.HarvestFromTree(index);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        private static void GrowShrub()
        {
            int index;
            string? input;
            try
            {
                myGarden.ShowPlants();
                Console.Write("Введите индекс куста для роста: ");
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Неверный ввод!");
                    return;
                }
                index = int.Parse(input) - 1;
                
                var plants = myGarden.GetPlants();
                if (index >= 0 && index < plants.Count && plants[index] is Shrub shrub)
                {
                    shrub.Grow();
                }
                else
                {
                    Console.WriteLine("Куст с таким индексом не найден!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        private static void DeconstructTree()
        {
            int index;
            string? input;
            try
            {
                myGarden.ShowPlants();
                Console.Write("Введите индекс дерева для деконструкции: ");
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Неверный ввод!");
                    return;
                }
                index = int.Parse(input) - 1;
                
                var plants = myGarden.GetPlants();
                if (index >= 0 && index < plants.Count && plants[index] is Tree tree)
                {
                    var (type, height) = tree;
                    Console.WriteLine($"Деконструктор: Тип - {type}, Высота - {height}");
                }
                else
                {
                    Console.WriteLine("Дерево с таким индексом не найдено!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}