using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural.Facade
{
    // Example of a "Horrible API" with complex and hard-to-use classes

    public class ComplexClass1
    {
        public void DoSomething1()
        {
            Console.WriteLine("ComplexClass1 - DoSomething1");
        }

        public void DoSomething2()
        {
            Console.WriteLine("ComplexClass1 - DoSomething2");
        }
    }

    public class ComplexClass2
    {
        public void DoSomething3()
        {
            Console.WriteLine("ComplexClass2 - DoSomething3");
        }

        public void DoSomething4()
        {
            Console.WriteLine("ComplexClass2 - DoSomething4");
        }
    }

    public class ComplexClass3
    {
        public void DoSomething5()
        {
            Console.WriteLine("ComplexClass3 - DoSomething5");
        }

        public void DoSomething6()
        {
            Console.WriteLine("ComplexClass3 - DoSomething6");
        }
    }

    // Facade class that simplifies the usage of the "Horrible API"

    public class ApiFacade
    {
        private readonly ComplexClass1 _complexClass1;
        private readonly ComplexClass2 _complexClass2;
        private readonly ComplexClass3 _complexClass3;

        public ApiFacade()
        {
            _complexClass1 = new ComplexClass1();
            _complexClass2 = new ComplexClass2();
            _complexClass3 = new ComplexClass3();
        }

        public void DoSomething()
        {
            _complexClass1.DoSomething1();
            _complexClass2.DoSomething3();
            _complexClass3.DoSomething5();
        }
    }

    // Client code that uses the Facade to interact with the "horrible API"

    public static class FacadeClient
    {
        public static void Run()
        {
            ApiFacade facade = new ApiFacade();
            facade.DoSomething();
        }
    }

    /*
        The Facade design pattern is a structural design pattern that provides a simplified interface to a complex system of classes, 
        making it easier to use and understand. The pattern achieves this by defining a higher-level interface that makes the system easier to use, 
        without exposing its internal complexity.

        In this example, the "horrible API" is made up of three complex and hard-to-use classes: ComplexClass1, ComplexClass2, and ComplexClass3. 
        The ApiFacade class provides a simplified interface to this API by exposing a single method, DoSomething(), 
        that coordinates the actions of the underlying classes.

        By using the Facade pattern, the client code is shielded from the complexity of the "horrible API", 
        and only needs to interact with the Facade to accomplish its goals. The Facade abstracts away the underlying complexity of the API 
        and provides a simpler and more intuitive interface for the client to use.
    */
}
