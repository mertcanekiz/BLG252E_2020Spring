using System;

namespace _4_interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            var textArea = new TextArea();
            textArea.Click();
            textArea.RightClick();

            var button = new Button();
            button.Click();
        }
    }
}
