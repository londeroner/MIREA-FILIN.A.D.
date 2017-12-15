#include "stdio.h"
#include "stdlib.h"

static int n = 0;
static int i;
static int *ip;
static char *cp;
static int countcycles = -1;
static char *mascycles[10000];

void work();
void completecomm();

int main(int argc, char *argv[])
{
    FILE *fp;
    char ch;
	int stc[30000];
	char comm[30000];


	for (i = 0; i < 30000; i++)
		stc[i] = 0;

	ip = &stc[15000];

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
    work();
    return 0;
}

void work()
{
    for (i = 0; i < n; i++)
    {
        completecomm();
    }
}

void completecomm()
{
    switch (*cp)
    {
            case 'r': ip++;
                break;
            case 'l': ip--;
                break;
            case 'i': *ip++;
                break;
            case 'd': *ip--;
                break;
            case 'p': printf("%d", *ip);
                break;
            case 'b': countcycles++;
                mascycles[countcycles] = cp;
                mascycles[countcycles]++;
				break;
            case 'e': if (*ip != 0) { cp = mascycles[countcycles]; }
                else { countcycles--; }
				break;
    }
    cp++;
}

