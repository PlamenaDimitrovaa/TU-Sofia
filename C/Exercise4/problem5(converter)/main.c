#include <stdio.h>
#include <stdlib.h>

int main()
{
    float inches;
    char text[10];
    float result;

    printf("Insert inches: ");
    scanf("%f", &inches);
    printf("Choose an option: (mm, cm, dm ,m): ");
    scanf("%s", &text);

    if(strcmp(text, "mm") == 0)
    {
        result = inches * 25.4;
    }
    else if(strcmp(text, "cm") == 0)
    {
        result = inches * 2.54;
    }
     else if(strcmp(text, "dm") == 0)
    {
        result = inches * 0.254;
    }
     else if(strcmp(text, "m") == 0)
    {
        result = inches * 0.0254;
    }

    printf("Result is: ");
    printf("%f", result);

    return 0;
}
