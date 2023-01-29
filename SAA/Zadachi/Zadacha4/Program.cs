namespace Zadacha4
{

 //   Даден е двумерен масив A[n x n]. Да се генерира едномерен масив B със сортирани:
 //   минималните по стойност елементи от съответните редове на масив А, сумата на
 //   елементите по главният диагонал на масив A и сумата на елементите по второстепенния диагонал
 //   и броят на отрицателните елементи
 //   по вторичният диагонал на масив А.

    internal class Program
    {
        static void Main(string[] args)
        {

            int[,] a = new int[,]
            {
                { 1, 2, 5, 6, 14 },
                { 2, 3, 4, -9, 0},
                { 8, 4, 6, 1, 62},
                { 5, -3, 5, 0, 54},
                { 9, 5, 9, 89, 11},
            };

            int[] B = new int[8];
            int sum1 = 0;
            int sum2 = 0;
            int count = 0;

            for (int i = 0; i < a.GetLength(0); i++)
            {
                int min = a[i, 0];
                sum1 += a[i, i]; //сумата на главния диагонал
                sum2 += a[i, a.GetLength(0) - 1 - i]; //сумата на второстепенния диагонал

                for (int j = 0; j < a.GetLength(1); j++)
                {
                    if(min > a[i, j])
                    {
                        min = a[i, j];
                    }

                    if (i + j == a.GetLength(0) - 1 && a[i, j] < 0)
                    {
                        count++;
                    }
                }

                B[i] = min;
            }

            B[5] = sum1;
            B[6] = count;
            B[7] = sum2;

            for (int i = 0; i < B.Length; i++)
            {
                Console.WriteLine(B[i]);
            }
        }
    }
}