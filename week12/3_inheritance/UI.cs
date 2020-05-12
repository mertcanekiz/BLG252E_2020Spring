using System;

namespace _3_inheritance
{
    abstract class UIElement
    {
        public bool IsActive { get; set; }
        public string Text { get; set; }

        public abstract void Click();
    }

    class TextArea : UIElement
    {
        public override void Click()
        {
            Console.WriteLine("TextArea clicked");
        }
    }

    class Button : UIElement
    {
        public override void Click()
        {
            Console.WriteLine("Button clicked");
        }
    }

    class Checkbox : UIElement
    {
        public override void Click()
        {
            Console.WriteLine("Checkbox clicked");
        }
    }
}