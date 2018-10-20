namespace DesignPattern
{
    class Menu : Component
    {
        public Menu(string name) : base(name)
        {
        }

        public void Add(Component component)
        {
            AddComponent(component);
        }

        protected override void Select()
        {
            _current = _items[0];
        }
    }
}