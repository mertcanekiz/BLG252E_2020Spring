using System;
using System.Collections.Generic;
using System.Threading;
using SFML.Graphics;
using SFML.Window;

namespace snake
{
    class App
    {
        public const int WIDTH = 320;
        public const int HEIGHT = 240;
        public const int GRID_SIZE = 8;
        public const int COLS = WIDTH / GRID_SIZE;
        public const int ROWS = HEIGHT / GRID_SIZE;
        public static RenderWindow Window { get; private set; }
        private List<GameObject> gameObjects = new List<GameObject>();
        private Snake snake;
        private Food food;

        public App() {
            // Create window and set up event handlers
            Window = new RenderWindow(new VideoMode(WIDTH, HEIGHT), "Snake Game");
            Window.Closed += (o, e) => Window.Close();
            Window.KeyPressed += KeyPressed;

            // Create snake and set up AteFood event handler
            snake = new Snake();
            snake.AteFood += OnAteFood;

            // Create food and place it somewhere on screen
            food = new Food();
            food.Place(snake);

            // Add snake and food to gameobjects
            gameObjects.Add(snake);
            gameObjects.Add(food);
        }

        private void OnAteFood(object sender, EventArgs e)
        {
            food.Place(snake);
            snake.grow = true;
        }

        public void Run()
        {
            while (Window.IsOpen) {
                // Input and update
                Window.DispatchEvents();
                snake.Update(food);

                // Render
                Window.Clear(Color.Black);
                foreach (var gameObject in gameObjects) {
                    gameObject.Render();
                }
                Window.Display();

                // Sleep 
                Thread.Sleep(100);
            }
        }

        private void KeyPressed(object sender, SFML.Window.KeyEventArgs e)
        {
            if (e.Code == Keyboard.Key.W || e.Code == Keyboard.Key.Up) {
                snake.Turn(Direction.UP);
            }
            if (e.Code == Keyboard.Key.A || e.Code == Keyboard.Key.Left) {
                snake.Turn(Direction.LEFT);
            }
            if (e.Code == Keyboard.Key.S || e.Code == Keyboard.Key.Down) {
                snake.Turn(Direction.DOWN);
            }
            if (e.Code == Keyboard.Key.D || e.Code == Keyboard.Key.Right) {
                snake.Turn(Direction.RIGHT);
            }
        }
    }
}