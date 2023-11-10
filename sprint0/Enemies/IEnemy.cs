using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.Enemies
{
    public interface IEnemy
    {
        public void EnemyUp();
        public void EnemyDown();
        public void EnemyLeft();
        public void EnemyRight();
        public void ChangeEnemyY(int change);

        public void ChangeEnemyX(int change);

        public void Update();
        public void Draw(SpriteBatch spriteBatch);
    }
}
