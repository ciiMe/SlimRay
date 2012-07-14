#ifndef APP_H
#define APP_H

namespace HHT
    {
    namespace APP
    {
        class IAPP
        {
            public:
                void Start();
                void End();
        };

        /*
        App Manager..
        */
        class IAPPManager
        {
            public:
                /*
                Load an App..
                */
                void Load();
        };
    }
}

#endif // APP_H
