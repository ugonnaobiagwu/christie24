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
        Texture2D heart, ruby, itemA, itemB;
        SpriteBatch spriteBatch;
        SpriteFont font;
        float fontSize = 1.5f;
        Inventory inventory;
        HUD hud;


        public HUD(SpriteBatch spriteBatch, SpriteFont font, Texture2D hudspriteSheet, Texture2D Hearttexture, Inventory inventory)
        {
            this.spriteBatch = spriteBatch;
            this.inventory = inventory;
            this.font = font;
            hudBackground = hudspriteSheet;
            this.heart = Hearttexture;
        }


        public void backgroundDisplay()
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
        /* public void heartDisplay()
         {

             int j = 0;
             int i;
             int heartNum = 5; ; // Number of hearts for now (this will be passed in the parameter later??)
             int heartWidth = heart.Width / 3;
             int heartHeight = heart.Height;
             Rectangle sourceRectangle = new Rectangle(0, 0, heartWidth, heartHeight); // first full Heart


             for (i = 0; i < heartNum; i++)
             {

                 spriteBatch.Draw(heart, new Vector2(570 + j, 90), sourceRectangle, Color.White);

                 j += 40;
             }

         }*/

        public void heartDisplay()
        {

            int j = 0;
            int i;
            int heartNum = inventory.items[Inventory.ItemTypes.HEART]; ; // Number of hearts for now (this will be passed in the parameter later??)
            int heartWidth = heart.Width / 3;
            int heartHeight = heart.Height;
            Rectangle sourceRectangle = new Rectangle(0, 0, heartWidth, heartHeight); // first full Heart


            for (i = 0; i < heartNum; i++)
            {

                spriteBatch.Draw(heart, new Vector2(590 + j, 90), sourceRectangle, Color.White);

                j += 40;
            }

        }


        //heart modulus 
        //if heart is damaged, 
        //public void heartLine() { }

        //Gem
        public void gemDisplay()
        {
            int gemCount = inventory.items[Inventory.ItemTypes.GEM];
            //draw gem number
            //spriteBatch.DrawString(font, gemCount.ToString(), new Vector2(350, 100), Color.White);
            spriteBatch.DrawString(font, gemCount.ToString(), new Vector2(340, 35), Color.White, 0, Vector2.Zero, fontSize, SpriteEffects.None, 0);

        }
        //Key display
        public void keyDisplay()
        {
            int keyCount = inventory.items[Inventory.ItemTypes.KEY];
            spriteBatch.DrawString(font, keyCount.ToString(), new Vector2(340, 75), Color.White, 0, Vector2.Zero, fontSize, SpriteEffects.None, 0);
        }

        public void bombDisplay()
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

        public void levelDisplay()
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
            this.slotADisplay("");
            this.slotBDisplay("");
            this.levelDisplay();


        }

        /*public void XP(){}*/


    }

}
