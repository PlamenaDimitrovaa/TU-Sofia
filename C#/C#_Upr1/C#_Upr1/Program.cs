namespace C__Upr1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Rectangle rect = new Rectangle(5, 10);
            rect.Color = Shape.Colors.Red;
            Console.WriteLine($"Rectangle Area: {rect.GetArea()}, Perimeter: {rect.GetPerimeter()}, Color: {rect.Color}");

            Circle circle = new Circle(7);
            circle.Color = Shape.Colors.Blue;
            Console.WriteLine($"Circle Area: {circle.GetArea()}, Perimeter: {circle.GetPerimeter()}, Color: {circle.Color}");

            Square square = new Square(4);
            square.Color = Shape.Colors.Green;
            Console.WriteLine($"Square Area: {square.GetArea()}, Perimeter: {square.GetPerimeter()}, Color: {square.Color}");

            Console.WriteLine($"Static Square Area Calculation: {Square.CalculateArea(4)}");

            if (Triangle<int>.GetInstance(3, 4, 5, out var triangle))
            {
                Console.WriteLine("Triangle created successfully.");
            }
            else
            {
                Console.WriteLine("Failed to create Triangle.");
            }
        }
    }
}
