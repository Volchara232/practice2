using Plants;
namespace Plants
{
     public class Tree : Plant
    {
        public int Age { get; set; }
        
        public void Harvest()
        {
            Console.WriteLine("Урожай собран, милорд.");
        }
        
        public void Care()
        {
            Console.WriteLine("Дерево ухожено, милорд");
        }
        
        public void Cut()
        {
            Console.WriteLine("Дерево срублено, милорд");
        }
        
        public void Touch()
        {
            Console.WriteLine("Дерево поглажено, милорд");
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Дерево | Тип: {Type}, Высота: {Height}, Возраст: {Age} лет");
        }
    }
}