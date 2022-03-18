#include <stdio.h>
#include <stdlib.h>

int main()
{
   int number;
   int points = 0;
   int bonusPoints = 0;
   printf("Insert number: ");
   scanf("%d", &number);

   if(number <= 100){
        bonusPoints = 5;
   }
   else if(number > 100){
        bonusPoints = number * 0.2;
   }
   else if(number > 1000){
        bonusPoints = number * 0.1;
   }

   if(number % 2 == 0){
        bonusPoints += 1;
   }

   if(number % 10 == 5){
        bonusPoints += 2;
   }

   number += bonusPoints;

   printf("%d\n", bonusPoints);
   printf("%d\n", number);
    return 0;
}
