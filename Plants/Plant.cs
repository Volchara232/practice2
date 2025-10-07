namespace Plants
{
    public enum TreeType
    {
        Oak, Pine, Birch, Maple
    }
    public struct Height
    {
        public double Meters { get; set; }
        public Height(double meters)
        {
            Meters = meters;
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
        
        public void Deconstruct(out TreeType treeType, out Height height)
        {
            treeType = Type;
            height = Height;
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Тип: {Type}, Высота: {Height}");
        }
    }
}