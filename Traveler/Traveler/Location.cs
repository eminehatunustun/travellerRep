using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Traveler
{
  public  class Location
    {
        public Point p { get; set; }
        public static Point move(char direction, Point p)
        {
            switch (direction)
            {
                case 'E': p.X = p.X + 1; break;
                case 'S': p.Y = p.Y - 1; break;
                case 'W': p.X = p.X - 1; break;
                case 'N': p.Y = p.Y + 1; break;
                default:
                    break;
            }
            return p;
        }
    }
}
