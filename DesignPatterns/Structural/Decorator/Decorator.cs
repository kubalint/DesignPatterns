namespace DesignPatterns.Structural.Decorator
{
    using System;

    // The ICar interface defines the interface for both concrete and decorator objects
    public interface ICar
    {
        string GetDescription();
        int GetSpeed();
        int GetDefense();
        int GetAttack();
    }

    // The ConcreteCar class is the basic implementation of the ICar interface
    public class ConcreteCar : ICar
    {
        private string _description;
        private int _speed;
        private int _defense;
        private int _attack;

        public ConcreteCar(string description, int speed, int defense, int attack)
        {
            _description = description;
            _speed = speed;
            _defense = defense;
            _attack = attack;
        }

        public string GetDescription()
        {
            return _description;
        }

        public int GetSpeed()
        {
            return _speed;
        }

        public int GetDefense()
        {
            return _defense;
        }

        public int GetAttack()
        {
            return _attack;
        }
    }

    // The CarDecorator class has a reference to a ICar object and implements the ICar interface
    public abstract class CarDecorator : ICar
    {
        protected ICar _car;

        public CarDecorator(ICar car)
        {
            _car = car;
        }

        public virtual string GetDescription()
        {
            return _car.GetDescription();
        }

        public virtual int GetSpeed()
        {
            return _car.GetSpeed();
        }

        public virtual int GetDefense()
        {
            return _car.GetDefense();
        }

        public virtual int GetAttack()
        {
            return _car.GetAttack();
        }
    }

    // The SpeedBoost class adds additional speed to the ICar object
    public class SpeedBoost : CarDecorator
    {
        public SpeedBoost(ICar car) : base(car)
        {
        }

        public override string GetDescription()
        {
            return _car.GetDescription() + ", with speed boost";
        }

        public override int GetSpeed()
        {
            return _car.GetSpeed() + 10;
        }
    }

    // The DefenseBoost class adds additional defense to the ICar object
    public class DefenseBoost : CarDecorator
    {
        public DefenseBoost(ICar car) : base(car)
        {
        }

        public override string GetDescription()
        {
            return _car.GetDescription() + ", with defense boost";
        }

        public override int GetDefense()
        {
            return _car.GetDefense() + 5;
        }
    }

    // The AttackBoost class adds additional attack to the ICar object
    public class AttackBoost : CarDecorator
    {
        public AttackBoost(ICar car) : base(car)
        {
        }

        public override string GetDescription()
        {
            return _car.GetDescription() + ", with attack boost";
        }

        public override int GetAttack()
        {
            return _car.GetAttack() + 7;
        }
    }


    public static class DecoratorClient
    {    // Example usage of the Decorator pattern with special cars
        public static void Run()
        {
            // Create a ConcreteCar object
            ICar car = new ConcreteCar("Basic car", 50, 20, 30);

            // Create a SpeedBoost object and wrap the ConcreteCar object
            car = new SpeedBoost(car);

            // Create a DefenseBoost object and wrap the SpeedBoost object
            car = new DefenseBoost(car);

            // Create an AttackBoost object and wrap the DefenseBoost object
            car = new AttackBoost(car);

            // Get the description and decorated properties of the car
            Console.WriteLine(car.GetDescription());
            Console.WriteLine("Speed: " + car.GetSpeed());
            Console.WriteLine("Defense: " + car.GetDefense());
            Console.WriteLine("Attack: " + car.GetAttack());
        }

    }

    /*
        The Decorator pattern is a structural design pattern that allows you to dynamically add functionality to an object by wrapping it in a decorator object. 
        The decorator object has the same interface as the original object, so it can be used as a drop-in replacement, 
        but it adds additional functionality to the original object.

        The Decorator pattern is useful when you want to add functionality to an object without changing its interface 
        or when you want to add functionality to an object at runtime.

        In this example, we have an interface `ICar` that defines the basic properties of a car, 
        including `GetDescription()`, `GetSpeed()`, `GetDefense()`, and `GetAttack()`. 
        We also have a concrete implementation of `ICar` called `ConcreteCar`, 
        which represents a basic car with no special properties.

        We then have a `CarDecorator` abstract class that implements the `ICar` interface and has a reference to another `ICar` object. 
        This is the basis of the Decorator pattern. We then create three concrete decorator classes that extend `CarDecorator` 
        and add additional properties to the `ICar` object. `SpeedBoost` adds speed to the car, `DefenseBoost` adds defense to the car, 
        and `AttackBoost` adds attack to the car.

        In the example usage of the Decorator pattern, we create a `ConcreteCar` object and wrap it in `SpeedBoost`, `DefenseBoost`, and `AttackBoost` 
        decorator objects to add additional properties to the car. We then output the description and decorated properties of the car.

        This example demonstrates how the Decorator pattern can be used to add functionality to an object at runtime 
        without changing its interface. In this case, we were able to add special properties to a car object by wrapping 
        it in decorator objects that added their own behavior.
    */
}
