using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.EntitiesView
{
    public class WallView : Wall
    {
        Sprite sprite;
        public Pos posWall = new Pos();
        public Size sizeWall = new Size();

        public WallView(int x, int y, int width, int height, bool destructible = false, bool isWater = false) : base(x, y, width, height, destructible, isWater)
        {
            posWall.posx = x;
            posWall.posy = y;
            sizeWall.width = width;
            sizeWall.height = height;

            Pos pos = new Pos { posx = 0, posy = 0 };

            sprite = new Sprite("Wall1.png", pos, sizeWall, 1);
        }

        public void Draw(Graphics graf)
        {
            sprite.Draw(graf, posWall.posx, posWall.posy);
        }
    }
}
