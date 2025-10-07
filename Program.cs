using System;
using System.Collections.Generic;
using Plants;
using Gardens;
namespace Program
{
    
    class Program
    {
        public void Menu()
        static void Main(string[] args)
        {
           
            Gardens.Garden myGarden = new Gardens.Garden();

            
            Plants.Tree oak = new Plants.Tree { Type = TreeType.Oak, Height = new Height(15.5), Age = 10 };
            Plants.Tree pine = new Plants.Tree { Type = TreeType.Pine, Height = new Height(20.2), Age = 15 };

            
            Plants.Shrub birchShrub = new Plants.Shrub { Type = TreeType.Birch, Height = new Height(2.1) };
            Plants.Shrub mapleShrub = new Plants.Shrub { Type = TreeType.Maple, Height = new Height(1.8) };

           
            myGarden.AddPlant(oak);
            myGarden.AddPlant(pine);
            myGarden.AddPlant(birchShrub);
            myGarden.AddPlant(mapleShrub);

            Console.WriteLine();

          
            myGarden.ShowPlants();

            Console.WriteLine();

            
            myGarden.CareForTree(0);
            myGarden.HarvestFromTree(1);

            Console.WriteLine();

            birchShrub.Grow();

            Console.WriteLine();

           
            var (type, height) = oak;
            Console.WriteLine($"Деконструктор: Тип - {type}, Высота - {height}");
        }
    }
}