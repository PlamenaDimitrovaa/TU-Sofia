#include <stdio.h>
#include <stdlib.h>

int main()
{
   int array[5];
   int sum;
   int i;
   for(i=0; i<5; i++){
        printf("Insert a number: ");
        scanf("%d", &array[i]);
        sum += array[i];
   }

   printf("Sum: %d", sum);
    return 0;
}
