namespace DesignPatterns.Behavioral.Template_Method;

    public abstract class AbstractClass
    {
        public void TemplateMethod()
        {
            this.Step1();
            this.Step2();
            this.Step3();
        }

        protected abstract void Step1();

        protected abstract void Step2();

        protected abstract void Step3();
    }

    public class ConcreteClass : AbstractClass
    {
        protected override void Step1()
        {
            Console.WriteLine("ConcreteClass: Step1");
        }

        protected override void Step2()
        {
            Console.WriteLine("ConcreteClass: Step2");
        }

        protected override void Step3()
        {
            Console.WriteLine("ConcreteClass: Step3");
        }
    }

    public static class TemplateMethodClient
    {
        public static void Run()
        {
            AbstractClass abstractClass = new ConcreteClass();
            abstractClass.TemplateMethod();
        }
    }

    /*
     The Template Method pattern is a behavioral design pattern that defines the skeleton of an algorithm in a base class, 
    but allows subclasses to override specific steps of the algorithm without changing its overall structure. 
    The idea is to create a base class that defines the overall algorithm, but leave some of the details to be implemented by the subclasses.

    In this example, AbstractClass is the base class that defines the overall algorithm, 
    and ConcreteClass is a subclass that implements the specific steps of the algorithm.

    When the TemplateMethod() method is called on an instance of ConcreteClass, it calls the Step1(), Step2(), and Step3() methods in sequence. 
    These methods are abstract in the AbstractClass, so the ConcreteClass must implement them.

    For a "real-life" usage of it, see EcommerceTemplateMethod.cs

     */

