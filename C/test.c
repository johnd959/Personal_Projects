#include <stdio.h>
#include <stdlib.h>
int max = 100;


int main (void)
{
    char *name = malloc(max * sizeof(char));
    char *buffer = malloc(max * sizeof(char));
    int end = 0;
    do 
    {
        printf("Hello, what is your name?: ");
        _flushall();
        fgets(buffer, max, stdin);
        end = sscanf(buffer, "%s", name);
    }
    while (end == -1);
    printf("Hi, %s", name);
}