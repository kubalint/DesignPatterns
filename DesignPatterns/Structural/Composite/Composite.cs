namespace DesignPatterns.Structural.Composite;

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

/*
    The Composite pattern is a structural design pattern that allows you to treat a group of objects in the same way as you would treat an individual object. 
    It allows you to create a tree-like structure where each node can have one or more children, which can also be nodes themselves. 
    This pattern is useful when you need to work with complex hierarchical structures and want to treat each element uniformly.

    In this example, we create a Menu class that implements the IMenuComponent interface. This class has a list of IMenuComponent objects, 
    which can be either other Menu objects or MenuItem objects. The Add() and Remove() methods are used to add or remove menu components from the list.

    The MenuItem class is a leaf node in the tree structure, which means that it doesn't have any children. 
    It implements the IMenuComponent interface and has a Display() method that simply displays the name and price of the menu item.

    In the Main() method, we create a Menu object for the top-level menu and then create three submenus for appetizers, entrees, and desserts. 
    We add MenuItem objects to each of the submenus, and then add the submenus to the top-level menu. 
    Finally, we call the Display() method on the top-level menu to display the entire menu structure, including all submenus and menu items.
    As you can see, the Menu and MenuItem objects are treated uniformly, and we can create a tree-like structure of menus and menu items using the Composite pattern.

    Overall, the Composite pattern is a powerful tool for managing hierarchical structures, and it can be used in a wide range of applications, 
    from graphical user interfaces to file systems and beyond.
 */
