#include <stdio.h>
#include <stdlib.h>

int main()
{
    int n;
    int element;
    printf("Insert the number of elements: ");
    scanf("%d", &n);

    int array[n];

    for(int i=0; i<n; i++)
    {
        printf("Insert element of array: ");
        scanf("%d", &element);
        array[i] = element;
    }

    for(int i=n-1; i>=0; i--)
    {
        printf("%d\t", array[i]);
    }

    return 0;
}
