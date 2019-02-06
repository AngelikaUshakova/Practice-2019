using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class Collisions
    {
        private int mapWidth;
        private int mapHeight;

        public void CheckCollisions(ListEntities objects, int mapWidth, int mapHeight)
        {
            this.mapWidth = mapWidth;
            this.mapHeight = mapHeight;

            CheckPlayerBounds(objects);
        }

        private void CheckPlayerBounds(ListEntities objects)
        {
            if (objects.Player.X < 0)
            {
                objects.Player.X = 0;
            }
            else if (objects.Player.X > mapWidth - objects.Player.Width)
            {
                objects.Player.X = mapWidth - objects.Player.Width;
            }

            if (objects.Player.Y < 0)
            {
                objects.Player.Y = 0;
            }
            else if (objects.Player.Y > mapHeight - objects.Player.Height)
            {
                objects.Player.Y = mapHeight - objects.Player.Height;
            }
        }

        public bool BoxCollides(Pos pos1, Size size1, Pos pos2, Size size2)
        {
            return Collides(pos1.posx,pos1.posy,
                            pos1.posx + size1.width,pos1.posy + size1.height,
                            pos2.posx, pos2.posy,
                            pos2.posx + size2.width, pos2.posy + size2.height);
        }

        private bool Collides(double x1, double y1, double dx1, double dy1, double x2, double y2, double dx2, double dy2)
        {
            return !(dx1 <= x2 || x1 > dx2 ||
                     dy1 <= y2 || y1 > dy2);
        }
    }
}
