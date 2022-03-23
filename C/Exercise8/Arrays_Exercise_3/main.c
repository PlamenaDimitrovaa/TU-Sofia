#include <stdio.h>
#include <stdlib.h>

int main()
{
   float array[7];
   float sum;
   int i;
   for(i=0; i<7; i++)
   {
        printf("Insert a number: ");
        scanf("%f", &array[i]);
        sum += array[i];
   }

   float difference;
   float nearestNumber = array[0];
   float average = sum / 7.0;
   difference = abs(nearestNumber - average);
   int index;

   for(i=1; i<7; i++)
   {
       float currentDifference = abs(array[i] - average);

       if(difference > currentDifference)
       {
           difference = currentDifference;
           nearestNumber = array[i];
           index = i + 1;
       }
   }

    printf("Number nearest to the average sum: %f\n", nearestNumber);
    printf("Number index is: %d", index);

    return 0;
}
