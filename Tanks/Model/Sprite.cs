using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public struct Pos
    {
        public int posx;
        public int posy;
    }

    public struct Size
    {
        public int width;
        public int height;
    }

    public class Sprite
    {
        string URL;
        Image sprite;
        public Pos pos;
        Size size;
        int speed;
        double index = 0;
        int frames;

        public Sprite(string URL, Pos pos, Size size, int frames, int speed = 0)
        {
            this.URL = URL;
            this.pos = pos;
            this.size = size;
            this.speed = speed;
            this.frames = frames;
        }

        public void Update(float dt)
        {
            index = speed * dt/10f;
        }

        public void Render()
        {
            if (speed > 0)
            {
                index = index % frames;
            }

            sprite = Image.FromFile(Path.Combine(Directory.GetCurrentDirectory(), "Sprite\\" + URL));
        }

        public void Draw(Graphics graf, int x, int y)
        {
            Render();
            graf.DrawImage(sprite, new Rectangle(x, y, size.width, size.height), new Rectangle(pos.posx + (int)index * size.width, pos.posy, size.width, size.height), GraphicsUnit.Pixel);
        }
    }
}
