namespace DesignPatterns.Behavioral.Visitor;

// Element interface
interface IElement
{
    void Accept(IVisitor visitor);
}

// Concrete Element class
class ConcreteElementA : IElement
{
    public void Accept(IVisitor visitor)
    {
        visitor.VisitConcreteElementA(this);
    }

    public void OperationA()
    {
        Console.WriteLine("ConcreteElementA.OperationA");
    }
}

// Concrete Element class
class ConcreteElementB : IElement
{
    public void Accept(IVisitor visitor)
    {
        visitor.VisitConcreteElementB(this);
    }

    public void OperationB()
    {
        Console.WriteLine("ConcreteElementB.OperationB");
    }
}

// Visitor interface
interface IVisitor
{
    void VisitConcreteElementA(ConcreteElementA element);
    void VisitConcreteElementB(ConcreteElementB element);
}

// Concrete Visitor class
class ConcreteVisitor1 : IVisitor
{
    public void VisitConcreteElementA(ConcreteElementA element)
    {
        Console.WriteLine("ConcreteVisitor1.VisitConcreteElementA");
        element.OperationA();
    }

    public void VisitConcreteElementB(ConcreteElementB element)
    {
        Console.WriteLine("ConcreteVisitor1.VisitConcreteElementB");
        element.OperationB();
    }
}

// Concrete Visitor class
class ConcreteVisitor2 : IVisitor
{
    public void VisitConcreteElementA(ConcreteElementA element)
    {
        Console.WriteLine("ConcreteVisitor2.VisitConcreteElementA");
        element.OperationA();
    }

    public void VisitConcreteElementB(ConcreteElementB element)
    {
        Console.WriteLine("ConcreteVisitor2.VisitConcreteElementB");
        element.OperationB();
    }
}

// Object structure class
class ObjectStructure
{
    private readonly IElement[] _elements;

    public ObjectStructure()
    {
        _elements = new IElement[] { new ConcreteElementA(), new ConcreteElementB() };
    }

    public void Accept(IVisitor visitor)
    {
        foreach (IElement element in _elements)
        {
            element.Accept(visitor);
        }
    }
}

public class VisitorClient
{
    public static void Run()
    {
        ObjectStructure objectStructure = new ObjectStructure();

        ConcreteVisitor1 visitor1 = new ConcreteVisitor1();
        objectStructure.Accept(visitor1);

        Console.WriteLine();

        ConcreteVisitor2 visitor2 = new ConcreteVisitor2();
        objectStructure.Accept(visitor2);
    }
}

/*
    The Visitor pattern is a behavioral design pattern that allows you to separate the algorithm from the object structure on which it operates. 
    It is useful when you have a complex object structure and want to add new operations to it without modifying the objects themselves.    

    First, you define an abstract Visitor interface that declares a set of visit methods, one for each class in the object structure. 
    The visit methods take a reference to the object they are visiting as a parameter.

    Then, you define a concrete Visitor class that implements the Visitor interface and provides the implementation for each visit method.

    Next, you define an abstract Element interface that declares an accept method that takes a Visitor object as a parameter.

    Finally, you define concrete Element classes that implement the Element interface and provide the implementation for the accept method. 
    The accept method simply calls the corresponding visit method on the Visitor object.

    In this example, we have two concrete Element classes (ConcreteElementA and ConcreteElementB) that implement the IElement interface and provide 
    the implementation for the Accept method. We also have two concrete Visitor classes (ConcreteVisitor1 and ConcreteVisitor2) that implement the 
    `IVisitorinterface and provide the implementation for theVisitConcreteElementAandVisitConcreteElementB` methods.

    The ObjectStructure class represents the object structure on which the Visitor operates. 
    It contains an array of IElement objects and provides the Accept method that takes a IVisitor object as a parameter. 
    The Accept method simply iterates over the elements in the array and calls their Accept method, passing the Visitor object as a parameter.

    In the Run method, we create an instance of ObjectStructure and two instances of ConcreteVisitor, visitor1 and visitor2. 
    We then call the Accept method on the ObjectStructure object, passing each Visitor object as a parameter. 
    This causes the appropriate Visit methods to be called on each Element object in the ObjectStructure.
 */
