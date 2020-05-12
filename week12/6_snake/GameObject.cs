namespace snake
{
    abstract class GameObject
    {
        public int X { get; set; }
        public int Y { get; set; }
        
        public abstract void Render();
    }
}