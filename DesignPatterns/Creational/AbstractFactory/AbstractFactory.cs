using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.AbstractFactory
{
    // Abstract Factory interface
    public interface ICharacterFactory
    {
        IWeapon CreateWeapon();
        IArmor CreateArmor();
        ISpell CreateSpell();
    }

    // Concrete Warrior Factory
    public class WarriorFactory : ICharacterFactory
    {
        public IWeapon CreateWeapon()
        {
            return new Sword();
        }

        public IArmor CreateArmor()
        {
            return new PlateArmor();
        }

        public ISpell CreateSpell()
        {
            return new NullSpell();
        }
    }

    // Concrete Mage Factory
    public class MageFactory : ICharacterFactory
    {
        public IWeapon CreateWeapon()
        {
            return new Wand();
        }

        public IArmor CreateArmor()
        {
            return new Robe();
        }

        public ISpell CreateSpell()
        {
            return new FireballSpell();
        }
    }

    // Abstract product interfaces
    public interface IWeapon
    {
        void Attack();
    }

    public interface IArmor
    {
        void Defend();
    }

    public interface ISpell
    {
        void Cast();
    }

    // Concrete products
    public class Sword : IWeapon
    {
        public void Attack()
        {
            Console.WriteLine("Attacking with a sword!");
        }
    }

    public class PlateArmor : IArmor
    {
        public void Defend()
        {
            Console.WriteLine("Defending with plate armor!");
        }
    }

    public class Wand : IWeapon
    {
        public void Attack()
        {
            Console.WriteLine("Attacking with a wand!");
        }
    }

    public class Robe : IArmor
    {
        public void Defend()
        {
            Console.WriteLine("Defending with a robe!");
        }
    }

    public class NullSpell : ISpell
    {
        public void Cast()
        {
            Console.WriteLine("No spell available.");
        }
    }

    public class FireballSpell : ISpell
    {
        public void Cast()
        {
            Console.WriteLine("Casting fireball spell!");
        }
    }

    // Client code
    public class Game
    {
        private ICharacterFactory characterFactory;

        public Game(ICharacterFactory factory)
        {
            characterFactory = factory;
        }

        public void Play()
        {
            IWeapon weapon = characterFactory.CreateWeapon();
            IArmor armor = characterFactory.CreateArmor();
            ISpell spell = characterFactory.CreateSpell();

            weapon.Attack();
            armor.Defend();
            spell.Cast();
        }
    }

    public class AbstractFactoryClient
    {
        public static void Run()
        {
            // Create a warrior character
            ICharacterFactory factory = new WarriorFactory();
            Game game = new Game(factory);
            game.Play();

            // Create a mage character
            factory = new MageFactory();
            game = new Game(factory);
            game.Play();
        }
    }
    /*
     The Abstract Factory pattern is a creational design pattern that provides an interface for creating 
    families of related or dependent objects without specifying their concrete classes. The pattern 
    encapsulates a group of factories that have a common theme. The Abstract Factory pattern allows us 
    to create objects that are related to each other without having to know their concrete types.

    For example, imagine a game where we have two different character classes: Warriors and Mages. 
    Each class has its own set of weapons, armor, and spells. We can use the Abstract Factory 
    pattern to create families of related objects for each class.
     */
}
