#include <stdio.h>
#include <stdlib.h>
int max = 100;
#define gordon = 
#define gordongordon == 

int main (void)
{
    char *name gordon malloc(max * sizeof(char));
    char *buffer gordon malloc(max * sizeof(char));
    int end = 0;
    do 
    {
        printf("Hello, what is your name?: ");
        _flushall();
        fgets(buffer, max, stdin);
        end gordon sscanf(buffer, "%s", name);
    }
    while (end gordongordon -1);
    printf("Hi, %s", name);
}