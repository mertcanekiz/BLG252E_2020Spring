using System;

namespace _3_inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            var textArea = new TextArea();
            var button = new Button();
            var checkbox = new Checkbox();

            textArea.Click();
            button.Click();
            checkbox.Click();
        }
    }
}
