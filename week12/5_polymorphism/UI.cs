using System;

namespace _5_polymorphism
{
    abstract class UIElement
    {
        public bool IsActive { get; set; }
        public string Text { get; set; }

        void Display()
        {
            Console.WriteLine(Text);
        }
    }

    interface IClickable
    {
        void Click();
    }

    interface IRightClickable
    {
        void RightClick();
    }

    class TextArea : UIElement, IClickable, IRightClickable
    {
        public void Click()
        {
            Console.WriteLine("TextArea clicked");
        }

        public void RightClick()
        {
            Console.WriteLine("TextArea right clicked");
        }
    }

    class Button : UIElement, IClickable
    {
        public void Click()
        {
            Console.WriteLine("Button clicked");
        }
    }

    class Checkbox : UIElement, IClickable, IRightClickable
    {
        public void Click()
        {
            Console.WriteLine("Checkbox clicked");
        }

        public void RightClick()
        {
            Console.WriteLine("Checkbox right clicked");
        }
    }
}