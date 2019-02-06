using Model.EntitiesView;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class GameModel : IGameModel
    {
        public ListEntities objects;
        private int mapWidth;
        private int mapHeight;

        public GameModel(ListEntities objects, int mapWidth, int mapHeight)
        {
            this.objects = objects;
            this.mapWidth = mapWidth;
            this.mapHeight = mapHeight;
        }

        public void ChangeDiriction(Direction direction)
        {
            throw new NotImplementedException();
        }

        public void Draw(Graphics graf)
        {
            throw new NotImplementedException();
        }

        public void NewGame()
        {
            objects.Apples = new List<AppleView>();
            objects.Enemies = new List<EnemyView>();
            objects.Bullets = new List<BulletView>();
            objects.Walls = new List<WallView>();

            Init init = new Init(objects, mapWidth, mapHeight);
            init.InitWalls();
            init.InitApple();
            init.InitPlayer();
            init.InitEnemies();
        }

        public void Update(int msc)
        {
            objects.Player.Update(msc);
            foreach (var enemy in objects.Enemies)
            {
                enemy.Update(msc);
            }
        }
    }
}
