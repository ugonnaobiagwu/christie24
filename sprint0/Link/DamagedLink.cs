using Microsoft.Xna.Framework.Graphics;
using sprint0.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.Link
{
    /*Having issues figuring out how to link the decorator and Link class*/
    internal class DamagedLink : ILink
    {
        SpriteFactory LinkFactory;
        ILink LinkObj;
        SpriteBatch SpriteBatch;
        /*This is arbitrary*/
        int timer = 20;
        public DamagedLink(SpriteFactory linkFactory, ILink link, SpriteBatch spriteBatch)
        {
            LinkFactory = linkFactory;
            SpriteBatch = spriteBatch;
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
        public void LinkUseItem()
        {
            LinkObj.LinkUseItem();
        }
        public void LinkTakeDamage() 
        { 
            /*Can't Take Damage*/
        }
        
        /*WARNING: This may be a cause of issues, its possible that it may not reset link and instead loop.
         PARRALLEL CODE: ItemUseLink.cs*/
        public void RemoveDecorator()
        {
           LinkObj.SetLink(LinkObj);
        }
        public String GetState()
        {
            return LinkObj.GetState();
        }
        public String GetDirection()
        {
            return LinkObj.GetDirection();
        }
        public int GetXVal()
        {
            return LinkObj.GetXVal();
        }
        public int GetYVal()
        {
            return LinkObj.GetYVal();
        }
        public int GetHealth()
        {
            return LinkObj.GetHealth();
        }
        public void SetState(String newState)
        {
            LinkObj.SetState(newState);
        }
        public void SetLink(ILink link)
        {
            LinkObj.SetLink(link); 
        }
        /*NOTE: This may need tweaking to get tweaked to work properly, specifically it should end with Link shown, so timer may need adjusted.*/
        public void Update()
        {
            timer--;
            LinkObj.Update();
            if(timer == 0)
            {
                LinkObj.SetState("Default");
                RemoveDecorator();

            }else if(timer%2 == 0)
            {
                /*The case where Link's model is not shown*/
                /*THIS DOES NOT EXIST IN THE SPRITE FACTOEY YET*/
                //LinkFactory.damage();
                LinkFactory.Draw(SpriteBatch, LinkObj.GetXVal(), LinkObj.GetYVal());
            }
            else
            {
                /*The case where Link's model is shown*/
                if (LinkObj.GetState().Equals("Attacking"))
                {
                    LinkFactory.attack();
                    LinkFactory.Draw(SpriteBatch, LinkObj.GetXVal(), LinkObj.GetYVal());
                }
                else if (LinkObj.GetState().Equals("UseItem")) 
                {
                    //LinkFactory.useItem();
                    LinkFactory.Draw(SpriteBatch, LinkObj.GetXVal(), LinkObj.GetYVal());
                }
                else
                { 
                    /*Default State*/
                    //LinkFactory.walk();
                    LinkFactory.Draw(SpriteBatch, LinkObj.GetXVal(), LinkObj.GetYVal());
                }
                    
            }

        }
    }
}
