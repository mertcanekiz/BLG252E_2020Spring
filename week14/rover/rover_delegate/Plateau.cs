using System;
using System.Collections.Generic;

namespace rover_delegate
{
    public class Plateau
    {
        public int width;
        public int height;
        public List<Location> ripLocations;

        public Plateau(int width, int height)
        {
            this.width = width;
            this.height = height;
            this.ripLocations = new List<Location>();
        }

        public bool OnCheck(Rover rover, Location nextLocation)
        {
            if (nextLocation.x < 0 || nextLocation.x > width ||
                nextLocation.y < 0 || nextLocation.y > height)
            {
                if (ripLocations.Contains(nextLocation)) {
                    return false;
                }
            }
            return true;
        }

        public void OnMoved(Location location)
        {
            if (location.x < 0 || location.x > width ||
                location.y < 0 || location.y > height)
            {
                ripLocations.Add(location);
                Console.WriteLine($"RIP at {location.x} {location.y} {location.direction}");
            }
        }
    }
}
