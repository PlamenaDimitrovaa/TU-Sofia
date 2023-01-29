namespace Zadacha2
{
    internal class Program
    {
        //Съставете алгоритъм и процедура:
        //за обработка на масив A(n) (n е нечетно число) от цели числа в диапазона от 1 до 100.
        //Процедурата да определи средно аритметичните S1 и S2 от най-малкия,
        //най-големия и средния по големина елементи на масива (S1),
        //от всички елементи на сортирания масив,
        //намиращи се на четни позиции в него (S2).
        //Задачата да бъде решена с алгоритъм с линейна сложност.

        static void Main(string[] args)
        {
            int[] arr = { 11, 2, 18, 45, 18 };

            int s1 = 0;
            int s2 = 0;
            int count = 0;

            bubbleSort(arr);

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }

            s1 = (arr[0] + arr[arr.Length - 1] + arr[arr.Length / 2])/ 3;
            
            for (int i = 0; i < arr.Length; i++)
            {
                if(i % 2 == 0) 
                {
                    s2 += arr[i];
                    count++;
                }
            }

            s2 = s2 / count;

            Console.WriteLine("S1: " + s1);
            Console.WriteLine("S2: " + s2);

        }

        static void bubbleSort(int[] arr)
        {
            bool isSorted = false;
            int count = 0;

            while (!isSorted)
            {
                isSorted = true;

                for (int i = 0; i < arr.Length - 1 - count; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        int temp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = temp;
                        isSorted = false;
                    }
                }

                count++;
            }  
        }
    }
}