using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Xml;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0.HUDs;
using sprint0.LevelLoading;

namespace sprint0.GameStates
{
	public class WinState : IGameState
	{
        SpriteFont Font;
        ContentManager Content;
        GameStateManager GameStateManager;
        private float LinkOnScreenTimer = 4.0f;
        Texture2D WinScreenTexture;
        public WinState(SpriteFont font, ContentManager content, GameStateManager gameStateManager, Texture2D winScreen)
		{
            Font = font;
            Content = content;
            GameStateManager = gameStateManager;
            WinScreenTexture = winScreen;
        }

        public void Draw(SpriteBatch spriteBatch, SpriteBatch HudInventorySpriteBatch)
        {
            if (LinkOnScreenTimer >= 0)
            {
                //Draw Screen
                List<IGameObject> Drawables = Globals.GameObjectManager.drawablesInRoom();
                foreach (IGameObject obj in Drawables)
                {
                    obj.Draw(spriteBatch);
                }
                Globals.Link.Draw(spriteBatch);
            }
            else
            {
                Rectangle destionationRectangle = new Rectangle(0, -50, 800, 500);
                spriteBatch.Draw(WinScreenTexture, destionationRectangle, Color.White);
                //Draw Menu - magic numbers here
                HudInventorySpriteBatch.DrawString(Font, "You Win!", new Vector2(580, 280), Color.White);
                HudInventorySpriteBatch.DrawString(Font, "Press R to reset game", new Vector2(550,330), Color.White);
            }
        }

        public void Update(GameTime gameTime)
        {
            Globals.Update(gameTime);
            LinkOnScreenTimer -= Globals.TotalSeconds;

            if (LinkOnScreenTimer <= 0)
            {
                List<Keys> pressed = new List<Keys>(Keyboard.GetState().GetPressedKeys());
                // press transitions
                foreach (Keys key in pressed)
                {
                    // adds to the list the current action/command
                    if (pressed.Contains(Keys.R))
                    {
                        this.TransitionState();

                        break;
                    }
                }
            }

        }

        public string GetState()
        {
            return "win";
        }

        public void TransitionState()
        {
            //Set all game objects to initial Values (New link, new GOM)
            Inventory.hasTriforce = false;
            Globals.GameObjectManager.ResetGOM();
            XmlDocument xmlFile = new XmlDocument();
            xmlFile.Load("Content/FirstDungeon.xml");
            XmlParser.ParseFile(xmlFile, Content);
            Globals.keyboardController.resetLinkCommands();
            GameStateManager.ChangeState("play");
            Globals.Camera.ResetCameraPos();
        }


    }
}

