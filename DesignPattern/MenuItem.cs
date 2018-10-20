using System;

namespace DesignPattern
{
    class MenuItem : Component
    {
        private readonly ICommand _command;

        public MenuItem(string name, ICommand command = null) : base(name)
        {
            if (command == null)
            {
                _command = new WriteCommand(this);
            }
            else
            {
                _command = command;
            }
        }

        protected override void Select()
        {
            _command?.Execute();
        }
    }
}