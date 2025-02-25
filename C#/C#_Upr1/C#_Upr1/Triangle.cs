namespace C__Upr1
{
    public class Triangle<T> where T : struct
    {
        public T SideA { get; }
        public T SideB { get; }
        public T SideC { get; }

        private Triangle(T sideA, T sideB, T sideC)
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        public static bool GetInstance(T sideA, T sideB, T sideC, out Triangle<T> triangle)
        {
            if (!(sideA is int || sideA is float))
            {
                triangle = null;
                return false;
            }

            dynamic a = sideA, b = sideB, c = sideC;
            if (a + b > c && a + c > b && b + c > a)
            {
                triangle = new Triangle<T>(sideA, sideB, sideC);
                return true;
            }

            triangle = null;
            return false;
        }
    }

}
