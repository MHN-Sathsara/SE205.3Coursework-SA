namespace Braile_API.Model
{
    public class Circle : IShape
    {
        public double Radius { get; set; }

        public double PerimeterCal()
        {
            return Radius * Math.PI;
        }
    }
}
