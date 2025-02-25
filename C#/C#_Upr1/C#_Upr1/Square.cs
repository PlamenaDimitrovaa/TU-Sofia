namespace C__Upr1
{
    public class Square : Rectangle
    {
        public Square(double side) : base(side, side) { }

        public static double CalculateArea(double side)
        {
            return side * side;
        }
    }
}
