using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.LinkObj
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using sprint0.AnimatedSpriteFactory;
    using sprint0.LinkObj;
    using sprint0;
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
        private int XVal { get; set; }
        private int YVal { get; set; }
        private int RoomId;
        public enum State { UseItem, Default, Dead, Damaged }
        Direction LinkDirection = Direction.Down;
        public State LinkState;
        ILink LinkObj;
        ISprite LinkSprite;
        LinkTunic currentTunic;
        int damageTimer;
        /*Edited to have a texture, row, and column input for the purpose of drawing*/
        public Link(int x, int y, SpriteFactory spriteFactory)
        {
            /*3 hearts or 6 half hearts*/
            HealthVal = 6;
            LinkSpriteFactory = spriteFactory;
            XVal = x; YVal = y;
            LinkObj = this;
            IsDynamic = true;
            LinkState = State.Default;
            currentTunic = LinkTunic.GREEN;
            LinkSprite = LinkSpriteFactory.getAnimatedSprite(currentTunic.ToString() + "Down");
            damageTimer = 0;


        }


        /*The directions just change what position he is in, we have these defined already.*/
        public void LinkUp()
        {

            if (LinkDirection != Direction.Up && LinkState == State.Default || LinkState == State.Damaged)
            {

                LinkDirection = Direction.Up;
                LinkSprite = LinkSpriteFactory.getAnimatedSprite(currentTunic.ToString() + "Up");
            }
            if (LinkState == State.Default || LinkState == State.Damaged)
            {
                YVal--;
                LinkSprite.Update();
            }

        }

        public void LinkDown()
        {
            if (LinkDirection != Direction.Down && LinkState == State.Default || LinkState == State.Damaged)
            {
                LinkDirection = Direction.Down;
                LinkSprite = LinkSpriteFactory.getAnimatedSprite(currentTunic.ToString() + "Down");
            }
            if (LinkState == State.Default || LinkState == State.Damaged)
            {
                YVal++;
                LinkSprite.Update();
            }
        }

        public void LinkRight()
        {
            if (LinkDirection != Direction.Right && LinkState == State.Default || LinkState == State.Damaged)
            {
                LinkDirection = Direction.Right;
                LinkSprite = LinkSpriteFactory.getAnimatedSprite(currentTunic.ToString() + "Right");
            }
            if (LinkState == State.Default || LinkState == State.Damaged)
            {
                XVal++;
                LinkSprite.Update();
            }
        }

        public void LinkLeft()
        {
            if (LinkDirection != Direction.Left && LinkState == State.Default || LinkState == State.Damaged)
            {
                LinkDirection = Direction.Left;
                LinkSprite = LinkSpriteFactory.getAnimatedSprite(currentTunic + "Left");
            }
            if (LinkState == State.Default || LinkState == State.Damaged)
            {
                XVal--;
                LinkSprite.Update();
            }
        }
        public void LinkTakeDamage()
        {
            if (LinkState != State.Damaged)
            {
                LinkState = State.Damaged;
                HealthVal--;
                if (HealthVal == 0)
                {
                    LinkState = State.Dead;
                    LinkSprite = LinkSpriteFactory.getAnimatedSprite("Dead");
                }

            }
        }
        public void Update()
        {
            if (LinkItemSystem.CurrentTunic != currentTunic)
            {
                currentTunic = LinkItemSystem.CurrentTunic;
            }
            if (LinkState == State.Damaged)
            {

                if (damageTimer == 60)
                {
                    LinkState = State.Default;
                    damageTimer = 0;
                }
                else if (damageTimer % 2 == 0)
                {
                    /*The case where Link isn't shown*/
                    LinkSprite = LinkSpriteFactory.getAnimatedSprite("Damaged");
                }
                else
                {
                    LinkSprite = LinkSpriteFactory.getAnimatedSprite(Globals.LinkItemSystem.CurrentTunic.ToString() + LinkDirection.ToString());
                }
                damageTimer++;
            }
            if (HealthVal == 0)
            {
                LinkState = State.Dead;
                LinkSprite = LinkSpriteFactory.getAnimatedSprite("Dead");
            }
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
            return LinkState.ToString();
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
        public void GainHealth(int addedHealth)
        {
            HealthVal += addedHealth;
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
            LinkSprite.Draw(spriteBatch, XVal, YVal, 0);
        }
        public string type()
        {
            return "Link";
        }
        public void ChangeXandYValue(int x, int y)
        {
            XVal = x;
            YVal = y;
        }
    }

}