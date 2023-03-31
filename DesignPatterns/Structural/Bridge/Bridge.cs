using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural.Bridge
{
    // Abstraction
    public abstract class Shape
    {
        protected IColor color;

        public Shape(IColor color)
        {
            this.color = color;
        }

        public abstract void Draw();
    }

    // Refined Abstraction
    public class Circle : Shape
    {
        private int x, y, radius;

        public Circle(int x, int y, int radius, IColor color)
            : base(color)
        {
            this.x = x;
            this.y = y;
            this.radius = radius;
        }

        public override void Draw()
        {
            Console.WriteLine("Drawing Circle [Color: " + color.FillColor() + ", X: " + x + ", Y: " + y + ", Radius: " + radius + "]");
        }
    }

    // Implementor
    public interface IColor
    {
        string FillColor();
    }

    // Concrete Implementor
    public class RedColor : IColor
    {
        public string FillColor()
        {
            return "Red";
        }
    }

    // Concrete Implementor
    public class GreenColor : IColor
    {
        public string FillColor()
        {
            return "Green";
        }
    }

    // Client
    public static class BridgeClient
    {
        public static void Run()
        {
            IColor color = new RedColor();

            Shape circle = new Circle(10, 10, 5, color);
            circle.Draw();

            color = new GreenColor();
            circle = new Circle(20, 20, 10, color);
            circle.Draw();
        }
    }

    /*
        The Bridge pattern is a design pattern that decouples an abstraction from its implementation so that the two can vary independently. 
        In other words, it allows you to separate the interface of an object from its implementation. 
        This is useful when you want to vary both the abstraction and the implementation independently.

        Let's consider an example to better understand how the Bridge pattern works. 
        Suppose we have a shape hierarchy with several different types of shapes such as circles, 
        rectangles, and squares. We also have a color hierarchy with several different colors such as red, green, and blue. 
        We want to be able to draw the shapes with different colors.

        We can use the Bridge pattern to achieve this by defining two hierarchies, one for the shapes and one for the colors, 
        and then creating a bridge between them. The bridge is an interface that connects the two hierarchies and allows them to vary independently.

        In this example, we have an abstract Shape class that defines the basic properties and behavior of a shape. 
        We also have a concrete Circle class that implements the Shape class and adds additional properties and behavior specific to a circle.

        We then have an IColor interface that defines the basic properties and behavior of a color. 
        We also have two concrete color classes RedColor and GreenColor that implement the IColor interface and add additional properties 
        and behavior specific to their respective colors.

        Finally, we have a Client class that creates instances of the Shape and IColor classes and connects them using the bridge interface. 
        The Client class is responsible for creating and using the objects, while the bridge interface (the IColor interface) allows the objects to vary independently.

        In this example, we can easily add new shapes or colors without having to modify the existing code. 
        We can also vary the shapes and colors independently, which makes it easy to create new combinations of shapes and colors.
     */
}
