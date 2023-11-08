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
    internal class HUD
    {

        //object will call
        //just do the calculation
        //_spriteBatch.DrawString(font, "X %d", new Vector2(100, 10), Color.White);

        Texture2D hudBackground;
        Texture2D heart, gem, itemA, itemB;
        SpriteBatch spriteBatch;
        SpriteFont font;     
        Inventory inventory;
        HUD hud;
        float fontSize = 1.5f;


        public HUD(SpriteBatch spriteBatch, SpriteFont font, Texture2D hudspriteSheet, Texture2D Hearttexture, Inventory inventory)
        {
            this.spriteBatch = spriteBatch;
            this.inventory = inventory;
            this.font = font;
            hudBackground = hudspriteSheet;
            this.heart = Hearttexture;
        }


        protected void backgroundDisplay()
        {
            {
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
        

        protected void heartDisplay()
        {
            int fullHeart = 10; //5 hearts
            int j = 0;
            int i;
            int heartNum = inventory.items[Inventory.ItemTypes.HEART]; //up to max 10
            int heartWidth = heart.Width / 3;
            int heartHeight = heart.Height;
            Rectangle fullHeartsheet = new Rectangle(0, 0, heartWidth, heartHeight); // first full Heart
            Rectangle halfHeartsheet = new Rectangle(heartWidth, 0, heartWidth, heartHeight);
            Rectangle emptyHeartsheet = new Rectangle(2, 0, heartWidth, heartHeight);
           

            for (i = 1; i <= heartNum; i++)
            {
               
                if (i == heartNum && i % 2 != 0) {

                    //if odd
                    spriteBatch.Draw(heart, new Vector2(590 + j, 90), halfHeartsheet, Color.White);
                    j += 40;
                }
                else if (i % 2 == 0)
                {
                    spriteBatch.Draw(heart, new Vector2(590 + j, 90), fullHeartsheet, Color.White);
                    j += 40;
                }

               

            }

        }


        //heart modulus 
        //if heart is damaged, 
        //public void heartLine() { }

        //Gem
        protected void gemDisplay()
        {
            int gemCount = inventory.items[Inventory.ItemTypes.GEM];
            //draw gem number
            //spriteBatch.DrawString(font, gemCount.ToString(), new Vector2(350, 100), Color.White);
            spriteBatch.DrawString(font, gemCount.ToString(), new Vector2(340, 35), Color.White, 0, Vector2.Zero, fontSize, SpriteEffects.None, 0);

        }
        //Key display
        protected void keyDisplay()
        {
            int keyCount = inventory.items[Inventory.ItemTypes.KEY];
            spriteBatch.DrawString(font, keyCount.ToString(), new Vector2(340, 75), Color.White, 0, Vector2.Zero, fontSize, SpriteEffects.None, 0);
        }

        protected void bombDisplay()
        {
            int bombCount = inventory.items[Inventory.ItemTypes.BOMB];

            spriteBatch.DrawString(font, bombCount.ToString(), new Vector2(340, 110), Color.White, 0, Vector2.Zero, fontSize, SpriteEffects.None, 0);
        }

        //slot A item
        public void slotADisplay(string currentItemA)
        {
            //get currentA item if not null

        }
        //slot B item
        public void slotBDisplay(string currentItemB)
        {
            //get current B item if not null
        }

        protected void levelDisplay()
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
            this.backgroundDisplay();
            this.heartDisplay();
            this.gemDisplay();
            this.keyDisplay();
            this.bombDisplay();
            this.slotADisplay(""); //change
            this.slotBDisplay(""); //change
            this.levelDisplay();


        }

        /*public void XP(){}*/


    }

}
