using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.EntitiesView
{
   public class AppleView : Apple
    {
        Sprite sprite;

        public AppleView(int x, int y, int width, int height) : base(x, y, width, height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Pos pos = new Pos { posx = 0, posy = 0 };
            Size size = new Size { width = width, height = height };

            sprite = new Sprite("Apple.png", pos, size, 1);
        }

        public void Draw(Graphics graf)
        {
            sprite.Draw(graf, X, Y);
        }
    }
}
