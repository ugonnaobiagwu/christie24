using Microsoft.Xna.Framework.Graphics;
using sprint0.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.Link
{
    /*Having issues figureing out how to link the decorator and Link class*/
    internal class DamagedLink : ILink
    {
        SpriteFactory LinkFactory;
        Link LinkObj;
        public DamagedLink(SpriteFactory linkFactory, Link link)
        {
            LinkFactory = linkFactory;
            LinkObj = link;
        }

        /*Could do something like: LinkObj.takeDamage(0 followed by the attack immediately*/
        public void LinkUp()
        {
            LinkObj.LinkUp();
        }

        public void LinkDown()
        {
           LinkObj.LinkDown();
        }

        public void LinkRight()
        {
            LinkObj.LinkRight();
        }

        public void LinkLeft()
        {
            LinkObj.LinkLeft(); 
        }
        public void LinkAttack()
        {
            LinkObj.LinkAttack();
            
        }
        public void RemoveDecorator()
        {
            
        }
    }
}
