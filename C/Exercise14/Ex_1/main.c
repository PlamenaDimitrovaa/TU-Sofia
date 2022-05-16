#include <stdio.h>
#include <stdlib.h>

int main()
{
    double chairPrice = 13.99;
    double tableFor8People = 42;
    double packageOf6Cups = 5.98;
    double packageOf6Dishes = 21.02;

    int countOfGuests;

    int tableCount = 0;
    int chairsCount = 0;
    int cupsCount = 0;
    int dishesCount = 0;

    double result;

    printf("Insert the number of guests: ");
    scanf("%d", &countOfGuests);

    char command[10];
    printf("Insert commands: ");
    scanf("%s", &command);

    while(strcmp(command, "PARTY!")!= 0)
    {
        if(strcmp(command, "Table") == 0){
            result += tableFor8People;
            tableCount++;
        } else if(strcmp(command, "Chair") == 0){
            result += chairPrice;
            chairsCount++;
        } else if(strcmp(command, "Cups") == 0){
            result += packageOf6Cups;
            cupsCount++;
        } else if(strcmp(command, "Dishes") == 0){
            result += packageOf6Dishes;
            dishesCount++;
        }

        scanf("%s", command);
    }

    int neededTables = 0;
    int neededCups = 0;
    int neededChairs = 0;
    int neededDishes = 0;

    printf("%f", result);

    if(countOfGuests > chairsCount){
        neededChairs = countOfGuests - chairsCount;
        printf("\nNeeded chairs: %d", neededChairs);
    }

    if(countOfGuests % 8 > 0){

        neededTables = ceil(countOfGuests / 8);

        if(tableCount < neededTables - tableCount){  //?
            printf("\nNeeded tables: %d", neededTables - tableCount);
        }
    }

    if(countOfGuests % 6 > 0){

        neededCups = ceil(countOfGuests / 6);

        if(cupsCount < neededCups){
            printf("\nNeeded cups: %d", neededCups - cupsCount);
        }

        neededDishes = ceil(countOfGuests / 6);

        if(dishesCount < neededDishes){
            printf("\nNeeded dishes: %d", neededDishes - dishesCount);
        }

    }
    return 0;
}
