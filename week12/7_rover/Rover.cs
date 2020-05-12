using System;

namespace _7_rover
{
    enum Direction { BEGIN, N, W, S, E, END };
    enum Towards { LEFT, RIGHT, NONE };

    class Rover
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Direction Dir { get; set; }

        public void Turn(Towards towards)
        {
            if (towards == Towards.LEFT)     this.Dir++;
            if (towards == Towards.RIGHT)    this.Dir--;
            if (this.Dir == Direction.BEGIN) this.Dir = Direction.END - 1;
            if (this.Dir == Direction.END)   this.Dir = Direction.BEGIN + 1;
        }

        public void Move()
        {
            switch (this.Dir) {
                case Direction.N: Y++; break;
                case Direction.W: X--; break;
                case Direction.S: Y--; break;
                case Direction.E: X++; break;
            }
        }

        public void Print()
        {
            Console.WriteLine($"{X} {Y} {Dir}");
        }
    }
}