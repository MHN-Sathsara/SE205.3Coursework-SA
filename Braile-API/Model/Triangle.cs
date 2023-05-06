namespace Braile_API.Model
{
    public class Triangle : IShape
    {
        public double Base { get; set; }
        public double Right { get; set; }
        public double Left { get; set; }
        
        public double PerimeterCal()
        {
            return Base + Right + Left;
        }
    }
}
