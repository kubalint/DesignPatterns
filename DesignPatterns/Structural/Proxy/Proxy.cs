namespace DesignPatterns.Structural.Proxy;

// The real object interface
public interface IImage
{
    void Display();
}

// The real object implementation
public class RealImage : IImage
{
    private string _filename;

    public RealImage(string filename)
    {
        _filename = filename;
        LoadFromDisk();
    }

    public void Display()
    {
        Console.WriteLine("Displaying " + _filename);
    }

    private void LoadFromDisk()
    {
        Console.WriteLine("Loading " + _filename);
    }
}

// The proxy object implementation
public class ProxyImage : IImage
{
    private RealImage _realImage;
    private string _filename;

    public ProxyImage(string filename)
    {
        _filename = filename;
    }

    public void Display()
    {
        if (_realImage == null)
        {
            _realImage = new RealImage(_filename);
        }
        _realImage.Display();
    }
}

public class ProxyClient
{
    public static void Run()
    {
        // Create a proxy image
        IImage image = new ProxyImage("test.jpg");

        // Display the image - this will call the proxy's Display method
        image.Display();

        // Display the image again - this time, the real object will be used
        image.Display();
    }
}

/*
    The Proxy design pattern is a structural pattern that allows us to provide a surrogate or placeholder for another object to control access to it. 
    In other words, a proxy object acts as an intermediary between a client and the real object, 
    and it forwards requests from the client to the real object while adding additional functionality if needed.

    In this example, we have an interface IImage that defines the methods that the real object and the proxy object will implement. 
    The RealImage class is the implementation of the IImage interface and represents the real object that we want to control access to. 
    The ProxyImage class is the implementation of the IImage interface and acts as a proxy for the real image.

    The ProxyImage class only creates a RealImage object when it is needed and forwards the Display method calls to the real object. 
    This way, we can control access to the real object and add additional functionality if needed.

    In this example, we create a proxy image with the filename "test.jpg". We then call the Display method on the proxy image, 
    which will call the proxy's Display method. The proxy will create the real image object and call its Display method. 
    We then call the Display method again, and this time the real object will be used instead of creating a new one.
*/