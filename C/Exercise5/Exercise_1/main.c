#include <stdio.h>
#include <stdlib.h>

int main()
{
    int hour;
    int minutes;
    printf("Insert an hour: ");
    scanf("%d", &hour);

    printf("Insert minutes: ");
    scanf("%d", &minutes);
    minutes += 15;

    if(minutes >= 60){
        hour++;
        minutes -= 60;
    }

    if(hour >= 24){
        hour -= 24;
    }

    printf("%02d:", hour);
    printf("%02d", minutes);
    return 0;
}
