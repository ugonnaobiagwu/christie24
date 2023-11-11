using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.Enemies
{
    public interface IBokoblin: IEnemy
    {
        public void EnemyUp();
        public void EnemyDown();
        public void EnemyLeft();
        public void EnemyRight();

        public void TakeDamage();
        public void BokoblinThrow();

        public int getDirection();
        public int getHealth();

        public int xPosition();
        public int yPosition();

        public String getState();
        public void setState(String state);

        public void Draw(SpriteBatch spriteBatch);
        public void Update();
    }
}
