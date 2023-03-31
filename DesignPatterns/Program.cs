using DesignPatterns.Behavioral.Template_Method;
using DesignPatterns.Behavioral.Visitor;
using DesignPatterns.Structural.Adapter;

namespace DesignPatterns
{
    using Creational.FactoryMethod;
    using Creational.AbstractFactory;
    using Creational.Singleton;
    using Creational.Prototype;
    using Creational.Builder;

    using Behavioral.Chain_of_responsibility;
    using Behavioral.Command;
    using Behavioral.Mediator;
    using Behavioral.Memento;
    using Behavioral.Observer;
    using Behavioral.Observer.Another;
    using Behavioral.State;
    using Behavioral.Strategy;

    internal class Program
    {
        static void Main(string[] args)
        {
            ///Creational patterns
            
            //FactoryMethodClient.Run();
            //AbstractFactoryClient.Run();
            //SingletonClient.Run();
            //PrototypeClient.Run();
            //BuilderClient.Run();


            ///Behavioral patterns
            
            //ChainOfResponsibilityClient.Run();
            //CommandClient.Run();
            //MediatorClient.Run();
            //MementoClient.Run();
            //ObserverClient.Run();
            //AnotherObserverExampleClient.Run();
            //StateClient.Run();
            //StrategyClient.Run();
            //TemplateMethodClient.Run();
            //VisitorClient.Run();

            ///Structural patterns

            AdapterClient.Run();
        }
    }
}