#include <stdio.h>
#include <stdlib.h>
#define TRUE 1

int main()
{
    short temp;
    short sum = 0;
    short counter = 0;

    do{
        printf("Temp: ");
        scanf("%hi", &temp);
        if(!temp){
            break;
        }
        sum += temp;
        counter++;
    }
    while(TRUE);
        if(!counter){
            printf("No data...\n");
        }
        else{
            printf("Average temp: %g\n", (float)sum/counter);
        }
    return 0;
}
