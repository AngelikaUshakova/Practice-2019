using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public enum Direction
    {
        LEFT,
        RIGHT,
        UP,
        DOWN 
    }

   public class MovableObject : Object
    {
        public Direction direction;
        public int speed;

        public MovableObject(int x, int y, int width, int height, Direction direction, int speed = 9)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            this.direction = direction;
            this.speed = speed;
        }
    }
}
