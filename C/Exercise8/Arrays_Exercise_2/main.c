#include <stdio.h>
#include <stdlib.h>

int main()
{
   float array[5];
   float sum;
   int i;
   for(i=0; i<5; i++){
        printf("Insert a number: ");
        scanf("%f", &array[i]);
        sum += array[i];
   }

   float average = sum / 5.0;

    printf("Average sum: %f", average);
    return 0;
}
