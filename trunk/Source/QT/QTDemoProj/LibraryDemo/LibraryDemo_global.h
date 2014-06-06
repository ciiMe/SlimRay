#ifndef LIBRARYDEMO_GLOBAL_H
#define LIBRARYDEMO_GLOBAL_H

#include <QtCore/qglobal.h>

#if defined(LIBRARYDEMO_LIBRARY)
#  define LIBRARYDEMOSHARED_EXPORT Q_DECL_EXPORT
#else
#  define LIBRARYDEMOSHARED_EXPORT Q_DECL_IMPORT
#endif

#endif // LIBRARYDEMO_GLOBAL_H