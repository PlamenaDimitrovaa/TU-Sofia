#include <stdio.h>
#include <stdlib.h>

int main()
{
    int my_variable, *my_pointer;
    my_variable = 5;
    my_pointer = &my_variable;
    printf("Address of my variable is: %x\n", &my_variable);
    printf("Value of my variable is: %d\n", *my_pointer);
    return 0;
}
