#include <stdio.h>
#include <stdlib.h>

int main()
{
    char text[50];
    int count = 0;
    printf("Enter text: ");
    fgets(text, sizeof(text), stdin);
    printf("%s", text);

    for(int i = 0; i < strlen(text); i++){
            count = 0;
            printf("%c\n", text[i]);
            printf("%d\n", count);
            for(int j = 0; j <= strlen(text); j++){
                if(text[i] == text[j]){
                     count++;
        }
            }
    }
    return 0;
}
