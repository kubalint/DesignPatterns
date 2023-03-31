namespace DesignPatterns.Behavioral.State;

public interface IOrderState
{
    void CancelOrder(Order order);
    void VerifyPayment(Order order);
    void ShipOrder(Order order);
}

public class Order
{
    public IOrderState State { get; set; }

    public Order()
    {
        State = new NewState();
    }

    public void CancelOrder()
    {
        Console.WriteLine("Try to cancel order...");
        State.CancelOrder(this);
        Console.WriteLine();
    }

    public void VerifyPayment()
    {

        Console.WriteLine("Try to verify payment...");
        State.VerifyPayment(this);
        Console.WriteLine();
    }

    public void ShipOrder()
    {
        Console.WriteLine("Try to ship order...");
        State.ShipOrder(this);
        Console.WriteLine();
    }
}

public class NewState : IOrderState
{
    public NewState()
    {
        Console.WriteLine("New order has been created:");
        Console.WriteLine();
    }

    public void CancelOrder(Order order)
    {
        order.State = new CancelledState();
    }

    public void VerifyPayment(Order order)
    {
        order.State = new PaidState();
    }

    public void ShipOrder(Order order)
    {
        Console.WriteLine("Cannot ship order until payment is verified.");
    }
}

public class PaidState : IOrderState
{
    public PaidState()
    {
        Console.WriteLine("State moved to PaidState");
    }

    public void CancelOrder(Order order)
    {
        order.State = new CancelledState();
    }

    public void VerifyPayment(Order order)
    {
        Console.WriteLine("Payment has already been verified.");
    }

    public void ShipOrder(Order order)
    {
        order.State = new ShippedState();
    }
}

public class ShippedState : IOrderState
{
    public ShippedState()
    {
        Console.WriteLine("State moved to ShippedState");
    }

    public void CancelOrder(Order order)
    {
        Console.WriteLine("Cannot cancel order once it has been shipped.");
    }

    public void VerifyPayment(Order order)
    {
        Console.WriteLine("Payment has already been verified.");
    }

    public void ShipOrder(Order order)
    {
        Console.WriteLine("Order has already been shipped.");
    }
}

public class CancelledState : IOrderState
{
    public CancelledState()
    {
        Console.WriteLine("State moved to CancelledState");
    }

    public void CancelOrder(Order order)
    {
        Console.WriteLine("Order has already been cancelled.");
    }

    public void VerifyPayment(Order order)
    {
        Console.WriteLine("Cannot verify payment for a cancelled order.");
    }

    public void ShipOrder(Order order)
    {
        Console.WriteLine("Cannot ship a cancelled order.");
    }
}

public static class StateClient
{
    public static void Run()
    {
        Order order = new Order();

        order.VerifyPayment(); // switch to PaidState
        order.ShipOrder(); // switch to ShippedState
        order.ShipOrder(); // Order has already been shipped.

        Console.WriteLine("");
        order = new Order();
        order.CancelOrder(); // switch to CancelledState
        order.ShipOrder(); // Cannot ship a cancelled order.
    }
}

/*
    The State design pattern is a behavioral design pattern that allows an object to alter its behavior when its internal state changes. 
    The pattern involves creating different state classes that represent various states of an object, 
    and the object can switch between these states based on some conditions.

    Let's say we have a class called "Order" that represents an order in an e-commerce application. 
    The Order class has a state variable called "state", which can take on different values such as "New", "Paid", "Shipped". 
    Each of these states has its own behavior that the Order class should exhibit.

        + First, we define an interface called "IOrderState" that defines the methods that should be implemented by each state class
        + Next, we create concrete classes that implement the IOrderState interface for each state of the Order class
        + Finally, we define the Order class and its state variable, and use the state variable to call the appropriate behavior for each state
 */
