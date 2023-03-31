namespace DesignPatterns.Behavioral.Mediator;

// Define the mediator interface
interface IChatRoomMediator
{
    void Subscribe(User user);
    void SendMessage(string message, User user);
}

// Define the mediator implementation
class ChatRoomMediator : IChatRoomMediator
{
    private List<User> _users = new List<User>();

    public void Subscribe(User user)
    {
        _users.Add(user);
    }

    public void SendMessage(string message, User user)
    {
        // Broadcast the message to all users in the chat room except the sender
        foreach (var u in _users)
        {
            if (u != user)
            {
                u.ReceiveMessage(message);
            }
        }
    }
}

// Define the user class
class User
{
    private string name;
    private IChatRoomMediator chatRoom;

    public User(string name, IChatRoomMediator chatRoom)
    {
        this.name = name;
        this.chatRoom = chatRoom;
        this.chatRoom.Subscribe(this);
    }

    public void SendMessage(string message)
    {
        chatRoom.SendMessage(message, this);
    }

    public void ReceiveMessage(string message)
    {
        Console.WriteLine("{0} received message: {1}", name, message);
    }
}

public static class MediatorClient
{
    public static void Run()
    {
        // Example usage
        var mediator = new ChatRoomMediator();
        var user1 = new User("Alice", mediator);
        var user2 = new User("Bob", mediator);
        var user3 = new User("Charlie", mediator);

        user1.SendMessage("Hi everyone!");
        user2.SendMessage("Hey Alice, what's up?");
        user3.SendMessage("Nothing much, just hanging out.");

        // Output:
        // Bob received message: Hi everyone!
        // Charlie received message: Hi everyone!
        // Alice received message: Hey Alice, what's up?
        // Charlie received message: Hey Alice, what's up?
        // Alice received message: Nothing much, just hanging out.
        // Bob received message: Nothing much, just hanging out.
    }
}

/*
    The Mediator pattern is a behavioral design pattern that allows objects to communicate with each other through a mediator object, 
    rather than directly communicating with each other. This can help to reduce the dependencies between objects, 
    making the system more flexible and easier to maintain.

    Suppose we have a system that allows users to chat with each other. We might have a User class that represents a user in the system,
    and a ChatRoom class that represents a chat room. Without using the Mediator pattern, we might have the User objects communicating with each other 
    directly. But with the Mediator pattern, we can introduce a ChatRoomMediator object that acts as a mediator between the User objects.

    In this example, the ChatRoomMediator object acts as a mediator between the User objects. The ChatRoomMediator maintains a List of User objects 
    and provides a method to add User to its "subscription". When a user sends a message, the SendMessage method is called on the ChatRoomMediator, 
    which broadcasts the message to all users in the chat room except the sender. The User objects don't need to know about each other, 
    and they don't need to know how the messages are being sent or received – they simply use the mediator object to send and receive messages. 
    This helps to reduce the dependencies between the User objects and make the system more flexible.
*/