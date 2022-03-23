#include <stdio.h>
#include <stdlib.h>

int main()
{
    float d;
    float p;
    float pi = 3.14;
    printf("Enter d: ");
    scanf("%f", &d);
    p = d * pi;
    printf("P = %.2f\n", p);
    return 0;
}
