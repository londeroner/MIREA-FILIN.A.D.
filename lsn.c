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
          printf("%hu %ld %d %d %d %d %d %d %d %s", pDire->st_mode, pDire->st_ino, pDire->st_dev, pDire->st_nlink, pDire->st_uid, pDire->st_gid, pDire->st_size, ctime(pDire->st_ctime));
}
