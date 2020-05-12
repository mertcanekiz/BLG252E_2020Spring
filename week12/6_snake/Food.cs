using SFML.Graphics;
using SFML.System;
using System;
using System.Linq;

namespace snake
{
    class Food : GameObject
    {
        public override void Render()
        {
            var shape = new CircleShape() {
                Position = new Vector2f(X * App.GRID_SIZE, Y * App.GRID_SIZE),
                Radius = App.GRID_SIZE / 2,
                FillColor = Color.Red
            };
            App.Window.Draw(shape);
        }

        public void Place(Snake snake)
        {
            Random r = new Random();
            int x = r.Next(App.COLS);
            int y = r.Next(App.ROWS);
            while (snake.body.Any(b => b.X == x && b.Y == y)) {
                x = r.Next(App.COLS);
                y = r.Next(App.ROWS);
            }
            X = x;
            Y = y;
        }
    }
}