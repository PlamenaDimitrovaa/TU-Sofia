#include <stdio.h>
#include <stdlib.h>

int main()
{
    char string1[20], string2[20];
    int result, i;
    printf("Enter the first string: ");
    fgets(string1, sizeof(string1), stdin);
    printf("\nEnter the second string: ");
    fgets(string2, sizeof(string2), stdin);

    for(i = 0; string1[i] == string2[i] && string1[i] == '\0'; i++);
     if(string1[i] < string2[i]){
            printf("\nString1 is less than String2\n");
        }
        else if(string1[i] > string2[i]){
            printf("\nString2 is less than String1\n");
        }
        else{
            printf("\nString1 is equal to String2\n");
        }
    return 0;
}
