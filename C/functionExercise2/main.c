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
    swap(a,b);
    return 0;
}

void swap(int* a, int* b)
{
    int temp = a;
    a = b;
    b = temp;
    printf("%d %d", a, b);
}
