using Microsoft.Xna.Framework.Graphics;
using sprint0.LinkObj;
using sprint0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static sprint0.Globals;

namespace sprint0.LinkObj
{

    public interface ILink : IGameObject
    {
        public void LinkUp();
        public void LinkDown();
        public void LinkLeft();
        public void LinkRight();
        public void LinkTakeDamage();
        public String GetState();
        public Direction GetDirection();
        public int GetHealth();
        public void SetLink(ILink link);
        public void SetState(Link.State state);
        public void SetSprite(ISprite newSprite);
        public void GainHealth(int addedHealth);
        public void ChangeXandYValue(int x, int y);


    }
}