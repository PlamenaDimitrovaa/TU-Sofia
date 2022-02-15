#include <stdio.h>
#include <stdlib.h>
#include <time.h>

#define SIZE 30

int main()
{
    int i;
    short sum = 0;
    short num;
    srand(time(NULL));
    for(i = 0;i < SIZE; ++i){
        num = (short)(rand()%50-25);
        printf("%hi", num);
        sum += num;
    }
    printf("\nSum = %hi\n", sum);
    return 0;
}
