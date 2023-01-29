namespace Zadachi
{
    internal class Program
    {

        //Съставете алгоритъм и процедура: за обединяване на три целочислени масива A[1..m], B[1..n] и C[1..p] в нов масив D,
        //включващ само еднаквите елементи и на трите масива.
        //Във всеки масив има само различни елементи, като обхватът им е от 1 до 100. 
        //Задачата да бъде решена с алгоритъм с линейна сложност.

        static void Main(string[] args)
        {
            int[] arr1 = { 1, 5, 4, 9 };
            int[] arr2 = { 1, 6, 4, 15, 3 };
            int[] arr3 = { 4, 1, 17, 89, 56 };

            int[] result = new int[arr1.Length];

            getArray(arr1, arr2, result, 0, 0, 0);

            int[] result1 = new int[arr1.Length];

            getArray(result, arr3, result1, 0, 0, 0);

            for (int i = 0; i < result1.Length; i++) 
            {
                Console.WriteLine(result1[i]);
            }
        }

        private static void getArray(int[] arr, int[] arr2, int[] result, int idxArr1, int idxArr2, int idxResult) 
        {
            if (arr.Length <= idxArr1 || arr2.Length <= idxArr2)
            {
                return;
            }

            if (idxArr1 == arr.Length - 1)
            {
                getArray(arr, arr2, result, 0, idxArr2 + 1, idxResult);
            }

            if (arr[idxArr1] == arr2[idxArr2])
            {
                result[idxResult] = arr[idxArr1];
                getArray(arr, arr2, result, idxArr1 + 1, idxArr2, idxResult + 1);
            }

            if (arr[idxArr1] != arr2[idxArr2])
            {
                getArray(arr, arr2, result, idxArr1 + 1, idxArr2, idxResult);
            }
        }
    }
}