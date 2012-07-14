#ifndef DLLLOADER_H
#define DLLLOADER_H


typedef int (*Fun)(int,int);

int LoadLib(QString lib);

#endif // DLLLOADER_H
