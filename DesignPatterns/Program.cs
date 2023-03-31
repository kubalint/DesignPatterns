using DesignPatterns.Behavioral.Template_Method;
using DesignPatterns.Behavioral.Visitor;
using DesignPatterns.Structural.Adapter;
using DesignPatterns.Structural.Bridge;
using DesignPatterns.Structural.Composite;

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

            //AdapterClient.Run();
            //BridgeClient.Run();
            CompositeClient.Run();
        }
    }

    /*
        The Composite pattern is a structural design pattern that allows you to treat a group of objects in the same way as you would treat an individual object. 
        It allows you to create a tree-like structure where each node can have one or more children, which can also be nodes themselves. 
        This pattern is useful when you need to work with complex hierarchical structures and want to treat each element uniformly.
        
        In this example, we create a Menu class that implements the IMenuComponent interface. This class has a list of IMenuComponent objects, 
        which can be either other Menu objects or MenuItem objects. The Add() and Remove() methods are used to add or remove menu components from the list.

        The MenuItem class is a leaf node in the tree structure, which means that it doesn't have any children. 
        It implements the IMenuComponent interface and has a Display() method that simply displays the name and price of the menu item.

        In the Main() method, we create a Menu object for the top-level menu and then create three submenus for appetizers, entrees, and desserts. 
        We add MenuItem objects to each of the submenus, and then add the submenus to the top-level menu. 
        Finally, we call the Display() method on the top-level menu to display the entire menu structure, including all submenus and menu items.
        As you can see, the Menu and MenuItem objects are treated uniformly, and we can create a tree-like structure of menus and menu items using the Composite pattern.

        Overall, the Composite pattern is a powerful tool for managing hierarchical structures, and it can be used in a wide range of applications, 
        from graphical user interfaces to file systems and beyond.
     */
}