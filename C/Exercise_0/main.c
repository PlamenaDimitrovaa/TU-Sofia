#include <stdio.h>
#include <stdlib.h>

int main()
{
    int a,b;

    printf("Insert a: ");
    scanf("%d", &a);

    printf("Insert b: ");
    scanf("%d", &b);

    ReturnTheBiggerNumber(a, b);

    return 0;
}

int ReturnTheBiggerNumber(int a, int b){
    if(a > b){
        printf("%d\n", a);
    }
    else if(b > a){
         printf("%d\n", b);
    }
    else{
            printf("Numbers are equal\n");
    }

}
