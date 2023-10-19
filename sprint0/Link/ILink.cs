using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.Link
{
    public interface ILink
    {
        public void LinkUp();
        public void LinkDown();
        public void LinkLeft();
        public void LinkRight();
        public void LinkTakeDamage();
        public void LinkUseItem();
        public String GetState();
        public int GetXVal();
        public int GetYVal();
        public String GetDirection();
        public int GetHealth();
        public void Update();
        public void SetLink(ILink link);
        public void SetState(String state);
    }
}
