#include <stdio.h>
#include <stdlib.h>

int main()
{
    void swap(int* xp, int* yp)
    {
        int temp = *xp;
        *xp = *yp;
        *yp = temp;
    }
    int n;
    int element;
    printf("Insert the number of elements: ");
    scanf("%d", &n);
    int tem;

    int array[n];

    for(int i = 0; i<n; i++)
    {
        printf("Insert element: ");
        scanf("%d", &element);
        array[i] = element;
    }
    for(int i=0; i<n - 1; i++)
    {
        tem = i;
        for(int j = i + 1; j<n; j++)
        {
           if(array[j] < array[tem])
            {
                tem = j;
           }
        }
        swap(&array[tem], &array[i]);
    }

    for(int i=0; i<n; i++)
    {
        printf("%d\t", array[i]);
    }

    printf("\n");

    return 0;
}
