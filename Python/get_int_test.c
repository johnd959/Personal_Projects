#include <stdio.h>
#include <stdlib.h>
#include <ctype.h>

int MAX = 100 * sizeof(int);
int get_int(char *phrase);

int main (void)
{
    char *phrase = malloc(100 * sizeof(char));
    phrase = "Hello there: ";
    int test = 0;
    test = get_int(phrase);
    printf("%i", test);
}

int get_int(char *phrase)
{
    int return_int = 0;
    char *temp = malloc(100 * sizeof(int));
    int temp1 = 0;

    do
    {
        printf("%s", phrase);
        fgets(temp, MAX, stdin);
        temp1 = sscanf(temp, "%d", &return_int);
    } 
    while (temp1 == 0 || temp1 == -1);
    free(temp);

    return return_int;
}