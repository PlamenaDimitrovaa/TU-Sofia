namespace Zadacha3
{
    internal class Program
    {
        //Намиране на най - голям общ делител на масив от числа, след което да се сортират. !!!

        static void Main(string[] args)
        {
            Console.WriteLine(nod(60, 6));
        }

        private static int min(int a, int b)
        {
            if(a > b)
            {
                return b;
            }

            return a;
        }

        private static int nod(int c, int d)
        {
            if (c == d)
            {
                return c;
            }

            return nod(Math.Abs(c - d), min(c, d));
        }
    }
}