#include <stdio.h>
#include <stdlib.h>

int main()
{
    int matrix[5][5] =
    {
        {1, 2, 3, 4, 5},
        {3, 2, 1, 8, 9},
        {4, 5, 6, 7, 3},
        {4, 5, 6, 7, 3},
        {1, 2, 3, 4, 5}
    };
    int i, j;
    for(i=0; i<5; i++)
    {
        for(j=0; j<5; j++)
        {
            printf("%d\t", matrix[i][j]);
        }

        printf("\n");
    }

    printf("\nPrincipal diagonal: ");

    for(i=0; i<5; i++)
    {
       for(j=0; j<5; j++)
        {
            if(i==j)
            {
               printf("%d\t", matrix[i][j]);
            }
        }
    }

    printf("\nSecondary diagonal: ");
    for(i=0; i<5; i++)
    {
       for(j=0; j<5; j++)
        {
            if((i+j) == (5 - 1))
            {
               printf("%d\t", matrix[i][j]);
            }
        }
    }

    printf("\nNumbers up to the principal diagonal: ");

    for(i=0; i<5; i++)
    {
       for(j=0; j<5; j++)
        {
            if(j>i)
            {
                printf("%d\t", matrix[i][j]);
            }
        }
    }

    printf("\nNumbers under the secondary diagonal: ");

    for(i=0; i<5; i++)
    {
       for(j=0; j<5; j++)
        {
            if(i>j)
            {
                printf("%d\t", matrix[i][j]);
            }
        }
    }
    return 0;
}
