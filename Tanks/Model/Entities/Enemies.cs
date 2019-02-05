using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Enemies : MovableObject
    {
        public Enemies(int x, int y, int width, int height, Direction direction, int speed) : base(x, y, width, height, direction, speed)
        {
        } 
    }
}
