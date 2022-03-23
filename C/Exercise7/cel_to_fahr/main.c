#include <stdio.h>
#include <stdlib.h>
int main()
{
   unsigned lower, upper, step;
    float fahr;
    int cel;
    printf("Input lower: ");
    scanf("%d", &lower);
    printf("Input upper: ");
    scanf("%d", &upper);
    printf("Input step: ");
    scanf("%d", &step);
    printf("Celsius to Fahrenheit convertor\n");
    printf("C\tF\n");

    for(cel = lower; cel <= upper; cel += step){
    fahr = cel * 9.0 / 5 + 32;
    printf("%d\t%g\n", cel, fahr);
    }
    return 0;
}
