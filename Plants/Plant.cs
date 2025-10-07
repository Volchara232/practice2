namespace Plants
{
    public enum TreeType
    {
        Oak, Pine, Birch, Maple
    }

    public struct Height
    {
        private double meters;

        public double Meters 
        { 
            get => meters;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Высота не может быть отрицательной");
                if (value > 150)
                    throw new ArgumentException("Высота не может превышать 150 метров");
                meters = value;
            }
        }

        public Height(double meter)
        {
            if (meter < 0)
                throw new ArgumentException("Высота не может быть отрицательной");
            if (meter > 150)
                throw new ArgumentException("Высота не может превышать 150 метров");
            meters = meter;
        }

        public override string ToString()
        {
            return $"{Meters:F1} м";
        }
    }

    public class Plant
    {
        public Height Height { get; set; }
        public TreeType Type { get; set; }

        public const int MAX_LIFESPAN = 5000; 

        public Plant()
        {
            Height = new Height(1.0); 
            Type = TreeType.Oak; 
        }

        public Plant(TreeType type, Height height)
        {
            Type = type;
            Height = height;
        }

        public void Deconstruct(out TreeType treeType, out Height height)
        {
            treeType = Type;
            height = Height;
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Тип: {Type}, Высота: {Height}");
        }

        public override string ToString()
        {
            return $"Растение: {Type}, Высота: {Height}";
        }
    }
}