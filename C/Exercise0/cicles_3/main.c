#include <stdio.h>
#include <stdlib.h>

int main()
{
    int i;
    int evenSum = 0;
    int oddSum = 1;
    int n;
    int n2;
    printf("Insert a number: ");
    scanf("%d", &n);
    printf("Insert a second number: ");
    scanf("%d", &n2);

    for(i=n; i<= n2; i++)
    {
        if(i % 2 == 0)
        {
             evenSum += i;
        }
        else if(i % 2 != 0)
        {
            oddSum *= i;
        }
    }

    printf("%d\n", evenSum);
    printf("%d\n", oddSum);
    return 0;
}
