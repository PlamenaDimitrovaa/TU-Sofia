#include <stdio.h>
#include <stdlib.h>

int main()
{
    float valute;
    float result;
    float levove;
    printf("Enter the sum in lv: ");
    scanf("%f", &levove);

    printf("Enter a valute 1, 2 or 3: 1=dollars; 2 =euro; 3=paunds: ");
    scanf("%f", &valute);

    if(valute == 1)
    {
        result = levove * 1.77;
    }
    else if(valute == 2)
    {
        result = levove * 1.96;
    }
    else if(valute == 3)
    {
        result = levove * 2.34;
    }

    printf("%f", result);
    return 0;
}
