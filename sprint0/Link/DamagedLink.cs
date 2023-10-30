using Microsoft.Xna.Framework.Graphics;
using sprint0.AnimatedSpriteFactory;
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
        IGameObject LinkGameObj;
        /*This is arbitrary*/
        int timer = 20;
        public DamagedLink(SpriteFactory linkFactory, ILink link)
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
        public int GetDirection()
        {
            return LinkObj.GetDirection();
        }
        public int xPosition()
        {
            return LinkObj.xPosition();
        }
        public int yPosition()
        {
            return LinkObj.yPosition();
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
        /*NOTE: TURN ALL SWITCH CASES INTO DELEGATES*/
        public void Update()
        {
            timer--;
            if(timer == 0)
            {
                LinkObj.SetState("Default");
                RemoveDecorator();

            }else if(timer%2 == 0)
            {
                /*The case where Link isn't shown*/
                LinkObj.SetSprite(LinkFactory.getAnimatedSprite("Damaged"));
               
            }
            else
            {
                /*The case where Link's model is shown*/
               if (LinkObj.GetState().Equals("UseItem")) 
                {
                    switch (LinkObj.GetDirection())
                    {
                        case 2:
                            LinkObj.SetSprite( LinkFactory.getAnimatedSprite("ItemUp"));
                            break;
                        case 3:
                            LinkObj.SetSprite(LinkFactory.getAnimatedSprite("ItemDown"));
                            break;
                        case 0:
                            LinkObj.SetSprite(LinkFactory.getAnimatedSprite("ItemLeft"));
                            break;
                        case 1:
                            LinkObj.SetSprite(LinkFactory.getAnimatedSprite("ItemRight"));
                            break;
                    }

                }
                else
                {

                    switch (LinkObj.GetDirection())
                    {
                        case 2:
                            LinkObj.SetSprite(LinkFactory.getAnimatedSprite("Up"));
                            break;
                        case 3:
                            LinkObj.SetSprite(LinkFactory.getAnimatedSprite("Down"));
                            break;
                        case 0:
                            LinkObj.SetSprite(LinkFactory.getAnimatedSprite("Left"));
                            break;
                        case 1:
                            LinkObj.SetSprite(LinkFactory.getAnimatedSprite("Right"));
                            break;
                    }

                }
                    
            }
            LinkObj.Update();
        }
        public void SetSprite(ISprite newSprite) 
        { 
            LinkObj.SetSprite(newSprite);
        }
        public int height()
        {
            return LinkObj.height();
        }
        public int width()
        {
            return LinkObj.width();
        }
        public bool isDynamic()
        {
            return LinkObj.isDynamic();
        }
        public bool isUpdateable()
        {
            return LinkObj.isUpdateable();
        }
        public bool isDrawable()
        {
            return LinkObj.isDrawable();
        }
        public bool isInPlay()
        {
            return LinkObj.isInPlay();
        }
        public void SetRoomId(int roomId)
        {
            LinkObj.SetRoomId(roomId);
        }
        public int GetRoomId()
        {
            return LinkObj.GetRoomId();
        }
        /*TO BE DELETE: FOR TESTING*/
        public void Draw(SpriteBatch spriteBatch)
        {
            LinkObj.Draw(spriteBatch);
        }
    }
}
