#include <stdio.h>
#include <stdlib.h>
#include <limits.h>

#define FALSE !TRUE
#define TRUE 1
#define BOOLEAN int

int main()
{
    short temp;
    short sum = 0;
    short cnt = 0;
    short minTemp;
    short maxNegTemp = SHRT_MIN;
    BOOLEAN isInit = FALSE;

    do{
        printf("Temp: ");
        scanf("%hi", &temp);
        if(!temp){
            break;
        }
        if(!isInit){
            minTemp = temp;
            isInit = !isInit;
        }
        else if(minTemp > temp){
            maxNegTemp = temp;
        }
        sum += temp;
        cnt++;
    }
    while(TRUE);
        if(!cnt){
            printf("No data...\n");
        }
        else{
            printf("Average temp: %g\n", (float)sum/cnt);
            printf("Min temperature: %hi\n", minTemp);
            printf("Max Negative Temperature: %hi\n", maxNegTemp);
        }
    return 0;
}
