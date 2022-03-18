#include <stdio.h>
#include <stdlib.h>

int main()
{
     int a, b, c;
   printf("Insert a: ");
   scanf("%d", &a);

    printf("Insert b: ");
    scanf("%d", &b);

    printf("Insert c: ");
    scanf("%d", &c);

    if(a == b && b == c){
        printf("YES");
    }
    else{
        printf("NO");
    }
    return 0;
}
