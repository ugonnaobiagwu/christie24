using sprint0.AnimatedSpriteFactory;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static sprint0.Globals;
using sprint0.LinkObj;

namespace sprint0.LinkObj
{

    public interface ILink : IGameObject
    {
        public void LinkUp();
        public void LinkDown();
        public void LinkLeft();
        public void LinkRight();
        public void LinkTakeDamage();
        public void LinkUseItem();
        public String GetState();
        public Direction GetDirection();
        public int GetHealth();
        public void SetLink(ILink link);
        public void SetState(Link.State newState);
        public void SetSprite(ISprite newSprite);


    } 
}