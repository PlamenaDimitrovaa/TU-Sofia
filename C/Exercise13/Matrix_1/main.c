#include <stdio.h>
#include <stdlib.h>

int main()
{
    int matrix[3][5] = {
        {5, 4, 3, 2, 1},
        {6, 5, 4, 3, 2},
        {7, 6, 5, 4, 3}
    };

    int isTrue = 1;

    for(int i = 0; i < 3; i++)
    {
        if(i + 1 >= 3)
        {
            break;
        }

        for(int j = 0; j < 5; j++)
        {
            if(j + 1 >= 5)
            {
                break;
            }

            if(matrix[i][j] < matrix[i + 1][j] && matrix[i][j] > matrix[i][j + 1])
            {
                isTrue = 1;
            }
            else
            {
                isTrue = 0;
                break;
            }
        }

        if(isTrue == 0)
        {
            break;
        }
    }

    if(isTrue == 1)
    {
        printf("TRUE");
    }
    else
    {
        printf("FALSE");
    }

    return 0;
}
