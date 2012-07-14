/*
Demo for override ...
*/

class A
{
    public:
        virtual int Add(int a,int b)
        {
            return 0;
        }
};

class B:public A
{
    public:
        int Add(int a, int b)
        {
            return (a + b);
        }
};

class C:public A
{
    public:
        int Add(int a, int b)
        {
            return -1 * (a + b);
        }
};

A* getTestObject()
{
    return new C();
}
