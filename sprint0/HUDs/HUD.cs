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
        static Texture2D heart, miniMap, linkLocator, gem, itemA, itemB;
        SpriteBatch spriteBatch;
        SpriteFont font;
        //Inventory inventory;
        HUD hud;
        float fontSize = 1.5f;

        //Vars to change hud position - need for inventory screen
        public int HudXOffset {get;set;}
        public int HudYOffset { get; set; }

        //CHANGE HUD CONSTRUCTOR SO IT DOESN"T HAVE TO PASS IN TH TEXTURE@D (Probably Level loader?)
        public HUD(SpriteBatch spriteBatch, SpriteFont font, Texture2D hudspriteSheet, Texture2D Hearttexture, Texture2D minimap, Texture2D linklocator)
        {
            this.spriteBatch = spriteBatch;
            this.font = font;
            hudBackground = hudspriteSheet;
            miniMap = minimap;
            linkLocator = linklocator;
            heart = Hearttexture;

            HudXOffset = 0;
            HudYOffset = 0;
        }


        protected void BackgroundDisplay()
        {
            {
                float scaledWidth = 0.95f;
                float scaledHeight = 0.7f;
                int x = 0 + HudXOffset;
                int y = 0 + HudYOffset;

                int width = (int)(hudBackground.Width * scaledWidth);
                int height = (int)(hudBackground.Height * scaledHeight);
                



                Rectangle destinationRectangle = new Rectangle(x, y, width, height);
                spriteBatch.Draw(hudBackground, destinationRectangle, Color.White);


            }

        }
        

        protected void HeartDisplay()
        {
            //Each heart is count of 2. If it's an odd number, that means it's an half heart

            int fullHeart = 10; //5 hearts
            int heartSpacing = 40;
            int j = 0;
            int i;
            int heartChecker = 2;
            int heartNum = Inventory.items[Inventory.ItemTypes.HEART]; //up to max 10
            int heartWidth = heart.Width / 3;
            int heartHeight = heart.Height;
            Rectangle fullHeartsheet = new Rectangle(0, 0, heartWidth, heartHeight); // first full Heart
            Rectangle halfHeartsheet = new Rectangle(heartWidth, 0, heartWidth, heartHeight);
            Rectangle emptyHeartsheet = new Rectangle(2, 0, heartWidth, heartHeight);
           

            for (i = 1; i <= heartNum; i++) //Loops the amount of hearts from enum HEART in the inventory
            {
               
                if (i == heartNum && i % heartChecker != 0) { //checks if i is at the last heart and if the last heart is odd

                    //if odd draw a half heart
                    spriteBatch.Draw(heart, new Vector2(590 + j + HudXOffset, 90 + HudYOffset), halfHeartsheet, Color.White);
                    j += heartSpacing; 
                }
                else if (i % heartChecker == 0) //if the the last heart is even, or if not the last heart, draw a full heart
                {
                    spriteBatch.Draw(heart, new Vector2(590 + j + HudXOffset, 90 +HudYOffset), fullHeartsheet, Color.White);
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
        public void SlotADisplay(string currentItemA)
        {
            //get currentA item if not null

        }
        //slot B item
        public void SlotBDisplay(string currentItemB)
        {
            //get current B item if not null
        }

        //Will change the logic. I wanted to just display
        protected void MiniMapDisplay()
        {


            float scaledWidth = 1f;
            float scaledHeight = 1f;
            int x = 30 + HudXOffset;
            int y = 40 + HudYOffset;

            int width = (int)(miniMap.Width * scaledWidth);
            int height = (int)(miniMap.Height * scaledHeight);




            Rectangle destinationRectangle = new Rectangle(x, y, width, height);
            spriteBatch.Draw(miniMap, destinationRectangle, Color.White);


        }
        
           //Will change the logic. Just wanted to display
        protected void linkLocatorDisplay()
        {
            float scaledWidth = 0.55f;
            float scaledHeight = 0.40f;
            int x = 40 + HudXOffset;
            int y = 90 + HudYOffset;

            int width = (int)(linkLocator.Width * scaledWidth);
            int height = (int)(linkLocator.Height * scaledHeight);




            Rectangle destinationRectangle = new Rectangle(x, y, width, height);
            spriteBatch.Draw(linkLocator, destinationRectangle, Color.White);


        }


        protected void LevelDisplay()
        {
            //get the level room number
            //change "1" so it links to the roomID that gets passed into the parameter of Inventory
            spriteBatch.DrawString(font, "1", new Vector2(210, 15), Color.White, 0, Vector2.Zero, 2, SpriteEffects.None, 0);
        }

        //xp calculation
        // if Link attacks, gain xp (200)

        //Display all (called in Game1)
        public void Draw()
        {
            this.BackgroundDisplay();
            MiniMapDisplay();
            linkLocatorDisplay();
            HeartDisplay();
            this.RupeeDisplay();
            this.KeyDisplay();
            this.BombDisplay();
            this.SlotADisplay(""); //change
            this.SlotBDisplay(""); //change
            this.LevelDisplay();


        }

        /*public void XP(){}*/

        public int ReturnHUDHeight() { return hudBackground.Height; }
    }

}
