namespace C__Upr1
{
    public class Rectangle : Shape, IElliptical
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public override double GetPerimeter()
        {
            return 2 * (Width + Height);
        }

        public override double GetArea()
        {
            return Width * Height;
        }

        public bool IsElliptical()
        {
            return false;
        }
    }
}
