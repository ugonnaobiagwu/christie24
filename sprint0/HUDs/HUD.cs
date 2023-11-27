using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
//using sprint0.AnimatedSpriteFactory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
//using System.Numerics;
using System.Text;
using System.Threading.Tasks;


namespace sprint0.HUDs
{
    public class HUD
    {   //change HUD to static as well??

        static Texture2D hudBackground;
        static Texture2D heart, miniMap, linkLocator, gem, itemA, itemB, triforce,link, xp,xpMonitor;
        SpriteBatch spriteBatch;
        SpriteFont font;     
        //Inventory inventory;
        HUD hud;
        float fontSize = 1.5f;

        //CHANGE HUD CONSTRUCTOR SO IT DOESN"T HAVE TO PASS IN TH TEXTURE@D (Probably Level loader?)
        public HUD(SpriteBatch spriteBatch, SpriteFont font)
        {
           
            this.spriteBatch = spriteBatch;
            this.font = font;
           
        }


        protected void BackgroundDisplay()
        {
            {
                hudBackground = Inventory.hudSpritSheet[Inventory.HUDSpriteSheet.BACKGROUNDSHEET];
                float scaledWidth = 0.95f;
                float scaledHeight = 0.7f;
                int x = 0;
                int y = 0;

                int width = (int)(hudBackground.Width * scaledWidth);
                int height = (int)(hudBackground.Height * scaledHeight);
                



                Rectangle destinationRectangle = new Rectangle(x, y, width, height);
                spriteBatch.Draw(hudBackground, destinationRectangle, Color.White);


            }

        }
        

        protected void HeartDisplay()
        {
            //Each heart is count of 2. If it's an odd number, that means it's an half heart
            heart = Inventory.hudSpritSheet[Inventory.HUDSpriteSheet.HEARTSHEET];
            int heartSpacing = 40;
            int j = 0;
            int i = 0;
            int heartChecker = 2;
            int heartNum = Inventory.items[Inventory.ItemTypes.HEART]; //up to max 10
            int heartWidth = heart.Width / 3;
            int heartHeight = heart.Height;
            Rectangle fullHeartsheet = new Rectangle(0, 0, heartWidth, heartHeight); // first full Heart
            Rectangle halfHeartsheet = new Rectangle(heartWidth, 0, heartWidth, heartHeight);
           

            for (i = 1; i <= heartNum; i++) //Loops the amount of hearts from enum HEART in the inventory
            {
               
                if (i == heartNum && i % heartChecker != 0) { //checks if i is at the last heart and if the last heart is odd

                    //if odd draw a half heart
                    spriteBatch.Draw(heart, new Vector2(590 + j, 90), halfHeartsheet, Color.White);
                    j += heartSpacing; 
                }
                else if (i % heartChecker == 0) //if the the last heart is even, or if not the last heart, draw a full heart
                {
                    spriteBatch.Draw(heart, new Vector2(590 + j, 90), fullHeartsheet, Color.White);
                    j += heartSpacing; //I still have to look into why there has to be two j +=heartSpacing.
                }

               

            }

        }


        //Gem
        protected void RupeeDisplay()
        {
            int rupeeCount = Inventory.items[Inventory.ItemTypes.RUPEE];
            
            //draw rupee number            
            spriteBatch.DrawString(font, rupeeCount.ToString(), new Vector2(340, 35), Color.White, 0, Vector2.Zero, fontSize, SpriteEffects.None, 0);

        }
        //Key display
        protected void KeyDisplay()
        {
            int keyCount = Inventory.items[Inventory.ItemTypes.KEY];
            spriteBatch.DrawString(font, keyCount.ToString(), new Vector2(340, 75), Color.White, 0, Vector2.Zero, fontSize, SpriteEffects.None, 0);
        }

        protected void BombDisplay()
        {
            int bombCount = Inventory.items[Inventory.ItemTypes.BOMB];

            spriteBatch.DrawString(font, bombCount.ToString(), new Vector2(340, 110), Color.White, 0, Vector2.Zero, fontSize, SpriteEffects.None, 0);
        }

        //slot A item
        public void SlotADisplay()
        {
            itemA = Inventory.LocateCurrentAItemSheet();
            //get currentA item if not null
            if (Inventory.slotA != Globals.ItemsInSlots.EMPTY && itemA != null) {
                float scaledWidth = 2f;
                float scaledHeight = 2f;
                int x = 500;
                int y = 60;

                int width = (int)(itemA.Width * scaledWidth);
                int height = (int)(itemA.Height * scaledHeight);




                Rectangle destinationRectangle = new Rectangle(x, y, width, height);
                spriteBatch.Draw(itemA, destinationRectangle, Color.White);

            }

        }
        //slot B item
        public void SlotBDisplay()
        {

            itemB = Inventory.LocateCurrentBItemSheet();
            //get current B item if not null
            if (Inventory.slotB != Globals.ItemsInSlots.EMPTY && itemB !=null) {

                float scaledWidth = 2f;
                float scaledHeight = 2f;
                int x = 415;
                int y = 65;

                int width = (int)(itemB.Width * scaledWidth);
                int height = (int)(itemB.Height * scaledHeight);




                Rectangle destinationRectangle = new Rectangle(x, y, width, height);
                spriteBatch.Draw(itemB, destinationRectangle, Color.White);
            }
        }
        //Will change the logic. I wanted to just display
        protected void MiniMapDisplay()
        {
            miniMap = Inventory.hudSpritSheet[Inventory.HUDSpriteSheet.MINIMAPSHEET];

            if (Inventory.PageResult())
            {
               
                float scaledWidth = 1f;
                float scaledHeight = 1f;
                int x = 30;
                int y = 40;

                int width = (int)(miniMap.Width * scaledWidth);
                int height = (int)(miniMap.Height * scaledHeight);




                Rectangle destinationRectangle = new Rectangle(x, y, width, height);
                spriteBatch.Draw(miniMap, destinationRectangle, Color.White);
            }

        }

        //Will change the logic. Just wanted to display
        protected void LinkLocatorDisplay()
        {
            linkLocator = Inventory.hudSpritSheet[Inventory.HUDSpriteSheet.LINKLOCATORSHEET];
            if (Inventory.CompassResult())
            {
                float scaledWidth = 0.55f;
                float scaledHeight = 0.40f;
                int x = 40;
                int y = 90;

                int width = (int)(linkLocator.Width * scaledWidth);
                int height = (int)(linkLocator.Height * scaledHeight);




                Rectangle destinationRectangle = new Rectangle(x, y, width, height);
                spriteBatch.Draw(linkLocator, destinationRectangle, Color.White);
            }

        }

        //still need sprite for this
        protected void TriforceDisplay()
        {

            if (Inventory.TriforceResult())
            {
                float scaledWidth = 0.55f;
                float scaledHeight = 0.40f;
                int x = 40;
                int y = 90;

                int width = (int)(triforce.Width * scaledWidth);
                int height = (int)(triforce.Height * scaledHeight);




                Rectangle destinationRectangle = new Rectangle(x, y, width, height);
                spriteBatch.Draw(triforce, destinationRectangle, Color.White);
            }

        }



        protected void LevelDisplay()
        {
            //get the level room number
            //change "1" so it links to the roomID that gets passed into the parameter of Inventory
            spriteBatch.DrawString(font, "1", new Vector2(210, 15), Color.White, 0, Vector2.Zero, 2, SpriteEffects.None, 0);
        }

        //xp calculation
        // if Link attacks, gain xp (200)
        public void XPDisplay() {

            //int xpSpacing = 30;
            link = Inventory.hudSpritSheet[Inventory.HUDSpriteSheet.LINKLEVELSHEET];
            xp = Inventory.hudSpritSheet[Inventory.HUDSpriteSheet.XPSHEET];
            xpMonitor = Inventory.hudSpritSheet[Inventory.HUDSpriteSheet.XPMONITORSHEET];
            int j = 0;
            int i = 0;
            float xpNum = Inventory.currentXP[Inventory.XPEnum.XP];
            int linkWidth = link.Width;
            int linkHeight = link.Height / 3;
            int currentRow = 0;
            Vector2 vectorPositionLinkLevel = new Vector2(380, 125);
            Vector2 vectorPositionxp = new Vector2(410, 125);
            Rectangle linkLevel = new Rectangle(0, currentRow, linkWidth, linkHeight); //default is low link
            //Rectangle xpMonitor = new Rectangle(0, 0, linkWidth, linkHeight);

            //if  (Inventory.currentLinkLevel == Inventory.LinkLevel.LOW) { Rectangle lowLink = new Rectangle(0, 0, linkWidth, linkHeight); }
            if (Inventory.currentLinkLevel == Inventory.LinkLevel.MEDIUM) { currentRow = linkHeight; }
           else if (Inventory.currentLinkLevel == Inventory.LinkLevel.HIGH) { currentRow = linkHeight * 2; }

            linkLevel = new Rectangle(0, currentRow, linkWidth, linkHeight);


            // reference:   spriteBatch.Draw(heart, new Vector2(590 + j, 90), halfHeartsheet, Color.White);
            spriteBatch.Draw(xp,vectorPositionxp,Color.White);
            spriteBatch.Draw(xpMonitor, vectorPositionxp, Color.White);
            spriteBatch.Draw(link, vectorPositionLinkLevel, linkLevel, Color.White);

            for (i = 0; i <= (int)xpNum; i++) //Loops the amount of xp from enum XP in the inventory
            {

                



            }
        
        }

        public void XPMonitorDisplay()
        { }

            //Display all (called in Game1)
            public void Draw()
        {

            BackgroundDisplay();
            XPDisplay();
            MiniMapDisplay();
            LinkLocatorDisplay();
            HeartDisplay();
            RupeeDisplay();
            KeyDisplay();
            BombDisplay();
            SlotADisplay(); 
            SlotBDisplay(); 
            LevelDisplay();
           


        }




    }

}
