#include <stdio.h>
#include <stdlib.h>

int main()
{
    char c;
    int nWhite = 0;
    int nOther = 0;
    int nDigits[] = {0,0,0,0,0,0,0,0,0,0};
    int i;
    while((c = getchar()) != EOF){
        if(c >= '0' && c <= '9'){
            nDigits[c - '0']++;
        }
        else if(c <= ' '){
            ++nWhite;
        }
        else{
            nOther++;
        }
    }
    for(i=0;i<10;++i){
        printf("%d=>%d ", i, nDigits[i]);
    }
    printf("\nWhite spaces: %d\tOther symbols: %d\n", nWhite, nOther);
    return 0;
}
