#include <stdio.h>
#include <stdlib.h>
#include <time.h>

#define SIZE 30
#define BOOLEAN int
#define FALSE 0

int main()
{
    long i;
    long sum = 0;
    long num;
    long minEvenNum;
    BOOLEAN isInit = FALSE;

    srand(time(NULL));

    for(i = 0; i < SIZE; ++i){
        num = (long)(rand()%50-25);
        printf("%li", num);
        sum += num;
        if(num % 2 == 0){
            if(!isInit){
                minEvenNum = num;
                isInit = !isInit;
            }
            else if(minEvenNum > num){
                minEvenNum = num;
            }
        }
    }
    printf("\nSum = %li\n", sum);
    if(!isInit){
        printf("No even numbers...\n");
    }
    else{
        printf("Min even number: %li\n", minEvenNum);
    }
    return 0;
}
