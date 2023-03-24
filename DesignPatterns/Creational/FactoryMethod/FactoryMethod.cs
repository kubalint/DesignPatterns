namespace DesignPatterns.Creational.FactoryMethod
{
    using System;

    // Abstract class for character factories
    public abstract class CharacterFactory<T> where T : Character
    {
        public abstract T CreateCharacter();
    }

    // Concrete subclass for warrior factories
    public class WarriorFactory : CharacterFactory<Warrior>
    {
        public override Warrior CreateCharacter()
        {
            return new Warrior();
        }
    }

    // Concrete subclass for mage factories
    public class MageFactory : CharacterFactory<Mage>
    {
        public override Mage CreateCharacter()
        {
            return new Mage();
        }
    }

    // Abstract class for characters
    public abstract class Character
    {
        public string Name { get; set; }
        public int Level { get; set; }
    }

    // Concrete subclass for warrior characters
    public class Warrior : Character
    {
        public int HealthPoints { get; set; }
        public int AttackPoints { get; set; }
    }

    // Concrete subclass for mage characters
    public class Mage : Character
    {
        public int MagicPoints { get; set; }
        public string[] Spells { get; set; }
    }

    // Client code
    public class FactoryMethodClient
    {
        public static void Run()
        {
            // Create a warrior character using a warrior factory
            CharacterFactory<Warrior> warriorFactory = new WarriorFactory();
            Warrior warrior = warriorFactory.CreateCharacter();
            warrior.Name = "Conan";
            warrior.Level = 10;
            warrior.HealthPoints = 100;
            warrior.AttackPoints = 50;

            Console.WriteLine($"Warrior {warrior.Name} (level {warrior.Level}) has {warrior.HealthPoints} health points and {warrior.AttackPoints} attack points.");

            // Create a mage character using a mage factory
            CharacterFactory<Mage> mageFactory = new MageFactory();
            Mage mage = mageFactory.CreateCharacter();
            mage.Name = "Gandalf";
            mage.Level = 10;
            mage.MagicPoints = 100;
            mage.Spells = new string[] { "Fireball", "Ice Storm", "Lightning Bolt" };

            Console.WriteLine($"Mage {mage.Name} (level {mage.Level}) has {mage.MagicPoints} magic points and knows the following spells: {string.Join(", ", mage.Spells)}.");
        }
    }


    /*
    The Abstract Method Design Pattern is a creational design pattern that provides an interface for creating families of related 
    objects without specifying concrete classes. In other words, it defines a skeleton for creating objects but leaves the actual 
    implementation to its subclasses.


    The Abstract Method Design Pattern is also known as the Factory Method Pattern, and it is used in situations where a class cannot 
    anticipate the type of objects it needs to create. Instead, the responsibility of creating objects is delegated to its subclasses,
    which can decide which type of object to create based on their specific requirements.


    One of the most common use cases for the Abstract Method Design Pattern is in object-oriented programming languages that do not support 
    multiple inheritance. In such languages, a class can only inherit from one superclass, but it can implement multiple interfaces. 
    The Abstract Method Design Pattern allows a class to create objects of different types by implementing different interfaces.


    Here is an example of how the Abstract Method Design Pattern can be used in a software application:

    Suppose you are building a game that has different types of characters, such as warriors, mages, and archers. 
    Each character has different attributes, such as health points, attack points, and defense points. However, 
    each character also has common features, such as a name, a level, and a set of skills.

    In this case, you can use the Abstract Method Design Pattern to create a CharacterFactory abstract class that defines 
    a method for creating a character object. You can then create different concrete subclasses of the CharacterFactory class, 
    such as WarriorFactory, MageFactory, and ArcherFactory. Each subclass can implement the createCharacter method in its own way, 
    depending on the specific attributes and skills of its character type.


    For example, the WarriorFactory subclass can create a character object with high health points and attack points, 
    while the MageFactory subclass can create a character object with high magic points and spells. The ArcherFactory subclass can create 
    a character object with high agility and ranged attacks.

    In this way, the Abstract Method Design Pattern allows you to create different types of characters without having to modify the existing code. 
    You can simply create a new subclass of the CharacterFactory class that implements the createCharacter method in a new way. 
    This makes your code more flexible, maintainable, and extensible.

    In this updated implementation, we use a generic type parameter T to represent the concrete type of character that the factory creates. 
    The CharacterFactory abstract class is now generic, with T as a type constraint on the CreateCharacter() method. The concrete WarriorFactory 
    and MageFactory subclasses implement the generic CreateCharacter() method to return instances of Warrior and Mage classes respectively.

    In the FactoryMethodClient class, we create instances of Warrior and Mage characters using their respective factories, 
    and we can access their properties directly without casting.
    */
}
