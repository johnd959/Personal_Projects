#include <stdio.h>
#include <stdlib.h>
short MAX = 10000;  

char *getString(char message[MAX]);

int main(void)
{
    char *name = getString("What is your name: ");
    printf(name);
    free(name);
    getchar(); 
}


char* getString(char message[MAX])
{
    char *String = malloc(MAX * sizeof(char));
    char *Buffer = malloc(MAX * sizeof(char));
    int end = 1;
    do
    {
        char nul[3] = "/0";
        printf("%s", message);
        fgets(Buffer, (MAX * sizeof(char)), stdin);
        end = sscanf(Buffer, "%s", String);
    } 
    while (end == EOF);
    free(Buffer);
    return String;
}
