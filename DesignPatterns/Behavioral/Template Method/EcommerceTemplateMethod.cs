namespace DesignPatterns.Behavioral.Template_Method;

public abstract class OrderProcessor
{
    public void ProcessOrder(Order order)
    {
        ValidateOrder(order);
        CheckAvailability(order);
        ReserveItems(order);
        ProcessPayment(order);
        MarkOrderComplete(order);
    }

    protected abstract void ValidateOrder(Order order);

    protected abstract void CheckAvailability(Order order);

    protected abstract void ReserveItems(Order order);

    protected abstract void ProcessPayment(Order order);

    protected abstract void MarkOrderComplete(Order order);
}

public class AmazonOrderProcessor : OrderProcessor
{
    protected override void ValidateOrder(Order order)
    {
        // Implementation specific to Amazon
    }

    protected override void CheckAvailability(Order order)
    {
        // Implementation specific to Amazon
    }

    protected override void ReserveItems(Order order)
    {
        // Implementation specific to Amazon
    }

    protected override void ProcessPayment(Order order)
    {
        // Implementation specific to Amazon
    }

    protected override void MarkOrderComplete(Order order)
    {
        // Implementation specific to Amazon
    }
}

public class WalmartOrderProcessor : OrderProcessor
{
    protected override void ValidateOrder(Order order)
    {
        // Implementation specific to Walmart
    }

    protected override void CheckAvailability(Order order)
    {
        // Implementation specific to Walmart
    }

    protected override void ReserveItems(Order order)
    {
        // Implementation specific to Walmart
    }

    protected override void ProcessPayment(Order order)
    {
        // Implementation specific to Walmart
    }

    protected override void MarkOrderComplete(Order order)
    {
        // Implementation specific to Walmart
    }
}

public class Order {}