#include <stdio.h>
#include <stdlib.h>

int main()
{
    int firstNumber = 10;
    int secondNumber = 2;
    int *firstAddress;
    int *secondAddress;
    firstAddress = &firstNumber;
    secondAddress = &secondNumber;
    printf("Result of their sum: %d\n", *firstAddress + *secondAddress);
    printf("Result of their subtraction: %d\n", *firstAddress - *secondAddress);
    printf("Result of their multiplication: %d\n", *firstAddress * *secondAddress);
    printf("Result of their division: %d\n", *firstAddress / *secondAddress);

    return 0;
}
