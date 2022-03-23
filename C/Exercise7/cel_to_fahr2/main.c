#include <stdio.h>
#include <stdlib.h>
#define STEP 20
int main()
{
    const int LOWER = 0;
    int upper = 300;
    float fahr;
    int cel;
    printf("Celsius to Fahrenheit convertor\n");
    printf("Celsius\tFahrenheit\n");
    for(cel = LOWER;cel <= upper;cel += STEP){
        fahr = cel * 9.0 / 5 + 32;
        printf("%d\t%g\n", cel, fahr);
    }
    return 0;
}
