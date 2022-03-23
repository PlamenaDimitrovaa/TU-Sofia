#include <stdio.h>
#include <stdlib.h>

int main()
{
    int number;
    printf("Insert a number: ");
    scanf("%d", &number);
    if(number > 6)
    {
        printf("Number is bigger than 6!\n");
    }
    else if(number == 6)
    {
        printf("Number is equal to 6!\n");
    }
    else
    {
         printf("Number is lower than 6!\n");
    }
    return 0;
}
