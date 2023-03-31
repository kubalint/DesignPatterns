namespace DesignPatterns.Creational.Prototype;

public abstract class Prototype
{
    public string Name { get; set; }
    public List<string> Features { get; set; }

    public abstract Prototype Clone();
}

public class ConcretePrototype : Prototype
{
    public ConcretePrototype(string name, List<string> features)
    {
        Name = name;
        Features = features;
    }

    public override Prototype Clone()
    {
        // Create a new object and copy all properties
        ConcretePrototype cloned = new ConcretePrototype(Name, Features.ToList());

        // Deep copy the features list
        cloned.Features = Features.Select(f => string.Copy(f)).ToList();

        return cloned;
    }

    //public override Prototype Clone()
    //{
    //    // Perform a shallow copy of the object
    //    return (ConcretePrototype)this.MemberwiseClone();
    //}
}

// Client code
public static class PrototypeClient
{
    public static void Run()
    {
        // Create the prototype object
        ConcretePrototype prototype = new ConcretePrototype("Prototype", new List<string> { "Feature 1", "Feature 2", "Feature 3" });

        // Clone the prototype using a deep copy
        ConcretePrototype cloned = (ConcretePrototype)prototype.Clone();

        // Modify the cloned object's features list
        cloned.Features[0] = "Modified Feature";

        // Verify that the original prototype object was not modified
        Console.WriteLine("Prototype features: " + string.Join(", ", prototype.Features));
        Console.WriteLine("Cloned features: " + string.Join(", ", cloned.Features));
    }
}

/*
    The Prototype pattern is a creational pattern that is used when you want to create an object based on an existing object. 
    Instead of creating a new object from scratch, you make a copy of the existing object and modify it as needed. This pattern is
    useful when the creation of a new object is expensive or complex and you want to avoid the overhead of creating a new object each time.

    Cloning the prototype with a shallow copy can cause side-effects if any of the cloned objects are modified, as those modifications will 
    also be reflected in the original prototype object.

    This is because a shallow copy only creates a new object with the same references as the original object, so any changes made to the 
    properties of the cloned object will also affect the original object. If the cloned objects contain any reference types, such as lists 
    or other objects, modifying those reference types will also affect the original object.

    To avoid side-effects, you can clone the prototype using a deep copy, which creates new copies of all the object's data. 
    This ensures that any changes made to the cloned object will not affect the original object.
 */

