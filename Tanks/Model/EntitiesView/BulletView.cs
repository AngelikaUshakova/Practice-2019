using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.EntitiesView
{
    public class BulletView : Bullet
    {
        public Sprite sprite;

        public Pos posBullet = new Pos();
        public Size sizeBullet = new Size();
        public bool senderPlayer;

        public BulletView(int x, int y, int width, int height,  Direction direction, bool senderPlayer, int speed = 0) : base(x, y, width, height, direction, speed)
        {
            posBullet.posx = x;
            posBullet.posy = y;
            sizeBullet.width = width;
            sizeBullet.height = height;
            this.senderPlayer = senderPlayer;
            Pos pos = new Pos { posx = 0, posy = 0 };

            sprite = new Sprite("Bullet.png", pos, sizeBullet, 1);
        }

        public void Draw(Graphics graf)
        {
            sprite.Draw(graf, posBullet.posx, posBullet.posy);
        }
    }
}
