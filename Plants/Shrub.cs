namespace Plants
{
    public class Shrub : Plant
    {
        
        private Height _height;

        public new Height Height 
        { 
            get => _height;
            set
            {
                if (value.Meters < 0)
                    throw new ArgumentException("Высота куста не может быть отрицательной");
                if (value.Meters > 10) 
                    throw new ArgumentException("Высота куста не может превышать 10 метров");
                _height = value;
            }
        }

        public Shrub() : base()
        {
            Height = new Height(0.5);
        }


        public Shrub(TreeType type, Height height) : base(type, height)
        {
            Height = height;
        }

        public void Grow()
        {
            if (Height.Meters < 10)
            {
                Height = new Height(Height.Meters + 0.5);
                Console.WriteLine("Этот куст растет, милорд. Новая высота: " + Height);
            }
            else
            {
                Console.WriteLine("Куст достиг максимальной высоты");
            }
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Куст | Тип: {Type}, Высота: {Height}");
        }

        public override string ToString()
        {
            return $"Куст: {Type}, Высота: {Height}";
        }

        public static Shrub operator +(Shrub shrub1, Shrub shrub2)
        {
            return new Shrub 
            { 
                Type = shrub1.Type, 
                Height = new Height((shrub1.Height.Meters + shrub2.Height.Meters) / 2)
            };
        }

        public Shrub Clone()
        {
            return new Shrub
            {
                Type = this.Type,
                Height = new Height(this.Height.Meters)
            };
        }
    }
}