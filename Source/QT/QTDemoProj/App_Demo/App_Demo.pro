#-------------------------------------------------
#
# Project created by QtCreator 2012-07-12T22:15:11
#
#-------------------------------------------------

QT       += sql

QT       -= gui

TARGET = App_Demo
TEMPLATE = lib

DEFINES += APP_DEMO_LIBRARY

SOURCES += app_demo.cpp \
    App.cpp \
    HelloApp.cpp

HEADERS += app_demo.h\
        App_Demo_global.h \
    App.h \
    HelloApp.h

symbian {
    MMP_RULES += EXPORTUNFROZEN
    TARGET.UID3 = 0xE5E2BA34
    TARGET.CAPABILITY = 
    TARGET.EPOCALLOWDLLDATA = 1
    addFiles.sources = App_Demo.dll
    addFiles.path = !:/sys/bin
    DEPLOYMENT += addFiles
}

unix:!symbian {
    maemo5 {
        target.path = /opt/usr/lib
    } else {
        target.path = /usr/lib
    }
    INSTALLS += target
}
