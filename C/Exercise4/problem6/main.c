#include <stdio.h>
#include <stdlib.h>

int main()
{
    float degreesInC;
    float degreesInF;

    printf("Enter degree in Celsius: ");
    scanf("%f", &degreesInC);

    degreesInF = (degreesInC * 1.8) + 32;
    printf("%f", degreesInF);
    return 0;
}
