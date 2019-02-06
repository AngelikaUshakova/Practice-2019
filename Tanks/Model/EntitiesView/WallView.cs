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

        public WallView(int x, int y, int width, int height, bool destructible = false, bool isWater = false) : base(x, y, width, height, destructible, isWater)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Pos pos = new Pos { posx = 0, posy = 0 };
            Size size = new Size { width = width, height = height };

            sprite = new Sprite("Wall1.png", pos, size, 1);
        }

        public void Draw(Graphics graf)
        {
            sprite.Draw(graf, X, Y);
        }
    }
}
