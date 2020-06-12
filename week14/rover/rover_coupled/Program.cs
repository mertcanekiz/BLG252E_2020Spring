using System;
using System.Linq;
using System.Collections.Generic;

namespace rover_coupled
{
    class QuitException : Exception
    {
        public QuitException() : base() {}
    }

    class Program
    {
        static void Main(string[] args)
        {
            GetPlateauCoordinates();
            var rovers = new List<Rover>();
            while (true)
            {
                try
                {
                    Rover rover = CreateRover();
                    ExecuteCommands(rover);
                }
                catch (QuitException)
                {
                    Console.WriteLine("Quitting");
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Please try a different command.");
                }
            }
            Rover.PrintAll();
        }

        static void GetPlateauCoordinates()
        {
            while (true) {
                Console.Write("Enter plateau dimensions: ");
                var plateauCoordinates = Console.ReadLine().Split(' ');
                try {
                    int w = int.Parse(plateauCoordinates[0]);
                    int h = int.Parse(plateauCoordinates[1]);
                    Rover.PLATEAU_WIDTH = w;
                    Rover.PLATEAU_HEIGHT = h;
                    break;
                }
                catch (Exception)
                {
                    Console.Error.WriteLine("Invalid plateau dimensions entered. Please try again.");
                }
            }
        }

        static Rover CreateRover()
        {
            int x, y;
            Direction dir;
            while (true) {
                try {
                    Console.Write("Enter rover location: ");
                    string[] roverLocation = Console.ReadLine().Split(' ');
                    if (roverLocation[0] == "q") throw new QuitException();
                    x = int.Parse(roverLocation[0]);
                    y = int.Parse(roverLocation[1]);
                    dir = (Direction)Enum.Parse(typeof(Direction), roverLocation[2]);
                    break;
                }
                catch (QuitException)
                {
                    throw;
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid rover location. Please try again.");
                }
            }
            Rover rover = Rover.AddRover(x, y, dir);
            return rover;
        }

        static void ExecuteCommands(Rover rover)
        {
            while (true) {
                char[] commands = GetCommands();
                Rover dummy = new Rover(rover.X, rover.Y, rover.Dir);
                try {
                    foreach (char cmd in commands)
                    {
                        switch (cmd)
                        {
                            case 'L': dummy.Turn(Towards.LEFT); break;
                            case 'R': dummy.Turn(Towards.RIGHT); break;
                            case 'M': dummy.Move(); break;
                        }
                    }
                    rover.X = dummy.X;
                    rover.Y = dummy.Y;
                    rover.Dir = dummy.Dir;
                    break;
                } catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Please try a different command.");
                }
            }
        }

        static char[] GetCommands()
        {
            char[] commands;
            while (true) {
                Console.Write("Enter commands: ");
                commands = Console.ReadLine().ToCharArray();
                if (!commands.All(c => c == 'L' || c == 'R' || c == 'M')) {
                    Console.Error.WriteLine("Invalid command. Please try again.");
                    continue;
                }
                break;
            }
            return commands;
        }
    }
}
