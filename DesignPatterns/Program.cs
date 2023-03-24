namespace DesignPatterns
{
    using Creational.FactoryMethod;
    using Creational.AbstractFactory;
    using Creational.Singleton;
    using Creational.Prototype;
    using Creational.Builder;

    using Behavioral.Chain_of_responsibility;
    using Behavioral.Command;

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
            CommandClient.Run();
        }
    }
}