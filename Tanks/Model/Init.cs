﻿using Model.EntitiesView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class Init
    {
        Random random = new Random();
        ListEntities objects;
        Collisions collisions = new Collisions();
        private int mapWidth;
        private int mapHeight;

        public Init(ListEntities objects, int mapWidth, int mapHeight)
        {
            this.objects = objects;
            this.mapWidth = mapWidth;
            this.mapHeight = mapHeight;
        }

        public void InitApple()
        {

            Size sizeApple = new Size() { width = 50, height = 50 };
            Pos pos = new Pos()
            {
                posx = random.Next(mapWidth - sizeApple.width),
                posy = random.Next(mapHeight - sizeApple.height)
            };

            for (int i = 0; i < objects.Walls.Count; i++)
            {
                if (collisions.BoxCollides(pos, sizeApple,
                    new Pos() { posx = objects.Walls[i].X, posy = objects.Walls[i].Y },
                    new Size() { width = objects.Walls[i].Width, height = objects.Walls[i].Height }))
                {
                    pos.posx = random.Next(mapWidth - sizeApple.width);
                    pos.posy = random.Next(mapHeight - sizeApple.height);
                    i = -1;
                }
            }
           
            var apple = new AppleView(pos.posx, pos.posy, sizeApple.width, sizeApple.height);

            objects.Apples.Add(apple);
        }

        public void InitPlayer()
        {
            Size sizePlayer = new Size() { width = 50, height = 50 };
            objects.Player = new PlayerView(5, mapHeight - sizePlayer.height - 5, sizePlayer.width, sizePlayer.height,Direction.RIGHT,9);
        }

        public void InitWalls()
        {

            Size sizeWall = new Size() { width = 60, height = 60 };

            WallView[] walls = new WallView[22];

            int y = 60;

            for (int i = 0; i < 3; i++)
            {
                walls[i] = new WallView(60, y, sizeWall.width, sizeWall.height);
                objects.Walls.Add(walls[i]);
                y += 60;
            }

             y = 60;

            for (int i = 3; i < 6; i++)
            {
                walls[i] = new WallView(180, y, sizeWall.width, sizeWall.height);
                objects.Walls.Add(walls[i]);
                y += 60;
            }


            y = 60;

            for (int i = 6; i < 9; i++)
            {
                walls[i] = new WallView(540, y, sizeWall.width, sizeWall.height);
                objects.Walls.Add(walls[i]);
                y += 60;
            }


            y = 60;

            for (int i = 9; i < 12; i++)
            {
                walls[i] = new WallView(660, y, sizeWall.width, sizeWall.height);
                objects.Walls.Add(walls[i]);
                y += 60;
            }


            int x = 60;

            for (int i = 12; i < 15; i++)
            {
                walls[i] = new WallView(x, 360, sizeWall.width, sizeWall.height);
                objects.Walls.Add(walls[i]);
                x += 60;
            }

             x = 540;

            for (int i = 15; i < 18; i++)
            {
                walls[i] = new WallView(x, 360, sizeWall.width, sizeWall.height);
                objects.Walls.Add(walls[i]);
                x += 60;
            }

             x = 300;

            for (int i = 18; i < 21; i++)
            {
                walls[i] = new WallView(x, 300, sizeWall.width, sizeWall.height);
                objects.Walls.Add(walls[i]);
                x += 60;
            }

        }

        public void InitEnemies()
        {
            Size sizeEnemy = new Size() { width = 50, height = 50 };

            for (int i = 0; i < 5; i++)
            {
                Pos pos = new Pos()
                {
                    posx = random.Next(mapWidth - sizeEnemy.width),
                    posy = random.Next(mapHeight - sizeEnemy.height)
                };

                for (int j = 0; j < objects.Walls.Count; j++)
                {
                    if (collisions.BoxCollides(pos, sizeEnemy,
                        new Pos() { posx = objects.Walls[j].X-5, posy = objects.Walls[j].Y-5 },
                        new Size() { width = objects.Walls[j].Width+10, height = objects.Walls[j].Height+10 }))
                    {
                        pos.posx = random.Next(mapWidth - sizeEnemy.width);
                        pos.posy = random.Next(mapHeight - sizeEnemy.height);
                        j = -1;
                    }

                    for (int k = 0; k < objects.Enemies.Count; k++)
                    {
                        if (collisions.BoxCollides(pos, sizeEnemy,
                            new Pos() { posx = objects.Enemies[k].X - 5, posy = objects.Enemies[k].Y - 5 },
                            new Size() { width = objects.Walls[k].Width + 10, height = objects.Walls[k].Height + 10 }))
                        {
                            pos.posx = random.Next(mapWidth - sizeEnemy.width);
                            pos.posy = random.Next(mapHeight - sizeEnemy.height);
                            j = -1;
                            k = -1;
                        }
                    }
                }

                objects.Enemies.Add(new EnemyView(pos.posx, pos.posy, sizeEnemy.width,
                   sizeEnemy.height, RandomDirection(), 9));
            }

            Direction RandomDirection()
            {
                var directions = Enum.GetValues(typeof(Direction));
                return (Direction)directions.GetValue(random.Next(directions.Length));
            }
        }
    }
}
