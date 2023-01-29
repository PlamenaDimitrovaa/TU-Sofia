namespace Zadacha5
{
    internal class Program
    {
        //Обхождане на масив и изкарване на броя на четните числа, които са по-големи от 100 и по-малки от 10 000.
        static void Main(string[] args)
        {
            int[] array = { 20, 18, 72, 96, 6, 5, 10, 12, 14, 16, 11000, 150, 120 };
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0 && array[i] < 10000 && array[i] > 100)
                {
                    count++;
                }
            }

            Console.WriteLine(count);
        }
    }
}