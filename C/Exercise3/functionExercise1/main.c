#include <stdio.h>
#include <stdlib.h>

int main()
{
    int number;
    printf("Enter a number(1-square; 2-rectangle; 3-triangle; 4-circle): ");
    scanf("%d", &number);

    switch(number)
    {
        case 1:
            SquareArea();
            break;
        case 2:
            RectangleArea();
            break;
        case 3:
            TriangleArea();
            break;
        case 4:
            CircleArea();
            break;
        default:
            printf("Invalid number!");
            break;
    }
    return 0;
}

void SquareArea()
{
    printf("SQUARE");
    float a;
    float result;
    printf("\nEnter a: ");
    scanf("%f", &a);
    result = a * a;
    printf("%f", result);
}

void RectangleArea()
{
    printf("RECTANGLE");
    float a;
    float b;
    float result;
    printf("\nEnter a: ");
    scanf("%f", &a);
    printf("Enter b: ");
    scanf("%f", &b);
    result = a * b;
    printf("%f", result);
}

void TriangleArea()
{
    printf("TRIANGLE");
    float a;
    float b;
    float result;
    printf("\nEnter a: ");
    scanf("%f", &a);
    printf("Enter b: ");
    scanf("%f", &b);
    result = (a * b) / 2;
    printf("%f", result);
}

void CircleArea()
{
    printf("CIRCLE");
    float r;
    float result;
    printf("\nEnter r: ");
    scanf("%f", &r);
    result = 3.14 * (r * r);
    printf("%f", result);
}
