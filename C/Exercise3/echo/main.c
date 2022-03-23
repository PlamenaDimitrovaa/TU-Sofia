#include <stdio.h>
#include <stdlib.h>

int main()
{
//    char c;
//    while((c = getchar()) != EOF){
//        printf("%c", c);
//    }
//    return 0;
    char c = 'x';
    while(c != EOF){
        c = getchar();
        putchar(c);
    }
    return 0;
}
