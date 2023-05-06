namespace Braile_API.Model
{
    public class ShapeFactory
    {
        //This contains the methods to select the shapes and give the appropriate response
        //This acts as a factory that contains all the methods
        //Factory Method

        public static IShape CreateShape(string shape,double[] dimentions)
        {
            switch(shape)
            {
                case "Circle":

                    Circle circle = new()
                    {
                        Radius = dimentions[0]
                    };
                    return circle ;

                case "Triangle":

                    Triangle triangle = new()
                    {
                        Base = dimentions[0],
                        Right = dimentions[1],
                        Left = dimentions[2]
                    };
                    return triangle ;

                case "Rectangle":

                    Rectangle rectangle = new()
                    {
                        Width = dimentions[0],
                        Length = dimentions[1]
                    };
                    return rectangle ;

                default:
                    throw new ArgumentException("Invalid Shape Selected");



            }
        }
    }
}
