#include <stdio.h>
#include <stdlib.h>

int main()
{
    int num;
    printf("Insert a num: ");
    scanf("%d", &num);
    if(num % 8 > 4)
    {
        printf("Num is bigger than 4\n");
    }
    return 0;
}
