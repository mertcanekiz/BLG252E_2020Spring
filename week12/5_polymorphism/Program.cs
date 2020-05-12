using System;
using System.Linq;
using System.Collections.Generic;

namespace _5_polymorphism
{
    class Program
    {
        static void Main(string[] args)
        {
            var uiElements = new List<UIElement>();
            uiElements.Add(new TextArea() { Text = "Sample text" });
            uiElements.Add(new Button() { Text = "Button" });
            uiElements.Add(new Checkbox() { Text = "Checkbox" });

            foreach (var element in uiElements.OfType<IRightClickable>()) {
                element.RightClick();
            }
        }
    }
}
