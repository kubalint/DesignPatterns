namespace DesignPatterns.Behavioral.Observer
{
    using System;
    using System.Collections.Generic;

    // Define the observer interface
    public interface IObserver
    {
        void Update();
    }

    // Define the subject interface
    public interface ISubject
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void Notify();
        void SetState(string value);
        string GetState();
    }

    // Define a concrete subject
    public class ConcreteSubject : ISubject
    {
        private List<IObserver> observers = new List<IObserver>();
        private string state;

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
                observer.Update();
            }
        }

        public string GetState()
        {
            return this.state;
        }

        public void SetState(string value)
        {
            this.state = value;
            Notify();
        }
    }

    // Define a concrete observer
    public class ConcreteObserver : IObserver
    {
        private string name;
        private ISubject subject;

        public ConcreteObserver(string name, ISubject subject)
        {
            this.name = name;
            this.subject = subject;
            this.subject.Attach(this);
        }

        public void Update()
        {
            Console.WriteLine("Observer {0}'s new state is {1}",
                name, subject.GetState());
        }
    }
    
    public static class ObserverClient
    {
        public static void Run()
        {
            ISubject subject = new ConcreteSubject();

            new ConcreteObserver("Observer 1", subject);
            new ConcreteObserver("Observer 2", subject);
            new ConcreteObserver("Observer 3", subject);

            subject.SetState("New State");
        }
    }

    /*
        The Observer pattern is a behavioral design pattern that allows an object (called the subject) to maintain a list of its dependents 
        (called observers) and notify them automatically whenever the state of the subject changes.

        In this pattern, the subject is responsible for notifying its observers when its state changes, 
        and the observers can choose to update their own state accordingly.

        In this example, we have a subject (the ConcreteSubject class) and three observers (the ConcreteObserver class). 
        The subject maintains a list of observers and notifies them whenever its state changes. 
        The observers update their own state accordingly.

        In the ExampleUsage class, we create a ConcreteSubject object and three ConcreteObserver objects. 
        We attach the observers to the subject and set the subject's state to "New State". 
        This triggers a notification to all the observers, who print out the subject's new state.
     */
}
