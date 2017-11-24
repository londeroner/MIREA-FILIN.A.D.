#include <stdio.h>
#include <dirent.h>
#include <sys/types.h>
#include <sys/stat.h>
#include <dirent.h>
#include <unistd.h>

int main ()
{
    DIR *dirname;
    struct dirent *pDire;
    dirname = fdopendir(dirfd(dirname));
    pDire = readdir(dirname);
    while ((pDire = readdir(dirname)) != NULL) 
          printf("%s\n", pDire->d_name);
}
