namespace DesignPatterns.Creational.Builder;

// Product class
class Pizza
{
    public string Dough { get; set; }
    public string Sauce { get; set; }
    public string Topping { get; set; }
}

// Builder interface
interface IPizzaBuilder
{
    void AddDough();
    void AddSauce();
    void AddTopping();
    Pizza GetPizza();
}

// Concrete Builder class
class MargheritaPizzaBuilder : IPizzaBuilder
{
    private Pizza _pizza = new Pizza();

    public void AddDough()
    {
        _pizza.Dough = "Regular crust";
    }

    public void AddSauce()
    {
        _pizza.Sauce = "Tomato sauce";
    }

    public void AddTopping()
    {
        _pizza.Topping = "Mozzarella cheese";
    }

    public Pizza GetPizza()
    {
        return _pizza;
    }
}

// Director class
class PizzaDirector
{
    private IPizzaBuilder _builder;

    public PizzaDirector(IPizzaBuilder builder)
    {
        _builder = builder;
    }

    public void BuildPizza()
    {
        _builder.AddDough();
        _builder.AddSauce();
        _builder.AddTopping();
    }
}

class ToplessPizzaDirector
{
    private IPizzaBuilder _builder;

    public ToplessPizzaDirector(IPizzaBuilder builder)
    {
        _builder = builder;
    }

    public void BuildPizza()
    {
        _builder.AddDough();
        _builder.AddSauce();
    }
}

// Usage example

public static class BuilderClient
{
    public static void Run()
    {
        IPizzaBuilder margheritaBuilder = new MargheritaPizzaBuilder();
        PizzaDirector director = new PizzaDirector(margheritaBuilder);

        director.BuildPizza();

        Pizza margherita = margheritaBuilder.GetPizza();
        Console.WriteLine($"Margherita pizza: {margherita.Dough}, {margherita.Sauce}, {margherita.Topping}");

        margheritaBuilder = new MargheritaPizzaBuilder();
        ToplessPizzaDirector director2 = new ToplessPizzaDirector(margheritaBuilder);

        director2.BuildPizza();

        Pizza toplessMargherita = margheritaBuilder.GetPizza();
        Console.WriteLine($"Topless margherita pizza: {toplessMargherita.Dough}, {toplessMargherita.Sauce}, {toplessMargherita.Topping}");
    }
}

/*
    The Builder pattern is a creational design pattern that allows you to create complex objects step by step. 
    It separates the construction of an object from its representation so that the same construction process can create different representations.

    The Builder pattern consists of four main components:

    + The Builder interface, which specifies methods for creating the different parts of the product object.
    + The Concrete Builder class(es), which implement the Builder interface to create the different parts of the product object.
    + The Product class, which represents the complex object being built.
    + The Director class, which is responsible for coordinating the building process using the Builder interface.


    In this example, the MargheritaPizzaBuilder class implements the IPizzaBuilder interface to create the different parts of the Pizza object, 
    and the PizzaDirector class is responsible for coordinating the building process using the IPizzaBuilder interface.

    When we want to create a Margherita pizza, we create a MargheritaPizzaBuilder object, pass it to a PizzaDirector object, 
    and call the BuildPizza method to create the pizza. Finally, we retrieve the completed Pizza object using the GetPizza method 
    of the MargheritaPizzaBuilder object.
 */
