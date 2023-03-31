using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural.Composite
{
    using System;
    using System.Collections.Generic;

    // Component interface
    interface IMenuComponent
    {
        void Display();
    }

    // Composite class
    class Menu : IMenuComponent
    {
        private string _name;
        private List<IMenuComponent> _menuComponents = new List<IMenuComponent>();

        public Menu(string name)
        {
            _name = name;
        }

        public void Add(IMenuComponent menuComponent)
        {
            _menuComponents.Add(menuComponent);
        }

        public void Remove(IMenuComponent menuComponent)
        {
            _menuComponents.Remove(menuComponent);
        }

        public void Display()
        {
            Console.WriteLine(_name);

            foreach (IMenuComponent component in _menuComponents)
            {
                component.Display();
            }
        }
    }

    // Leaf class
    class MenuItem : IMenuComponent
    {
        private string _name;
        private double _price;

        public MenuItem(string name, double price)
        {
            _name = name;
            _price = price;
        }

        public void Display()
        {
            Console.WriteLine("    " + _name + " - $" + _price);
        }
    }
    
    public static class CompositeClient
    {
        public static void Run()
        {
            // Create the top-level menu
            Menu restaurantMenu = new Menu("Restaurant Menu");

            // Create the main menu categories
            Menu appetizersMenu = new Menu("Appetizers");
            Menu entreesMenu = new Menu("Entrees");
            Menu dessertsMenu = new Menu("Desserts");

            // Add menu items to each menu category
            appetizersMenu.Add(new MenuItem("Bruschetta", 8.99));
            appetizersMenu.Add(new MenuItem("Chicken Wings", 10.99));

            entreesMenu.Add(new MenuItem("Steak", 24.99));
            entreesMenu.Add(new MenuItem("Salmon", 19.99));

            dessertsMenu.Add(new MenuItem("Cheesecake", 7.99));
            dessertsMenu.Add(new MenuItem("Chocolate Cake", 6.99));

            // Add the menu categories to the top-level menu
            restaurantMenu.Add(appetizersMenu);
            restaurantMenu.Add(entreesMenu);
            restaurantMenu.Add(dessertsMenu);

            // Display the entire menu
            restaurantMenu.Display();
        }
    }
}
