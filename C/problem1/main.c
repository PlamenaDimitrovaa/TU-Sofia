#include <stdio.h>
#include <stdlib.h>

int main()
{
    int i;
    int j;

    for(i=1; i<=55; i++)
    {
        for(j=1; j<=i; j++)
        {
            printf("*");
        }

        printf("\n");
    }
    return 0;
}
