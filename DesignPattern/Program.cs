using System;

namespace DesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var menu = new Menu("Root");
            var item1 = new MenuItem("Item 1");
            var item2 = new MenuItem("Item 2");
            
            var item21 = new MenuItem("Item 2.1", new SayHelloCommand(() => DateTime.Now.ToLongTimeString()));
            var item22 = new MenuItem("Item 2.2");

            var menu2 = new Menu("Menu 2");
            menu2.Add(item21);
            menu2.Add(item22);

            menu.Add(item1);
            menu.Add(item2);
            menu.Add(menu2);

            menu.Show();
        }
    }
}
