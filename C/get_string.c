#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <stdbool.h>
//The max string length
const int MAX = 100;
char *get_string(char *);

int main (void)
{
    char *message = malloc(MAX * sizeof(char));
    strncpy(message, "Hi, what is your name: ", MAX);
    char *name = get_string(message);
    printf("Hi, %s", name);
    free(message);
    free(name); 
}

char *get_string(char *phrase)
{
    char *string = malloc(MAX * sizeof(char));
    for (int i = 0; i < MAX; i++)
    {
        string[i] = 0;
    }
    char *buffer = malloc(MAX * sizeof(char));
    int end = 0;
    do 
    {
        printf(phrase);
        _flushall();
        bool valid = false;
        fgets(buffer, MAX, stdin); 
        end = sscanf(buffer, "%99c", string);
    }
    while (end == -1);
    return string; 
}