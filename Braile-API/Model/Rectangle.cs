namespace Braile_API.Model
{
    public class Rectangle : IShape
    {
        public double Length { get; set; }
        public double Width { get; set; }

        public double PerimeterCal()
        {
            return (2 * Length) + (2 * Width);
        }
    }
}
