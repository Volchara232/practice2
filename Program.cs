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

                string choice = Console.ReadLine();

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
            try
            {
                Console.WriteLine("\n--- Добавление дерева ---");
                
                Tree tree = new Tree();
                
                Console.WriteLine("Выберите тип дерева:");
                Console.WriteLine("1. Oak");
                Console.WriteLine("2. Pine"); 
                Console.WriteLine("3. Birch");
                Console.WriteLine("4. Maple");
                Console.Write("Ваш выбор: ");
                int typeChoice = int.Parse(Console.ReadLine());
                
                tree.Type = typeChoice switch
                {
                    1 => TreeType.Oak,
                    2 => TreeType.Pine,
                    3 => TreeType.Birch,
                    4 => TreeType.Maple,
                    _ => TreeType.Oak
                };
                
                Console.Write("Введите высоту дерева (0-150 м): ");
                double height = double.Parse(Console.ReadLine());
                tree.Height = new Height(height);
                
                Console.Write("Введите возраст дерева (0-5000 лет): ");
                tree.Age = int.Parse(Console.ReadLine());
                
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
            try
            {
                Console.WriteLine("\n--- Добавление куста ---");
                
                Shrub shrub = new Shrub();
                
                Console.WriteLine("Выберите тип куста:");
                Console.WriteLine("1. Oak");
                Console.WriteLine("2. Pine");
                Console.WriteLine("3. Birch"); 
                Console.WriteLine("4. Maple");
                Console.Write("Ваш выбор: ");
                int typeChoice = int.Parse(Console.ReadLine());
                
                shrub.Type = typeChoice switch
                {
                    1 => TreeType.Oak,
                    2 => TreeType.Pine,
                    3 => TreeType.Birch,
                    4 => TreeType.Maple,
                    _ => TreeType.Oak
                };
                
                Console.Write("Введите высоту куста (0-10 м): ");
                double height = double.Parse(Console.ReadLine());
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
            try
            {
                Console.Write("Введите индекс дерева для ухода: ");
                int index = int.Parse(Console.ReadLine()) - 1;
                myGarden.CareForTree(index);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        private static void HarvestFromTree()
        {
            try
            {
                Console.Write("Введите индекс дерева для сбора урожая: ");
                int index = int.Parse(Console.ReadLine()) - 1;
                myGarden.HarvestFromTree(index);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        private static void GrowShrub()
        {
            try
            {
                myGarden.ShowPlants();
                Console.Write("Введите индекс куста для роста: ");
                int index = int.Parse(Console.ReadLine()) - 1;
                
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
            try
            {
                myGarden.ShowPlants();
                Console.Write("Введите индекс дерева для деконструкции: ");
                int index = int.Parse(Console.ReadLine()) - 1;
                
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