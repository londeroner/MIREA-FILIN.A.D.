#include <stdio.h>
#include <dirent.h>
#include <sys/types.h>
#include <sys/stat.h>
#include <dirent.h>
#include <unistd.h>

int main ()
{
    DIR *dirname;
    char PATH[1000];
    getcwd(PATH, 1000);
    struct dirent *pDire;
    dirname = opendir(PATH);
    pDire = readdir(dirname);
    while ((pDire = readdir(dirname)) != NULL) 
          printf("%s\n", pDire->d_name);
}
