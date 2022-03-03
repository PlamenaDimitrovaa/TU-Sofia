#include <stdio.h>
#include <stdlib.h>

int main()
{
    void IsTheNumberEven(int number);
    void IsTheNumberOdd(int number);
    int number;
    printf("Enter a number: ");
    scanf("%d", &number);
    IsTheNumberEven(number);
    IsTheNumberOdd(number);
    return 0;
}
