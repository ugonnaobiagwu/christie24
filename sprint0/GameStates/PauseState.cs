using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace sprint0.GameStates
{
    public class PauseState : IGameState
    {
        public int ScreenWidth { get; set; }
        public int ScreenHeight { get; set; }
        SpriteFont Font;
        private float inputPoll = 2.0f;
        private bool inputLimit = true;
        GameStateManager GameStateManager;
        public PauseState(GameStateManager manager, SpriteFont font, int screenWidth, int screenHeight)
        {
            GameStateManager = manager;
            Font = font;
            ScreenWidth = screenWidth;
            ScreenHeight = screenHeight;
        }

        public void Update(GameTime gameTime)
        {
            //May not want to update gametime - using it for inputPoll
            Globals.Update(gameTime);
            this.TransitionState();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //Draw all room and game objects + hud here
            Globals.LinkItemSystem.Draw();
            List<IGameObject> Drawables = Globals.GameObjectManager.getList("drawables");
            foreach (IGameObject obj in Drawables)
            {
                obj.Draw(spriteBatch);
            }

            //Draw pause in center of screen
            spriteBatch.DrawString(Font, "-Pause-", new Vector2(ScreenWidth / 2, ScreenHeight / 3), Color.White);
            //Notes - Vector2 has magic numbers, replace with values to draw in center of screen
        }

        public string GetState()
        {
            return "pause";
        }

        public void TransitionState()
        {
            //Limits inputs to 1 per sec
            inputPoll -= Globals.TotalSeconds;
            if (inputPoll <= 0)
            {
                inputPoll += 1.0f;
                inputLimit = false;
            }
            if (!inputLimit)
            {
                List<Keys> pressed = new List<Keys>(Keyboard.GetState().GetPressedKeys());
                foreach (Keys key in pressed)
                {
                    if (pressed.Contains(Keys.P))
                    {
                        inputLimit = true;
                        inputPoll = 1.0f;
                        GameStateManager.ChangeState("play");
                        break;
                    }
                }
            }
        }


    }
}