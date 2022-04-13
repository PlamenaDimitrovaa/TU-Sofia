#include <stdio.h>
#include <stdlib.h>

int main()
{
    char name[20];
    printf("Enter name: ");
    fgets(name, sizeof(name), stdin);
    printf("%s", name);
    int count = 0;
    for(int i = 1; i < strlen(name); i++){
        count++;
    }
    printf("%d", count);
    return 0;
}
