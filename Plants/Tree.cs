

namespace Plants
{
    public class Tree : Plant
    {
        private int age;

        public int Age 
        { 
            get => age;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Возраст не может быть отрицательным");
                if (value > 5000)
                    throw new ArgumentException("Возраст не может превышать 5000 лет");
                age = value;
            }
        }


        public Tree() : base()
        {
            Age = 1;
        }

        public Tree(TreeType type, Height height, int age) : base(type, height)
        {
            Age = age;
        }

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

        public override string ToString()
        {
            return $"Дерево: {Type}, Высота: {Height}, Возраст: {Age} лет";
        }

        public static Tree operator +(Tree tree1, Tree tree2)
        {
            return new Tree 
            { 
                Type = tree1.Type, 
                Height = new Height((tree1.Height.Meters + tree2.Height.Meters) / 2),
                Age = (tree1.Age + tree2.Age) / 2
            };
        }

        public Tree Clone()
        {
            return new Tree
            {
                Type = this.Type,
                Height = new Height(this.Height.Meters),
                Age = this.Age
            };
        }
    }
}