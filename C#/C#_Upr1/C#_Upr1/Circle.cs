namespace C__Upr1
{
    public class Circle : Shape, IElliptical
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public override double GetPerimeter()
        {
            return 2 * Math.PI * Radius;
        }

        public override double GetArea()
        {
            return Math.PI * Radius * Radius;
        }

        public bool IsElliptical()
        {
            return true;
        }
    }
}
