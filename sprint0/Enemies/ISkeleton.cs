using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.Enemies
{
    public interface ISkeleton
    {
        public void SkeletonUp();

        public void SkeletonDown();

        public void SkeletonLeft();

        public void SkeletonRight();

        public int getDirection();

        public void takeDamage();

        public int getHealth();

        public void Update();
    }
}
