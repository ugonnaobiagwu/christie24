using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.Enemies
{
    public interface IDragon
    {
        public void DragonUp();

        public void DragonDown();

        public void DragonLeft();

        public void DragonRight();

        public int xPosition();
        public int yPosition();

        public int getDirection();

        public void takeDamage();

        public int getHealth();

        public void Update();

        public void DragonShoot();
    }
}
