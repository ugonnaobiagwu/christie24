using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.LinkObj
{
    using sprint0.AnimatedSpriteFactory;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Numerics;
    using System.Security.Cryptography.X509Certificates;
    using static sprint0.Globals;


    /* Need to make interface*/
    public class Link : ILink
    {
        private bool IsUpdateable = true;
        private bool IsDrawable = true;
        private bool IsInPlay = true;
        private bool IsDynamic = true;
        SpriteFactory LinkSpriteFactory;
        private int HealthVal { get; set; }
        public int XVal { get; set; }
        public int YVal { get; set; }
        private int RoomId;
        public enum State { UseItem, Default, Dead }
        Direction LinkDirection = Direction.Down;
        public State LinkState = State.Default;
        ILink LinkObj;
        ISprite LinkSprite;
        /*Edited to have a texture, row, and column input for the purpose of drawing*/
        public Link(int x, int y,SpriteFactory spriteFactory)
        {
            /*This number is arbitrary*/
            HealthVal = 10;
            LinkSpriteFactory = spriteFactory;
            XVal = x; YVal = y;
            LinkObj = this;
            IsDynamic = true;
            LinkSprite = LinkSpriteFactory.getAnimatedSprite("GreenDown");
        }

        /*This can be used for both attacking and use item because they have the same Link sprite but different items, which are handled by the item system*/
        public void LinkUseItem()
        {/* NOTE: THIS DOES NOT WORK, I believe the moment Link would change to his last frame, 
          * GetAnimationComplete ends before drawing
            LinkObj.SetState(State.UseItem);
            switch (LinkDirection)
            {
                case Direction.Left:
                    LinkSprite = LinkSpriteFactory.getAnimatedSprite("GreenItemLeft");
                    break;
                case Direction.Right:
                    LinkSprite = LinkSpriteFactory.getAnimatedSprite("GreenItemRight");
                    break;
                case Direction.Up:
                    LinkSprite = LinkSpriteFactory.getAnimatedSprite("GreenItemUp");
                    break;
                default:
                    LinkSprite = LinkSpriteFactory.getAnimatedSprite("GreenItemDown");
                    break;
            }
            while (!LinkSprite.GetAnimationComplete())
            {
                LinkSprite.Update();
            }
            LinkObj.SetState(State.Default);
            switch (LinkDirection)
            {
                case Direction.Left:
                    LinkSprite = LinkSpriteFactory.getAnimatedSprite("GreenLeft");
                    break;
                case Direction.Right:
                    LinkSprite = LinkSpriteFactory.getAnimatedSprite("GreenRight");
                    break;
                case Direction.Up:
                    LinkSprite = LinkSpriteFactory.getAnimatedSprite("GreenUp");
                    break;
                default:
                    LinkSprite = LinkSpriteFactory.getAnimatedSprite("GreenDown");
                    break;
            }

            */
        }


        /*The directions just change what position he is in, we have these defined already.*/
        public void LinkUp()
        {

            if (LinkDirection != Direction.Up)
            {
                LinkDirection = Direction.Up;
                LinkSprite = LinkSpriteFactory.getAnimatedSprite("GreenUp");
            }
            if(LinkState == State.Default)
            {
                YVal--;
                LinkSprite.Update();
            }

        }

        public void LinkDown()
        {
            if (LinkDirection != Direction.Down && LinkState == State.Default)
            {
                LinkDirection = Direction.Down;
                LinkSprite = LinkSpriteFactory.getAnimatedSprite("GreenDown");
            }
            if (LinkState == State.Default)
            {
                YVal++;
                LinkSprite.Update();
            }
        }

        public void LinkRight()
        {
            if (LinkDirection != Direction.Right && LinkState == State.Default)
            {
                LinkDirection = Direction.Right;
                LinkSprite = LinkSpriteFactory.getAnimatedSprite("GreenRight");
            }
            if (LinkState == State.Default)
            {
                XVal++;
                LinkSprite.Update();
            }
        }

        public void LinkLeft()
        {
            if (LinkDirection != Direction.Left && LinkState == State.Default)
            {
                LinkDirection = Direction.Left;
                LinkSprite = LinkSpriteFactory.getAnimatedSprite("GreenLeft");
            }
            if (LinkState == State.Default)
            {
                XVal--;
                LinkSprite.Update();
            }
        }

        public void LinkTakeDamage()
        {
            HealthVal--;
            //Add an if else to turn link dead if the health is 0 
            LinkObj = new DamagedLink(LinkSpriteFactory, this);
        }

        public void Update()
        {
            
        }

        public int xPosition()
        {
            return XVal;
        }
        public int yPosition()
        {
            return YVal;
        }
        public int GetHealth()
        {
            return HealthVal;
        }
        /*These next three methods could be compact probably*/
        public Direction GetDirection()
        {
            return LinkDirection;
        }
        public String GetState()
        {
            String state = "";
            switch (LinkState)
            {
                case State.UseItem:
                    state = "UseItem";
                    break;
                case State.Default:
                    state = "Default";
                    break;
            }
            return state;
        }
        public void SetState(Link.State newState)
        {
            LinkState = newState;
        }
        public void SetRoomId(int id)
        {
            RoomId = id;
        }
        public int GetRoomId()
        {
            return RoomId;
        }
        /*Needed to reset link after decorator finishes*/
        public void SetLink(ILink link)
        {
            LinkObj = link;
        }

        public void SetSprite(ISprite newLink)
        {
            LinkSprite = newLink;
        }
        public int width()
        {
            return LinkSprite.GetWidth();
        }
        public int height()
        {
            return LinkSprite.GetHeight();
        }
        public bool isDynamic()
        {
            return IsDynamic;
        }
        public bool isUpdateable()
        {
            return IsUpdateable;
        }
        public bool isInPlay()
        {
            return IsInPlay;
        }
        public bool isDrawable()
        {
            return IsDrawable;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            LinkSprite.Draw(spriteBatch, XVal, YVal,0);
        }
    }

}
