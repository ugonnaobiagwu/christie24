using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.Enemies
{
    public interface IBokoblin
    {
        public void BokoblinUp();
        public void BokoblinDown();
        public void BokoblinLeft();
        public void BokoblinRight();

        public void TakeDamage();
        public void BokoblinThrow();

        public int getDirection();
        public int getHealth();

        public String getState();
        public void setState(String state);

        public void Update();
    }
}
