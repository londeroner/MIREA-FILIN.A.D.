#include "stdio.h"
#include "stdlib.h"

int main(int argc, char *argv[])
{
    FILE *fp;
    char ch;
	int *p;
	int stc[30000];
	
	for (int i = 0; i < 30000; i++)
		stc[i] = 0;

	p = stc;

    if (argc != 2)
    {
        printf("You forgot write name file\n");
        exit(1);
    }
	
    if ((fp = fopen(argv[1], "r")) == NULL)
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

            case 'i':
				ch = getc(fp);
				ch = getc(fp);
				*p = *p + 1;
                break;
            case 'd': 
				ch = getc(fp);
				ch = getc(fp);
				*p = *p - 1;
                break;
            case 'p': 
				ch = getc(fp);
				ch = getc(fp);
				ch = getc(fp);
				ch = getc(fp);
				printf("%d\n", *p);
                break;
            default:
                break;
        }
    }
    return 0;
}