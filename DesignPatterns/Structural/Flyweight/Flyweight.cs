namespace DesignPatterns.Structural.Flyweight;

class CarFlyweight
{
    public string Model { get; private set; }
    public string Color { get; private set; }
    public int Year { get; private set; }

    public CarFlyweight(string model, string color, int year)
    {
        Model = model;
        Color = color;
        Year = year;
    }

    public void DisplayInfo(string owner)
    {
        Console.WriteLine($"This {Color} {Model} ({Year}) belongs to {owner}");
    }
}

// The FlyweightFactory manages the shared flyweight objects
class CarFlyweightFactory
{
    private Dictionary<string, CarFlyweight> _flyweights = new Dictionary<string, CarFlyweight>();

    public CarFlyweight GetFlyweight(string model, string color, int year)
    {
        string key = $"{model}-{color}-{year}";

        // Check if a flyweight with the given intrinsic properties exists
        if (!_flyweights.ContainsKey(key))
        {
            // If not, create a new flyweight and add it to the pool
            _flyweights[key] = new CarFlyweight(model, color, year);
        }

        return _flyweights[key];
    }
}

// The Client class uses the flyweight objects to minimize memory usage
class CarClient
{
    private CarFlyweightFactory _factory;

    public CarClient(CarFlyweightFactory factory)
    {
        _factory = factory;
    }

    public void DisplayCar(string model, string color, int year, string owner)
    {
        CarFlyweight flyweight = _factory.GetFlyweight(model, color, year);

        // Call the flyweight method with the unique extrinsic property
        flyweight.DisplayInfo(owner);
    }
}

// Usage example
public static class FlyWeightClient
{
    public static void Run()
    {
        CarFlyweightFactory factory = new CarFlyweightFactory();
        CarClient client = new CarClient(factory);

        // The first call creates a new flyweight and adds it to the pool
        client.DisplayCar("BMW", "black", 2020, "John");

        // The second call reuses the existing flyweight from the pool
        client.DisplayCar("BMW", "black", 2020, "Jane");
    }

    /*
        The Flyweight design pattern is a structural pattern that aims to minimize memory usage by sharing as much data as possible between similar objects. 
        The pattern achieves this by separating the intrinsic (shared) and extrinsic (unique) properties of an object. 
        The intrinsic properties are stored in a shared pool, while the extrinsic properties are passed as parameters to the methods of the object.

        In this example, the CarFlyweight class contains the intrinsic properties (Model, Color, and Year) that are shared between similar objects. 
        The CarFlyweightFactory class manages a pool of flyweight objects and creates new ones if needed. 
        The CarClient class uses the flyweight objects to minimize memory usage by only storing the unique extrinsic property (owner) for each object.

        In the Run method, we create a CarFlyweightFactory and a CarClient. We call the DisplayCar method twice with the same intrinsic properties (BMW, black, and 2020) 
        and different extrinsic properties (John and Jane). The first call creates a new flyweight and adds it to the pool, 
        while the second call reuses the existing flyweight.
    */
}
