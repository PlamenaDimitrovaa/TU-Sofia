#include <stdio.h>
#include <stdlib.h>

int main()
{
    int a;
    int b;
    printf("Enter a: ");
    scanf("%d", &a);
    printf("Enter b: ");
    scanf("%d", &b);
    int area = a * b;
    printf("Area: %d", area);
    return 0;
}
