using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.Enemies
{
    public interface IOktorok
    {
        public void OktorokUp();
        public void OktorokDown();
        public void OktorokLeft();
        public void OktorokRight();

        public void TakeDamage();
        public void OktorokShoot();

        public int getDirection();
        public int getHealth();

        public String getState();
        public void setState(String state);

        public void Update();
    }
}
