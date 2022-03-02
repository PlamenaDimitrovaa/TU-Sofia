#include <stdio.h>
#include <stdlib.h>

int main()
{
   float degree;
   float radiants;
   printf("Enter degree: ");
   scanf("%f", &degree);
   radiants = (3.14/180) * degree;
   printf("%f", radiants);
    return 0;
}
