#include <stdio.h>
#include <stdlib.h>

int main()
{
    int i;
    int n;
    int n2;
    int sum = 0;
    printf("Insert a number: ");
    scanf("%d", &n);
    printf("Insert a second number: ");
    scanf("%d", &n2);
    for(i=n + 1; i< n2; i++)
    {
       sum += i;
    }

    printf("%d\n", sum);
    return 0;
}
