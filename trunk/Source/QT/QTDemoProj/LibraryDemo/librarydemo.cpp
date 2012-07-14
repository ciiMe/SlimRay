#include "librarydemo.h"
#include "RealExportedObject.h"

EDemoClass* getDllTest()
{
    return new RealClass();
}
