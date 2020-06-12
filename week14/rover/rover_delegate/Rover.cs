using System;
using System.Collections.Generic;

namespace rover_delegate
{
    public enum Direction
    {
        BEGIN,
        WEST,
        NORTH,
        EAST,
        SOUTH,
        END
    }

    public enum Towards
    {
        LEFT,
        RIGHT,
        NONE
    }

    public struct Location : IEquatable<Location>
    {
        public int x;
        public int y;
        public Direction direction;

        public bool Equals(Location other)
        {
            return x == other.x && y == other.y && direction == other.direction;
        }
    }

    public class Rover
    {
        public Location location;
        public bool canMove = true;

        public Func<Rover, Location, bool> CheckHandler;
        public Action<Location> MovedHandler;

        public Rover(int x, int y, Direction direction)
        {
            this.location = new Location
            {
                x = x,
                y = y,
                direction = direction
            };
        }

        public void Turn(Towards towards)
        {
            if (towards == Towards.LEFT) this.location.direction--;
            else if (towards == Towards.RIGHT) this.location.direction++;

            if (this.location.direction == Direction.BEGIN) this.location.direction = Direction.END - 1;
            else if (this.location.direction == Direction.END) this.location.direction = Direction.BEGIN + 1;
        }

        public void MoveForward()
        {
            Location nextLocation = location;
            switch (location.direction)
            {
                case Direction.WEST:
                    nextLocation.x--;
                    break;
                case Direction.NORTH:
                    nextLocation.y++;
                    break;
                case Direction.EAST:
                    nextLocation.x++;
                    break;
                case Direction.SOUTH:
                    nextLocation.y--;
                    break;
            }

            bool canMove = true;
            if (CheckHandler != null) {
                canMove = CheckHandler.Invoke(this, nextLocation);
            }

            if (canMove)
            {
                location = nextLocation;
                MovedHandler?.Invoke(location);
            }
            else
            {
                Console.WriteLine("I'm sorry Dave, I'm afraid I can't do that.");
            }

        }

        public void Print()
        {
            Console.WriteLine($"{location.x} {location.y} {location.direction}");
        }
    }
}
