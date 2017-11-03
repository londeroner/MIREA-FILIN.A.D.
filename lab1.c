#include "stdio.h"
#include "stdlib.h"

int main(int argc, char *argv[])
{
    FILE *fp;
    char ch;
	int *p;
	int stc[30000];

	p = stc;

    if (argc != 2)
    {
        printf("You forgot write name file\n");
        exit(1);
    }

    if ((fp = fopen("file.txt", "r")) == NULL)
    {
        printf("File open Error\n");
        exit(1);
    }

    while(ch != EOF)
    {
        ch = getc(fp);
        switch(ch)
        {
            case 'm':
                ch = getc(fp);
                ch = getc(fp);
                ch = getc(fp);
                switch (ch)
                {
                    case 'r':
                        if (p == &stc[29999])
                            p = stc;
                        else p++;
                        break;
                    case 'l':
                        if (p == stc)
                            p = &stc[29999];
                        else p--;
                }
                break;

            case 'i': *p++;
                break;
            case 'd': *p--;
                break;
            case 'p': printf("%d", *p);
                break;
            default:
                break;
        }
    }
    return 0;
}
