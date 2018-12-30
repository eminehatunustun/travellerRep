using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traveler
{
  public  class Direction
    {
        public char d { get; set; }


        public static char findDirection(char turn, char direction)
        {
            switch (direction)
            {
                case 'N':
                    if (turn == 'L')
                        direction = 'W';
                    else
                        direction = 'E';
                    break;
                case 'S':
                    if (turn == 'L')
                        direction = 'E';
                    else
                        direction = 'W';
                    break;

                case 'E':
                    if (turn == 'L')
                        direction = 'N';
                    else
                        direction = 'S';
                    break;
                case 'W':
                    if (turn == 'L')
                        direction = 'S';
                    else
                        direction = 'N';
                    break;


                default:
                    break;
            }
            return direction;
        }
    }
}
