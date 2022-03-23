#include <stdio.h>
#include <stdlib.h>

int main()
{
    int x = 3, y = 5, z;
    z = ++y + x++;
    printf("x=%d, y=%d, z=%d\n",x,y,z);

    return 0;
}
