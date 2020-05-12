using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace _7_rover
{
    class Program
    {
        static void Main(string[] args)
        {
            var plateauCoordinates = Console.ReadLine().Split(' ');
            var rovers = new List<Rover>();
            while (true) {
                try {
                    string[] roverLocation = Console.ReadLine().Split(' ');
                    if (roverLocation[0] == "q") break;
                    
                    char[] commands = Console.ReadLine().ToCharArray();
                    
                    Rover rover = new Rover {
                        X = int.Parse(roverLocation[0]),
                        Y = int.Parse(roverLocation[1]),
                        Dir = (Direction)Enum.Parse(typeof(Direction), roverLocation[2])
                    };
                    
                    foreach (char cmd in commands) {
                        switch (cmd) {
                            case 'L': rover.Turn(Towards.LEFT); break;
                            case 'R': rover.Turn(Towards.RIGHT); break;
                            case 'M': rover.Move(); break;
                        }
                    }
                    
                    rovers.Add(rover);
                } catch (Exception ex) {
                    Console.Error.WriteLine("An error occurred. Please try again.");
                }
            }
            rovers.ForEach(r => r.Print());
        }
    }
}
