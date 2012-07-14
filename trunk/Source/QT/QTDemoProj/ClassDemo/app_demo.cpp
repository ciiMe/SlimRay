#include "app_demo.h"

#include "HelloApp.h"

using namespace HHT::APP;

App_Demo::App_Demo()
{
    HelloAPP a ;

    if(true)
    {
        a.Start();
    }
    else
    {
        a.Load();
        a.Update();
    }

    if(0)
    {
        a.End();
    }
}
