#include <stdio.h>
#include <stdlib.h>
#include <ctype.h>
#include <stdbool.h>
#include <string.h>
const int MAX = 100;
//defining a node for a linked list
typedef struct node
{
    int category;
    double quants;
    struct node *next;
}
node;
//defining a week node for a linked list
typedef struct week
{
    node* list_start;
    char* day; 
    struct week *next;
}
week;
node* create_list(int list_size);
void fill_list(node *list_start, char*phrase);
void free_list(node *list_start); 
void add_list(node *list_start);
week* create_week();
void add_week(week* currentNode);
void free_week(week* week_start);
double calculate_total(node* current_position);
int get_int(char phrase[MAX]);
void free_day(char *day); 
float APPLE_IPHONE = 120.45;
float ANDROID_PHONE = 99.50;
float APPLE_TABLET = 75.69;
float ANDROID_TABLET = 65.73;
float WINDOWS_TABLET = 51.49;
bool add = false; 

int main(void)
{
    float total = 0;
    bool end = false;
    while (end == false)
    {
        week* week1 = create_week();
        printf("Welcome to Circle Phones' Profit Calculator\n");
        printf("You can calculate the profit of the company according to a specific day or by a week or divide the week into weekdays and weekend.\nEnter:\n");
        printf("   1 - For a specific Day\n   2 - For the Week\n   3 - For Week Business Days\n   4 - For Weekend Days\n   0 - Exit\n");
        _flushall();
        int period = get_int("Enter: ");
        //if period = 1
        if (period == 0)
        {
            add = false;
            end = true;  
        }
        //if period = 2, getitng a day
        else if (period == 1)
        {
            printf("\n");
            _flushall();
            char *phrase = malloc(MAX * sizeof(char));
            char *buffer = malloc(MAX * sizeof(char));
            for (int i = 0; i < (MAX - 1); i++)
            {
                phrase[i] = 0; 
            }
            do
            {
                int end = 0;
                printf("Enter a specific day: ");
                fgets(buffer, MAX, stdin);
                end = sscanf(buffer, "%99c", phrase);
            } while (end == EOF);
            node *list = create_list(1);
            week1->list_start = list;
            strncpy(week1->day, phrase, 10);  
            fill_list(list, phrase);
            total = calculate_total(list);
            printf("Your total for  %s is $%.2f\n", phrase, total); 
            free_week(week1);
            free(buffer);
        }
        else
        {
            char *periodName = malloc(MAX * sizeof(char));
            add = true;
            int repeat = 0;
            int index = 1;
            switch (period)
            {
                case 2:
                    repeat = 7;
                    strncpy(periodName, "week", MAX);
                    break;
                case 3:
                    repeat = 5;
                    strncpy(periodName, "business week", MAX);
                    break;
                case 4:
                    repeat = 2;
                    strncpy(periodName, "weekend", MAX);
                    index = 6; 
                    break;
            }
            week *cursor = week1;
            node *list = NULL; 
            for (int i = 0; i < repeat; i++)
            {
                add= false; 
                list = create_list(1);
                cursor->list_start = list;
                cursor->next = NULL; 
                switch (index)
                {
                    case 1:
                        cursor->day = "Monday";
                        break;
                    case 2:
                        cursor->day = "Tuesday";
                        break;
                    case 3:
                        cursor->day = "Wednesday";
                        break;
                    case 4:
                        cursor->day = "Thursday";
                        break;
                    case 5:
                        cursor->day = "Friday";
                        break;
                    case 6:
                        cursor->day = "Saturday";
                        break;
                    case 7:
                        cursor->day = "Sunday";
                        break;            
                }
                index++;
                fill_list(list, cursor->day);
                _flushall();
                add = true; 
                add_week(cursor); 
                cursor = cursor->next; 
            }
            for (; week1 != NULL; week1 = week1->next)
            {
                total += calculate_total(week1->list_start);
            }
            printf("Your total for the %s is $%.2f\n", periodName, total);
            FILE *file = fopen("Costs.txt", "a'");
            fwrite(&total, 100, 1, file);
            fclose(file);
            free(periodName); 
           free(week1);
        }
    }
    return 0; 
}


node* create_list(int list_size)
{
    node *list_start = malloc(sizeof(node));
    node *module = malloc(sizeof(node));
    node *pointer = NULL;
    for (int i = 0; i < (list_size - 1); i++)
    {
        if (i == 0)
        {
            list_start->next = module; 
            list_start->category = 0.0;
            list_start->quants = 0;
        }
        else
        {
            pointer = module;
            module = malloc(sizeof(node));
            pointer->next = module;
            pointer->category = 0.0;
            pointer->quants = 0.0;
        }
    }
    module->next = NULL;
    module->category = 0.0;
    module->quants = 0.0;
    return list_start; 
}

void print_list(node *list_start) 
{
    node *cursor = NULL;
    for (cursor = list_start; cursor != NULL; cursor = cursor->next)
    {
        int categories = cursor->category; 
        int quants = cursor->quants; 
        printf("%i" "%i", categories, quants);
    }  
}

void free_list(node *list_start)
{
    node *cursor = NULL;
    while (list_start != NULL)
    {
        cursor = list_start;
        list_start = list_start->next;
        free(cursor); 
    }
    return;
}

void fill_list(node* list_start, char* phrase)
{
    printf("Please enter a product number and a quantity for %s\n", phrase);
    _flushall(); 
    node* cursor = NULL;
    char *phrase1 = malloc(100 * sizeof(char));
    strncpy(phrase1, "Enter a category: ", MAX);
    char *phrase2 = malloc(100 * sizeof(char));
    strncpy(phrase2, "Enter a quanity: ", MAX);
    int iteration = 0;
    for (cursor = list_start; cursor != NULL; cursor = cursor->next)
    {
        int category1 = 0;
        int quants1 = 0;
        do
        {
            category1 = get_int(phrase1);
        }
        while (category1 < 0 || category1 > 5);
        if (category1 != 0)
        {
            add_list(cursor);
        }
        else
        {
            continue;
        }
        cursor->category = category1;
        do 
        {
            quants1 = get_int(phrase2);
        }
        while (quants1 < 0 || quants1 > 10000);
        cursor->quants = quants1;
    }
    free(phrase1);
    free(phrase2); 
    return;
}

double calculate_total(node *list_start)
{
    node *cursor = NULL;
    double total = 0;
    for (cursor = list_start; cursor != NULL; cursor = cursor->next)
    {
        int switcher = cursor->category;
        switch (switcher)
        {
            case 1:
                total += APPLE_IPHONE * cursor->quants;
                break;
            case 2:
                total += ANDROID_PHONE * cursor->quants;
                break;
            case 3:
                total += APPLE_TABLET * cursor->quants;
                break;
            case 4:
                total += ANDROID_TABLET * cursor->quants;
                break;
            case 5:
                total += WINDOWS_TABLET * cursor->quants;
                break;
        }
    }
    return total;
}

int get_int(char phrase[MAX])
{
    int return_int = 0;
    char *temp = malloc(100 * sizeof(int));
    int temp1 = 0;

    do
    {
        printf("%s", phrase);
        _flushall();
        fgets(temp, MAX, stdin);
        temp1 = sscanf(temp, "%d", &return_int);
    } 
    while (temp1 == 0 || temp1 == -1);
    free(temp);

    return return_int;
}

void add_list(node *current_position)
{
    node *pointer = current_position;
    pointer->next = malloc(sizeof(node));
    pointer = pointer->next;
    pointer->next = NULL;
    pointer->category = 0;
    pointer->quants = 0;
}
week* create_week()
{
    week* week_start = NULL;
    week_start = malloc(sizeof(week));
    week_start->day = malloc(10 * sizeof(char));    
    week_start->list_start = NULL;
    week_start->next = NULL;
    return week_start; 
}
void add_week(week* currentNode)
{
    currentNode->next = malloc(sizeof(week));
    currentNode = currentNode->next;
    currentNode->day = NULL;
    currentNode->list_start = NULL;
    currentNode->next = NULL;
}

void free_week(week *week_start)
{
    week *cursor = NULL; 
    while (week_start != NULL)
    {
        cursor = week_start;
        week_start = week_start->next;
        free_list(cursor->list_start);
        free(cursor);

    }
}
