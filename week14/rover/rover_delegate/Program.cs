using System;

namespace rover_delegate
{
    class Program
    {
        static void AddRover(ref Plateau plateau, ref Rover rover)
        {
            rover.CheckHandler = plateau.OnCheck;
            rover.MovedHandler = plateau.OnMoved;
        }

        static void Main(string[] args)
        {
            Plateau plateau = new Plateau(5, 5);
            Rover rover1 = new Rover(1, 2, Direction.NORTH);
            AddRover(ref plateau, ref rover1);

            // LMLMLMLMM
            rover1.Turn(Towards.LEFT);
            rover1.MoveForward();
            rover1.Turn(Towards.LEFT);
            rover1.MoveForward();
            rover1.Turn(Towards.LEFT);
            rover1.MoveForward();
            rover1.Turn(Towards.LEFT);
            rover1.MoveForward();
            rover1.MoveForward();
            rover1.Print();

            // RIP at -1 0 W
            Rover rover2 = new Rover(0, 0, Direction.WEST);
            AddRover(ref plateau, ref rover2);
            rover2.MoveForward();
            rover2.Print();

            // Shouldn't allow another rover to die there
            Rover rover3 = new Rover(0, 0, Direction.WEST);
            AddRover(ref plateau, ref rover3);
            rover3.MoveForward();
            rover3.Print();

            // But they can die towards another direction
            Rover rover4 = new Rover(0, 0, Direction.SOUTH);
            AddRover(ref plateau, ref rover4);
            rover4.MoveForward();
            rover4.Print();

            // Now that direction is full as well
            Rover rover5 = new Rover(0, 0, Direction.SOUTH);
            AddRover(ref plateau, ref rover5);
            rover5.MoveForward();
            rover5.Print();
        }
    }
}
