using Microsoft.Xna.Framework.Graphics;
using sprint0.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.Link
{
    internal class ItemUseLink : ILink
    {
        SpriteBatch SpriteBatch;
        SpriteFactory LinkFactory;
        ILink LinkObj;
        /*NOTE: This number needs to be updated to reflect the actual length of the animation*/
        int timer = 10;
        public ItemUseLink(SpriteFactory linkFactory, SpriteBatch spriteBatch, ILink link)
        {
            LinkFactory = linkFactory;
            SpriteBatch = spriteBatch;
            LinkObj = link;
        }
        /*Link can't move while using an item*/
        public void LinkUp() { }
        public void LinkDown() { }
        public void LinkLeft() { }
        public void LinkRight() { }
        public void LinkUseItem() { }
        public void LinkTakeDamage() 
        {
            LinkObj.LinkTakeDamage();           
        }
        public int GetXVal()
        {
            return LinkObj.GetXVal();
        }
        public int GetYVal()
        {
            return LinkObj.GetYVal();
        }
        public String GetDirection()
        {
            return LinkObj.GetDirection();
        }
        public int GetHealth()
        {
            return LinkObj.GetHealth();
        }
        public String GetState()
        {
            return LinkObj.GetState();
        }
        public void SetState(String newState)
        {
            LinkObj.SetState(newState);
        }
        public void SetLink(ILink link)
        {
            LinkObj.SetLink(link);
        }
        /*WARNING: This may be a cause of issues, its possible that it may not reset link and instead loop, but I don't think it will.
         PARRALLEL CODE: ItemUseLink.cs*/
        public void RemoveDecorator()
        {
            LinkObj.SetLink(LinkObj);
        }
        public void Update()
        {
            LinkObj.Update();
            if(timer == 0)
            {
                LinkObj.SetState("Default");
                RemoveDecorator();
            }
            else
            {   if(!LinkObj.GetState().Equals("UseItem"))
                    //LinkFactory.useItem();
                LinkFactory.Draw(SpriteBatch, LinkObj.GetXVal(), LinkObj.GetYVal());
            }
            LinkObj.Update();
            
        }
    }
}
