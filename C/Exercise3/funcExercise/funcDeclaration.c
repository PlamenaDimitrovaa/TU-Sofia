#include <stdio.h>

void print(int array[], unsigned len){
    int i;
    for(i =0; i<len; ++i){
        printf("%d\t", array[i]);
    }
    printf("\n");
}
