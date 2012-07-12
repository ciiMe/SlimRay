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

        class IAPPManager
        {
            public:
                void Load();
        };
    }
}

#endif // APP_H
