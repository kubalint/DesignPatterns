namespace DesignPatterns.Structural.Adapter
{
    using System;

    // The Target interface
    interface ITarget
    {
        void Request();
    }

    // The Adaptee
    class Adaptee
    {
        public void SpecificRequest()
        {
            Console.WriteLine("Adaptee.SpecificRequest");
        }
    }

    // The Adapter
    class Adapter : ITarget
    {
        private Adaptee _adaptee;

        public Adapter(Adaptee adaptee)
        {
            _adaptee = adaptee;
        }

        public void Request()
        {
            _adaptee.SpecificRequest();
        }
    }

    // The Client
    public class AdapterClient
    {
        public static void Run()
        {
            Adaptee adaptee = new Adaptee();
            ITarget target = new Adapter(adaptee);
            target.Request();
        }
    }

    /*
        The Adapter design pattern is a structural pattern that allows objects with incompatible interfaces to work together. 
        It is often used when you want to reuse an existing class but its interface is not compatible with the rest of your code.

        The Adapter pattern consists of four main components:

        Target interface: The interface that the client code expects to work with.
        Adaptee: The existing class that needs to be adapted to work with the target interface.
        Adapter: The class that adapts the Adaptee to the Target interface.
        Client: The code that uses the Target interface to interact with the Adaptee through the Adapter.

        In this example, the Adaptee has a method called SpecificRequest that is not compatible with the Target interface, which only has a method called Request. 
        The Adapter is created to adapt the Adaptee to the Target interface by implementing the Target interface and forwarding the calls to the Adaptee.

        In the Client code, we create an instance of the Adaptee and pass it to the Adapter, which is then used through the Target interface. 
        When the Request method is called on the Target object, it is translated into a call to SpecificRequest on the Adaptee object.

        This is just a simple example, but the Adapter pattern can be very useful in many scenarios, 
        such as when integrating with legacy systems or third-party libraries that have incompatible interfaces with your code.
    */

}
