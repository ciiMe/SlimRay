#-------------------------------------------------
#
# Project created by QtCreator 2012-07-14T13:16:24
#
#-------------------------------------------------

QT       -= gui

TARGET = librarydemo
TEMPLATE = lib

DEFINES += LIBRARYDEMO_LIBRARY

SOURCES += librarydemo.cpp \
    RealExportedObject.cpp

HEADERS += librarydemo.h\
        librarydemo_global.h \
    RealExportedObject.h \
    ExportClassDemo.h

symbian {
    MMP_RULES += EXPORTUNFROZEN
    TARGET.UID3 = 0xE372DD9B
    TARGET.CAPABILITY = 
    TARGET.EPOCALLOWDLLDATA = 1
    addFiles.sources = librarydemo.dll
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
