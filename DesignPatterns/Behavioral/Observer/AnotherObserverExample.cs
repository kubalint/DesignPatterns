namespace DesignPatterns.Behavioral.Observer.Another;

// Define the observer interface
public interface IObserver
{
    void Update(float temperature, float humidity, float pressure);
}

// Define the subject interface
public interface ISubject
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void Notify();
}

// Define a concrete subject
public class WeatherData : ISubject
{
    private List<IObserver> observers = new List<IObserver>();
    private float temperature;
    private float humidity;
    private float pressure;

    public void Attach(IObserver observer)
    {
        observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (IObserver observer in observers)
        {
            observer.Update(temperature, humidity, pressure);
        }
    }

    public void SetMeasurements(float temperature, float humidity, float pressure)
    {
        this.temperature = temperature;
        this.humidity = humidity;
        this.pressure = pressure;
        Notify();
    }
}

// Define a concrete observer
public class CurrentConditionsDisplay : IObserver
{
    private float temperature;
    private float humidity;
    private ISubject weatherData;

    public CurrentConditionsDisplay(ISubject weatherData)
    {
        this.weatherData = weatherData;
        weatherData.Attach(this);
    }

    public void Update(float temperature, float humidity, float pressure)
    {
        this.temperature = temperature;
        this.humidity = humidity;
        Display();
    }

    public void Display()
    {
        Console.WriteLine("Current conditions: {0}°C degrees and {1}% humidity",
            temperature, humidity);
    }
}

// Example usage

public static class AnotherObserverExampleClient
{
    public static void Run()
    {
        WeatherData weatherData = new WeatherData();
        CurrentConditionsDisplay currentDisplay = new CurrentConditionsDisplay(weatherData);

        weatherData.SetMeasurements(10, 65, 30.4f);
        weatherData.SetMeasurements(22, 70, 29.2f);
        weatherData.SetMeasurements(28, 90, 29.2f);
    }
}