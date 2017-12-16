#include "stdio.h"
#include "stdlib.h"

static int n = 0;
static int i;
static int *ip;
static char *cp;
static int countcycles = 0;
static char *mascycles[100];
static int stc[3000];

void completecomm();

int main(int argc, char *argv[])
{
    FILE *fp;
    char ch;
	char comm[100];
    fp = fopen(argv[1], "r");
    for (i = 0; i < 3000; i++)
		stc[i] = 0;
    ip = &stc[1500];

    if (argc != 2)
    {
        printf("You forgot write name file\n");
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
                switch(ch)
                {
                case 'r': comm[n] = 'r';
                    n++;
                    break;
                case 'l': comm[n] = 'l';
                    n++;
                    break;
                }
                break;

            case 'i':
				ch = getc(fp);
				ch = getc(fp);
				comm[n] = 'i';
				n++;
                break;
            case 'd':
				ch = getc(fp);
				ch = getc(fp);
				comm[n] = 'd';
				n++;
                break;
            case 'p':
				ch = getc(fp);
				ch = getc(fp);
				ch = getc(fp);
				ch = getc(fp);
				comm[n] = 'p';
				n++;
                break;
            case 'b':
                ch = getc(fp);
				ch = getc(fp);
				ch = getc(fp);
				ch = getc(fp);
				comm[n] = 'b';
				n++;
				break;
            case 'e':
                ch = getc(fp);
				ch = getc(fp);
				comm[n] = 'e';
				n++;
				break;
        }
    }
    cp = &comm[0];
    comm[n] = 'f';
    while (*cp != 'f')
        completecomm();
    return 0;
}

void completecomm()
{
    switch (*cp)
    {
            case 'r': ip++;
                break;
            case 'l': ip--;
                break;
            case 'i': *ip = *ip + 1;
                break;
            case 'd': *ip = *ip - 1;
                break;
            case 'p': printf("%d\n", *ip);
                break;
            case 'b': countcycles++;
                mascycles[countcycles] = cp;

				break;
            case 'e':
                if (*ip == 0) { countcycles--; }
                else { cp = mascycles[countcycles]; }

				break;
    }
    cp++;

}
