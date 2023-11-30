using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0.Commands;
using sprint0.Items.groundItems;
using System.Runtime.CompilerServices;
using sprint0.Controllers;
using sprint0.Blocks;
using sprint0.LinkObj;
using System.Collections.Generic;
using sprint0.AnimatedSpriteFactory;
using sprint0.Enemies;
using sprint0.Sound.Ocarina;
using Microsoft.Xna.Framework.Audio;
using sprint0.HUDs;
using sprint0.Collision;
using sprint0.LevelLoading;
using System.Xml;
using System;

namespace sprint0.GameStates
{
	public class TitleScreenState :IGameState
	{
        GameStateManager GameStateManager;
        Texture2D BackGround;
        SpriteFont Font;
        private float titleSelection = 1.5f;
		public TitleScreenState(GameStateManager gameStateManager, Texture2D background, SpriteFont font)
		{
            GameStateManager = gameStateManager;
            BackGround = background;
            Font = font;
		}

        public void Draw(SpriteBatch spriteBatch, SpriteBatch HudInventorySpriteBatch)
        {
            //Draw background
            Rectangle destionationRectangle = new Rectangle(0,-50,800,500);
            spriteBatch.Draw(BackGround,destionationRectangle, Color.White);

            //Draw prompt
            if (titleSelection > 0.5f)
            {
                spriteBatch.DrawString(Font, "Push Space Button", new Vector2(330, 280), Color.White);
            }
        }

        public void Update(GameTime gameTime)
        {
            Globals.Update(gameTime);
            titleSelection -= Globals.TotalSeconds;
            if (titleSelection <=0)
            {
                titleSelection += 1.5f;
            }
            this.TransitionState();
        }

        public string GetState()
        {
            return "title";
        }

        public void TransitionState()
        {
            List<Keys> pressed = new List<Keys>(Keyboard.GetState().GetPressedKeys());
                foreach (Keys key in pressed)
                {
                    if (pressed.Contains(Keys.Space))
                    {
                        GameStateManager.ChangeState("play");
                        break;
                    }

                }
            
        }


    }
}

