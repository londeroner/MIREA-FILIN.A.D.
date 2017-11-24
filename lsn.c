#include <stdio.h>
#include <dirent.h>
#include <sys/types.h>
#include <sys/stat.h>
#include <dirent.h>
#include <unistd.h>

int main ()
{
    DIR *dirname;
    struct stat *pDire;
    dirname = opendir("/");
    pDire = readdir(dirname);
    while ((pDire = readdir(dirname)) != NULL) 
          printf("%s", ctime(&pDire->st_ctime));
}
