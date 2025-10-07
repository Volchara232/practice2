namespace Gardens {

public class Garden : IGarden
    {
        private List<Plants.Plant> plants = new List<Plants.Plant>();

        public void AddPlant(Plants.Plant plant)
        {
            plants.Add(plant);
            Console.WriteLine($"Растение типа {plant.Type} добавлено в сад");
        }
        public void ShowPlants()
        {
            if (plants.Count == 0)
            {
                Console.WriteLine("В саду пока нет растений");
                return;
            }

            Console.WriteLine("=== Растения в саду ===");
            for (int i = 0; i < plants.Count; i++)
            {
                Console.Write($"{i + 1}. ");
                plants[i].DisplayInfo();
            }
        }
        public void CareForTree(int index)
        {
            if (index >= 0 && index < plants.Count && plants[index] is Plants.Tree tree)
            {
                tree.Care();
            }
            else
            {
                Console.WriteLine("Дерево с таким индексом не найдено");
            }
        }
        public void HarvestFromTree(int index)
        {
            if (index >= 0 && index < plants.Count && plants[index] is Plants.Tree tree)
            {
                tree.Harvest();
            }
            else
            {
                Console.WriteLine("Дерево с таким индексом не найдено");
            }
        }
    }
}