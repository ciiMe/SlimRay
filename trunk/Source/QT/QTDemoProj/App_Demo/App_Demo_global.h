#ifndef APP_DEMO_GLOBAL_H
#define APP_DEMO_GLOBAL_H

#include <QtCore/qglobal.h>

#if defined(APP_DEMO_LIBRARY)
#  define APP_DEMOSHARED_EXPORT Q_DECL_EXPORT
#else
#  define APP_DEMOSHARED_EXPORT Q_DECL_IMPORT
#endif

#endif // APP_DEMO_GLOBAL_H
