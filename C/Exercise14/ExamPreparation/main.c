#include <stdio.h>
#include <stdlib.h>

struct Artist{
    char name[50];
    int age;
    char country[50];
    double income;
    int numOscars;
};

int main()
{
    Artist artists[10];
    return 0;
}

void AddNewArtist(Artist a){
    for(let i = 0; i < 10; i++){
        artists[i] = a;
    }
}
