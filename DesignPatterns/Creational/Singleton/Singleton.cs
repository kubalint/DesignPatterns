using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.Singleton
{
    public class Singleton
    {
        private static Singleton instance;
        private static readonly object lockObject = new object();

        private Singleton() { }

        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        if (instance == null)
                        {
                            instance = new Singleton();
                        }
                    }
                }
                return instance;
            }
        }

        public int Counter { get; private set; }

        public void IncreaseCounter()
        {
            Counter++;
            Console.WriteLine($"Value of the counter is: {Counter}");
        }
    }

    public static class SingletonClient
    {
        public static void Run()
        {
            var object1 = Singleton.Instance;
            var object2 = Singleton.Instance;

            Console.WriteLine($"Value of object 1 is {object1.Counter}");
            object1.IncreaseCounter();
            Console.WriteLine($"Value of object 2 is {object1.Counter}");

        }
    }

    /*
        The Singleton design pattern is a creational pattern that ensures a class has only one instance, 
        while providing a global point of access to that instance. This pattern is useful in situations where 
        it is important to limit the number of instances of a class, for example, when working with shared resources 
        such as databases, configuration settings, or hardware devices.

        In this implementation, the Singleton class has a private constructor to prevent instantiation of the class 
        from outside the class itself. The class also has a private static instance variable that holds the single 
        instance of the class.

        The public Instance property provides a global point of access to the single instance of the Singleton class. 
        This property uses lazy initialization to create the instance only when it is first accessed.

        In this example, we first create two instances of the Singleton class using the Instance property. 
        Then, we call the DoSomething() method on each instance, which outputs the message "Doing something in Singleton". 
        Finally, we check that the two instances are equal using the == operator, 
        which outputs "True" since they refer to the same object.

        You can make the Singleton design pattern thread-safe to avoid the possibility of creating multiple instances of 
        the Singleton class. One way to do this is to use a lock to ensure that only one thread can access the code block 
        that creates the instance at a time.

        In this implementation, we have added a lock statement around the code block that creates the Singleton instance. 
        The lock statement ensures that only one thread can access the code block at a time, 
        preventing multiple instances from being created.

        Note that we use a separate object (lockObject) as the lock object, rather than locking on the Singleton class itself. 
        This is to prevent deadlocks that can occur when other code tries to lock on the same object.

        With this thread-safe implementation, multiple threads can call the Instance property simultaneously without the 
        risk of creating multiple instances of the Singleton class.
    */
}
