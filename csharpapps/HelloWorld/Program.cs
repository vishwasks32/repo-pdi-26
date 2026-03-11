using System;

namespace MyNameSpace
{
    class MyClass
    {
        public void MyMethod()
        {
            Console.WriteLine("Hello World from MyNamespace");
        }
    }
    
}

class AnotherClass
{
    static void Main()
    {
        MyNameSpace.MyClass obj = new MyNameSpace.MyClass();
        obj.MyMethod();
    }
}