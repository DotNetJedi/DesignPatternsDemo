using System;
using System.Collections;
using System.Collections.Generic;

namespace DesignPattern
{
    public interface ICommand
    {
        void Execute();
    }

    class WriteCommand : ICommand
    {
        private readonly Component _component;

        public WriteCommand(Component component)
        {
            _component = component;
        }

        public void Execute()
        {
            Console.WriteLine($"Executing : {_component.Name}");
            Console.ReadLine();
        }
    }

    class SayHelloCommand : ICommand
    {
        private readonly Func<string> _name;

        public SayHelloCommand(IEnumerable<string> args)
        {
            
        }

        public SayHelloCommand(Func<string> name)
        {
            _name = name;
        }

        public void Execute()
        {
            Console.WriteLine($"Hello {_name.Invoke()}");
            Console.ReadLine();
        }
    }
}