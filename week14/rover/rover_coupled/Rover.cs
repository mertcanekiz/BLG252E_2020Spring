using System;
using System.Linq;
using System.Collections.Generic;

namespace rover_coupled
{
    enum Direction
    {
        BEGIN,
        N,
        E,
        S,
        W,
        END
    }

    enum Towards
    {
        LEFT,
        RIGHT
    }

    class RoverCollisionException : Exception
    {
        public RoverCollisionException(int x, int y)
            : base($"There is already a rover at ({x}, {y})")
            {}
    }

    class RoverOutOfBoundsException : Exception
    {
        public RoverOutOfBoundsException(int x, int y)
            : base($"Out of bounds at ({x}, {y})")
            {}
    }

    class Rover
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Direction Dir { get; set; }

        public static List<Rover> rovers = new List<Rover>();
        public static int PLATEAU_WIDTH;
        public static int PLATEAU_HEIGHT;
        
        public Rover(int x, int y, Direction direction)
        {
            X = x;
            Y = y;
            Dir = direction;
        }

        public static Rover AddRover(int x, int y, Direction dir)
        {
            if (rovers.Any(r => r.X == x && r.Y == y))
            {
                throw new RoverCollisionException(x, y);
            }
            else
            {
                Rover rover = new Rover(x, y, dir);
                rovers.Add(rover);
                return rover;
            }
        }

        public void Turn(Towards towards)
        {
            if (towards == Towards.LEFT) this.Dir--;
            else if (towards == Towards.RIGHT) this.Dir++;

            if (this.Dir == Direction.BEGIN) this.Dir = Direction.END - 1;
            else if (this.Dir == Direction.END) this.Dir = Direction.BEGIN + 1;
        }

        public void Move()
        {
            int nextX = X;
            int nextY = Y;
            switch (this.Dir)
            {
                case Direction.N: nextY++; break;
                case Direction.E: nextX++; break;
                case Direction.S: nextY--; break;
                case Direction.W: nextX--; break;
            }
            // TODO: Out of bounds checking
            if (nextX < 0 || nextX >= PLATEAU_WIDTH || nextY < 0 || nextY >= PLATEAU_HEIGHT)
            {
                throw new RoverOutOfBoundsException(X, Y);
            }
            else if (rovers.Any(r => r.X == nextX && r.Y == nextY))
            {
                throw new RoverCollisionException(nextX, nextY);
            }
            else {
                X = nextX;
                Y = nextY;
            }
        }

        public static void PrintAll()
        {
            foreach (var rover in rovers)
            {
                Console.WriteLine($"{rover.X} {rover.Y} {rover.Dir}");
            }
        }
    }
}
