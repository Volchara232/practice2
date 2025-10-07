using Plants;
namespace Plants
{
     public class Shrub : Plants.Plant
    {
        public void Grow()
        {
            Console.WriteLine("Этот куст растет, милорд");
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Куст | Тип: {Type}, Высота: {Height}");
        }
    }
}