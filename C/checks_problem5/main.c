#include <stdio.h>
#include <stdlib.h>

int main()
{
    int n;
    printf("Insert a number for a day of the week: ");
    scanf("%d", &n);

    if(n == 1)
    {
        printf("Monday.\n");
    }
    else if(n == 2)
    {
        printf("Tuesday.\n");
    }
    else if(n == 3)
    {
        printf("Wednesday.\n");
    }
    else if(n == 4)
    {
        printf("Thursday.\n");
    }
    else if(n == 5)
    {
        printf("Friday.\n");
    }
    else if(n == 6)
    {
        printf("Saturday.\n");
    }
    else if(n == 7)
    {
        printf("Sunday.\n");
    }
    else
    {
        printf("It's an invalid day of the week!\n");
    }


    switch(n)
    {
        case 1: printf("Monday.\n"); break;
        case 2: printf("Tuesday.\n"); break;
        case 3: printf("Wednesday.\n"); break;
        case 4: printf("Thursday.\n"); break;
        case 5: printf("Friday.\n"); break;
        case 6: printf("Saturday.\n"); break;
        case 7: printf("Sunday.\n"); break;
        default: printf("It's an invalid day of the week!\n"); break;
    }
    return 0;
}
