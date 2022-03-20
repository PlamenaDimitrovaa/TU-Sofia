#include <stdio.h>
#include <stdlib.h>

int main()
{
   int array[5];
   int biggest;
   int i;
   for(i=0; i<5; i++){
        printf("Insert a number: ");
        scanf("%d", &array[i]);
        biggest = array[0];
        if(biggest < array[i]){
            biggest = array[i];
        }
   }

   printf("Biggest number: %d", biggest);
    return 0;
}
