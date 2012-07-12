#ifndef HELLOAPP_H
#define HELLOAPP_H

#include "App.h"

using namespace HHT::APP;

namespace HHT
{
    namespace APP
    {
        class HelloAPP:public IAPP,public virtual IAPPManager
        {
            public:
                void Update();
        };
    }

}

#endif // HELLOAPP_H
