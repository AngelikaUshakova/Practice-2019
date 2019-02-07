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
        public Pos posApple = new Pos();
        public Size sizeApple = new Size();

        public AppleView(int x, int y, int width, int height) : base(x, y, width, height)
        {
            posApple.posx = x;
            posApple.posy = y;
            sizeApple.width = width;
            sizeApple.height = height;

            Pos pos = new Pos { posx = 0, posy = 0 };

            sprite = new Sprite("Apple.png", pos, sizeApple, 1);
        }

        public void Draw(Graphics graf)
        {
            sprite.Draw(graf, posApple.posx, posApple.posy);
        }
    }
}
