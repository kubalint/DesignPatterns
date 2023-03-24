using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Command
{
    // Command interface
    public interface ICommand
    {
        void Execute();
    }

    // Concrete Command classes
    public class LightOnCommand : ICommand
    {
        private readonly Light _light;

        public LightOnCommand(Light light)
        {
            _light = light;
        }

        public void Execute()
        {
            _light.TurnOn();
        }
    }

    public class LightOffCommand : ICommand
    {
        private readonly Light _light;

        public LightOffCommand(Light light)
        {
            _light = light;
        }

        public void Execute()
        {
            _light.TurnOff();
        }
    }

    // Receiver class
    public class Light
    {
        private bool _isOn = false;

        public void TurnOn()
        {
            _isOn = true;
            Console.WriteLine("Light is on");
        }

        public void TurnOff()
        {
            _isOn = false;
            Console.WriteLine("Light is off");
        }
    }

    // Invoker class
    public class Switch
    {
        private ICommand _onCommand;
        private ICommand _offCommand;

        public Switch(ICommand onCommand, ICommand offCommand)
        {
            _onCommand = onCommand;
            _offCommand = offCommand;
        }

        public void TurnOn()
        {
            _onCommand.Execute();
        }

        public void TurnOff()
        {
            _offCommand.Execute();
        }
    }
    
    public static class CommandClient
    {
        public static void Run()
        {
            // Create the receiver object
            var light = new Light();

            // Create the concrete command objects
            var turnOnCommand = new LightOnCommand(light);
            var turnOffCommand = new LightOffCommand(light);

            // Create the invoker object
            var switchButton = new Switch(turnOnCommand, turnOffCommand);

            // Use the invoker to execute the commands
            switchButton.TurnOn(); // Output: "Light is on"
            switchButton.TurnOff(); // Output: "Light is off"
        }
    }

    /*
        The Command design pattern is a behavioral pattern that allows us to encapsulate a request as an object, 
        thereby allowing us to parameterize clients with different requests, queue or log requests, 
        and support undoable operations. In essence, the Command design pattern turns a request into a standalone object 
        that contains all the information necessary to perform the requested action.

        The key components of the Command pattern are:

            + The Command interface: 
                defines the interface for executing an operation.

            + Concrete Command classes: 
                implement the Command interface and contain the code necessary to execute a specific operation.

            + The Invoker class: 
                holds a Command object and invokes its execute() method.

            + The Receiver class: 
                knows how to perform the operations associated with carrying out a request.

        In this example, the Command interface defines a single method, Execute(), which is implemented by the concrete command classes, 
        LightOnCommand and LightOffCommand. The Light class is the receiver, which knows how to turn the light on and off. 
        The Switch class is the invoker, which holds references to the on and off commands and uses them to turn the light on and off.

        In summary, the Command design pattern allows us to encapsulate requests as objects, which can be passed around and executed as necessary. 
        This provides a more flexible and extensible design than simply calling methods directly on objects.
    */
}
