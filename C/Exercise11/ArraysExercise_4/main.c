#include <stdio.h>
#include <stdlib.h>

int main()
{
    int n;
    int element;
    printf("Insert the number of elements: ");
    scanf("%d", &n);
    int array[n];
    int maxNumber;

    for(int i=0; i<n; i++)
    {
        printf("Insert element of array: ");
        scanf("%d", &element);
        array[i] = element;
        maxNumber = array[0];
        if(array[i] > maxNumber)
        {
            maxNumber = array[i];
        }
    }

    printf("%d\n", maxNumber);
    return 0;
}
