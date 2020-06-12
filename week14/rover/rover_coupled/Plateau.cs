using System;
using System.Collections.Generic;

namespace rover_coupled
{
    class Plateau
    {
        public int width;
        public int height;

        public List<Rover> rovers = new List<Rover>();

        public Plateau(int width, int height)
        {
            this.width = width;
            this.height = height;
        }
    }
}
