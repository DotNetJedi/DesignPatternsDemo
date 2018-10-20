using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace DesignPattern
{
    abstract class Component
    {
        protected List<Component> _items = new List<Component>();
        private string _name;
        private int _level;
        private Component _parent;
        protected static Component _current;

        protected Component(string name)
        {
            _name = name;
        }

        public string Name => _name;

        public void Display(Component component = null)
        {
            Console.WriteLine(_current._parent._name);
            Console.WriteLine();
            foreach (var item in _current._parent._items)
            {
                var isSelected = item._name == component?._name;

                if (isSelected)
                {
                    Console.WriteLine($"* {item._name}");
                }
                else
                {
                    Console.WriteLine($"  {item._name}");
                }
            }
        }

        protected abstract void Select();

        public void Show()
        {
            if (_current == null) _current = this._items[0];

            while (true)
            {
                Console.Clear();
                Display(_current);

                var consoleKeyInfo = Console.ReadKey();

                if (consoleKeyInfo.Key == ConsoleKey.Enter)
                {
                    _current.Select();
                } else if (consoleKeyInfo.Key == ConsoleKey.Backspace)
                {
                    if (_current._parent != null) _current = _current._parent;
                    if (_current._parent == null) break;

                } else if (consoleKeyInfo.Key == ConsoleKey.DownArrow)
                {
                    if (_current._parent != null)
                    {
                        var currentIndex = _current._parent._items.FindIndex(c => c._name == _current._name);
                        if (_current._parent._items.Count > currentIndex + 1)
                        {
                            _current = _current._parent._items[currentIndex + 1];
                        }
                    }
                } else if (consoleKeyInfo.Key == ConsoleKey.UpArrow)
                {
                    if (_current._parent != null)
                    {
                        var currentIndex = _current._parent._items.FindIndex(c => c._name == _current._name);
                        if (currentIndex > 0)
                        {
                            _current = _current._parent._items[currentIndex - 1];
                        }
                    }
                }
            }
        }

        protected void AddComponent(Component component)
        {
            component._parent = this;
            _items.Add(component);
        }
    }
}
