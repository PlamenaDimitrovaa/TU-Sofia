#include <stdio.h>
#include <stdlib.h>

int main()
{
    int height = 5;
    int width = 10;

    int i;
    int j;

    for(i=0; i!=height; i++)
    {
        for(j=0; j!=width; j++)
        {
            if((i==0) || (i==height - 1) || (j==width - 1) || (j==0))
            {
                printf("-");
            }
            else
            {
                printf(" ");
            }
        }
     printf("\n");
    }
    return 0;
}
