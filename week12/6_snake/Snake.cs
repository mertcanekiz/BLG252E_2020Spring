using System;
using System.Linq;
using System.Collections.Generic;
using SFML.System;
using SFML.Graphics;

namespace snake
{
    enum Direction {
        UP, LEFT, DOWN, RIGHT
    }

    class SnakeBodyPart : GameObject
    {
        public SnakeBodyPart(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public override void Render()
        {
            var shape = new RectangleShape() {
                Position = new Vector2f(X * App.GRID_SIZE, Y * App.GRID_SIZE),
                Size = new Vector2f(App.GRID_SIZE, App.GRID_SIZE),
                FillColor = Color.Green
            };
            App.Window.Draw(shape);
        }
    }

    class Snake : GameObject
    {
        public List<SnakeBodyPart> body;
        private Direction direction;
        public bool grow = false;
        public EventHandler AteFood;

        public Snake()
        {
            body = new List<SnakeBodyPart>();
            body.Add(new SnakeBodyPart(10, 10));
            direction = Direction.UP;
            this.grow = false;
        }

        public override void Render()
        {
            foreach (var part in body) {
                part.Render();
            }
        }

        public void Turn(Direction direction)
        {
            int opposite = ((int)direction - 2 + 4) % 4;
            if ((int)this.direction != opposite) {
                this.direction = direction;
            }
        }

        public void Update(Food food)
        {
            // Calculate the new (x,y) coordinates
            var head = body.Last();
            int x = 0, y = 0;
            switch (direction) {
                case Direction.UP:
                    x = head.X;
                    y = head.Y - 1;
                    break;
                case Direction.RIGHT:
                    x = head.X + 1;
                    y = head.Y;
                    break;
                case Direction.DOWN:
                    x = head.X;
                    y = head.Y + 1;
                    break;
                case Direction.LEFT:
                    x = head.X - 1;
                    y = head.Y;
                    break;
            }

            // For wrapping around the screen
            x = (x + App.COLS) % App.COLS;
            y = (y + App.ROWS) % App.ROWS;
            
            // If the current (x,y) coordinates are on top of food, eat it (fire the AteFood event)
            if (x == food.X && y == food.Y) {
                AteFood?.Invoke(this, EventArgs.Empty);
            }

            // If the current (x,y) coordinates are found inside the body
            if (body.Any(b => b.X == x && b.Y == y)) {
                Environment.Exit(0);
            }
            // Add the current (x,y) to body
            body.Add(new SnakeBodyPart(x, y));

            // If we are not growing, remove the tail
            if (grow == false) {
                body.RemoveAt(0);
            }
            grow = false;
        }
    }
}