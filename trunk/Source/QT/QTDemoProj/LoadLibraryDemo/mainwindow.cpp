#include "mainwindow.h"
#include "ui_mainwindow.h"
#include <QLibrary>
#include <QMessageBox>

#include "DLLLoader.h"
#include "../LibraryDemo/ExportClassDemo.h"
#include "TestClass.h"


MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow)
{
    ui->setupUi(this);
}

MainWindow::~MainWindow()
{
    delete ui;
}

void MainWindow::on_pushButton_clicked()
{

    //EDemoClass* getDllTest()
    typedef EDemoClass* (*dllFun)();
    if(this->m_Lib == 0)
    {
        m_Lib = new QLibrary("LibraryDemo.dll");
    }

    //判断是否正确加载
    if (!m_Lib->load())
    {
        QMessageBox::information(NULL,"NO","DLL is not loaded!");
        return;
    }

    QMessageBox::information(NULL,"OK","DLL load is OK!");

    dllFun open=(dllFun)m_Lib->resolve("getDllTest");

    //是否成功连接上 add() 函数
    if (!open)
    {
        QMessageBox::information(NULL,"NO","Linke to Function is not OK!!!!");
        //mylib.unload();
        return;
    }

    QMessageBox::information(NULL,"OK","Link to Function is OK!");

    this->m_DemoClass = open();

    int a,b,c;

    a = ui->spinBox->value();
    b = ui->spinBox_2->value();

    QMessageBox::information(NULL,"Start..","Starting DLL Func..");
    c = m_DemoClass->ClassAddFunc(a,b);
    //mylib.unload();
    QMessageBox::information(NULL,"Start..","Started DLL Func..");

    QString s = QString("Result of a+b is:%1").arg(c);

    ui->textEdit_3->setText(s);
}

void MainWindow::on_pushButton_2_clicked()
{
    A* testA = getTestObject();

    int a,b,c;
    a = ui->spinBox->value();
    b = ui->spinBox_2->value();


    c = testA->Add(a,b);

    QString s = QString("Result of a+b is:%1").arg(c);
    ui->textEdit_3->setText(s);
}

void MainWindow::on_pushButton_3_clicked()
{
    int a,b,c;
    a = ui->spinBox->value();
    b = ui->spinBox_2->value();

    if(this->m_DemoClass)
    {
        c = this->m_DemoClass->ClassAddFunc(a,b);
    }
    else
    {
        QMessageBox::information(NULL,"Object","Object is null..");
        return;
    }

    QString s = QString("Result of a+b is:%1").arg(c);
    ui->textEdit_3->setText(s);
}

void MainWindow::on_pushButton_4_clicked()
{
    this->m_DemoClass = 0;
    this->m_Lib = 0;
}

void MainWindow::on_pushButton_5_clicked()
{
    this->m_Lib->unload();
    delete this->m_DemoClass;
    delete this->m_Lib;

    this->m_DemoClass = 0;
    this->m_Lib = 0;
}
