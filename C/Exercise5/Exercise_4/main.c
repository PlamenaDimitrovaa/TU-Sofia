#include <stdio.h>
#include <stdlib.h>

int main()
{
    int first, second, third, sum;
    printf("Insert first time: ");
    scanf("%d", &first);

    printf("Insert second time: ");
    scanf("%d", &second);

    printf("Insert third time: ");
    scanf("%d", &third);

    sum = first + second + third;

    int minutes;
    int seconds;
    minutes = sum / 60;
    seconds = sum % 60;

    printf("%d:", minutes);
    printf("%02d", seconds);
    return 0;
}
