namespace DesignPatterns.Behavioral.Chain_of_responsibility;

// The abstract handler class
abstract class RequestHandler
{
    protected RequestHandler _successor;

    public void SetSuccessor(RequestHandler successor)
    {
        _successor = successor;
    }

    public abstract void HandleRequest(Request request);
}

// The concrete handler classes
class ManagerHandler : RequestHandler
{
    public override void HandleRequest(Request request)
    {
        if (request.Type == RequestType.Purchase && request.Amount <= 1000)
        {
            Console.WriteLine("Manager approved the purchase request");
        }
        else if (_successor != null)
        {
            _successor.HandleRequest(request);
        }
        else
        {
            Console.WriteLine("Request cannot be approved");
        }
    }
}

class DirectorHandler : RequestHandler
{
    public override void HandleRequest(Request request)
    {
        if (request.Type == RequestType.Purchase && request.Amount <= 5000)
        {
            Console.WriteLine("Director approved the purchase request");
        }
        else if (_successor != null)
        {
            _successor.HandleRequest(request);
        }
        else
        {
            Console.WriteLine("Request cannot be approved");
        }
    }
}

class CEOHandler : RequestHandler
{
    public override void HandleRequest(Request request)
    {
        if (request.Type == RequestType.Purchase && request.Amount <= 10000)
        {
            Console.WriteLine("CEO approved the purchase request");
        }
        else if (_successor != null)
        {
            _successor.HandleRequest(request);
        }
        else
        {
            Console.WriteLine("Request cannot be approved");
        }
    }
}

// The request class
class Request
{
    public RequestType Type { get; set; }
    public int Amount { get; set; }
}

// The request type enumeration
enum RequestType
{
    Purchase,
    Leave,
    Travel
}

public static class ChainOfResponsibilityClient
{
    public static void Run()
    {
        var managerHandler = new ManagerHandler();
        var directorHandler = new DirectorHandler();
        var ceoHandler = new CEOHandler();

        managerHandler.SetSuccessor(directorHandler);
        directorHandler.SetSuccessor(ceoHandler);

        var request1 = new Request { Type = RequestType.Purchase, Amount = 500 };
        managerHandler.HandleRequest(request1);

        var request2 = new Request { Type = RequestType.Purchase, Amount = 5000 };
        managerHandler.HandleRequest(request2);

        var request3 = new Request { Type = RequestType.Purchase, Amount = 15000 };
        managerHandler.HandleRequest(request3);
    }
}

/*
    The Chain of Responsibility design pattern is a behavioral pattern that allows a group of objects 
    to handle requests in a specific order. The idea behind this pattern is to decouple senders and receivers, 
    allowing multiple objects to handle a request without the sender having to know which one will ultimately process the request.

    Here's an example scenario where the Chain of Responsibility pattern can be used:

    Imagine you're developing a software application that needs to handle different types of requests, 
    such as purchase requests, leave requests, and travel requests. Each of these requests requires different 
    levels of approval, and you want to implement a system where each request is handled by the appropriate 
    authority based on the level of approval required.

    In this example, the abstract RequestHandler class defines a common interface for all concrete handler classes. 
    Each concrete handler class (ManagerHandler, DirectorHandler, and CEOHandler) is responsible for handling a specific type of request.

    The RequestHandler class also has a _successor field that holds the next handler in the chain. 
    If a request is not handled by the current handler, it is passed on to the next handler in the 
    chain until it is handled or until there are no more handlers.
 */