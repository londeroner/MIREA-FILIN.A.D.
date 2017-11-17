#include "stdio.h"


int main()
{
    int day=0;
    int month=0;
    int year=0;
    printf("Input date in format: dd mm year\n");
    scanf("%d %d %d", &day, &month, &year);

    int a = (14 - month) / 12;
    int y = year - a;
    int m = month + 12*a - 2;
    int dned = (7000 + (day + y + y / 4 - y / 100 + y / 400 + (31 * m) / 12)) % 7;
    switch(dned)
    {
        case 0: printf("Sunday");
            break;
        case 1: printf("Monday");
            break;
        case 2: printf("Tuesday");
            break;
        case 3: printf("Wednesday");
            break;
        case 4: printf("Thursday");
            break;
        case 5: printf("Friday");
            break;
        case 6: printf("Saturday");
            break;
    }
    scanf("%s");

}

