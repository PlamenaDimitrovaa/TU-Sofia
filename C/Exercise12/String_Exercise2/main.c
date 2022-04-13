#include <stdio.h>
#include <stdlib.h>

int main()
{
    int count = 0;
    char sequence[40];
    printf("Enter a sequence: ");
    fgets(sequence, sizeof(sequence), stdin);
    printf("%s", sequence);
    for(int i = 0; sequence[i] != '\0'; i++){
        if(sequence[i] == ' ' && sequence[i + 1] != ' '){
            count++;
        }
    }
    printf("%d\n", count + 1);
    return 0;
}
