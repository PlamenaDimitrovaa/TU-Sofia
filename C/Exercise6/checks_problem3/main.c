#include <stdio.h>
#include <stdlib.h>

int main()
{
    int i;
    int num1, num2, num3;
    printf("Insert num1: ");
    scanf("%d", &num1);
    printf("Insert num2: ");
    scanf("%d", &num2);
    printf("Insert num3: ");
    scanf("%d", &num3);
    int minNumber;
    if(num1 < num2 && num1 < num3)
    {
        minNumber = num1;
    }
    else if(num2 < num1 && num2 < num3)
    {
        minNumber = num2;
    }
    else if(num3 < num1 && num3 < num2)
    {
        minNumber = num3;
    }

    printf("%d", minNumber);
    return 0;
}
