
#include <QApplication>
#include <QLibrary>
#include <QMessageBox>

#include "DLLLoader.h"

int LoadLib(QString lib)
{
    QLibrary mylib(lib);

    //判断是否正确加载
    if (!mylib.load())
    {
        QMessageBox::information(NULL,"NO","DLL is not loaded!");
        return 0;
    }

    QMessageBox::information(NULL,"OK","DLL load is OK!");

    Fun open=(Fun)mylib.resolve("add");

    //是否成功连接上 add() 函数
    if (!open)
    {
        QMessageBox::information(NULL,"NO","Linke to Function is not OK!!!!");
        return 0;
    }

    QMessageBox::information(NULL,"OK","Link to Function is OK!");

    //这里函数指针调用dll中的 add() 函数
    return open(5,6);
}

