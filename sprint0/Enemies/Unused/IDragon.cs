using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.Enemies
{
    public interface IDragon: IEnemy
    {
        public void EnemyUp();
        public void EnemyDown();
        public void EnemyLeft();
        public void EnemyRight();

        public int xPosition();
        public int yPosition();

        public int getDirection();

        public void takeDamage();
        public int getHealth();

        public void Draw(SpriteBatch spriteBatch);
        public void Update();

        public void DragonShoot();
    }
}
