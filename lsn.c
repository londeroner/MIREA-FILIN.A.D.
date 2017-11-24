#include <stdio.h>
#include <dirent.h>
#include <sys/types.h>
#include <sys/stat.h>
#include <dirent.h>
#include <unistd.h>

int main ()
{
    Dir *dirname;
    struct dirent *pDire;
    dirname = opendir("\");
    pDire = readdir(dirname);
    while ((pDire = readdir(dirname)) != 0) printf("%s %s %s %s %s %s %s %s %s %s", pDire->st_mode, pDire->st_ino, pDire->dev, pDire->nlink, pDire->uid, pDire->gid, pDire->size, pDire->ctime);
}
