using Model.EntitiesView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class ListEntities
    {
        public PlayerView Player { get; set; }
        public List<EnemyView> Enemies { get; set; }
        public List<AppleView> Apples { get; set; }
        public List<WallView> Walls { get; set; }
        public List<BulletView> Bullets { get; set; }
        public List<ExplosionView> Explosions { get; set; }
    }
}
