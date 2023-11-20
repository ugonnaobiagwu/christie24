using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0.GameStates;

namespace sprint0.GameStates
{
	public class DeathState: IGameState
	{

        SpriteFont Font;
        public DeathState(GameStateManager manager,SpriteFont font)
		{
            Font = font;
        }

        public void Update(GameTime gameTime)
        {

            //Code to check if R is pressed to reset - too lazy to make a command
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

        public void Draw(SpriteBatch spriteBatch)
        {
            //Draw Screen
            List<IGameObject> Drawables = Globals.GameObjectManager.getList("drawables");
            foreach (IGameObject obj in Drawables)
            {
                obj.Draw(spriteBatch);
            }

            //Draw Menu - magic numbers here
            spriteBatch.DrawString(Font, "Press R to reset game", new Vector2(150,150), Color.White);
        }

        public string GetState()
        {
            return "death";
        }

        public void TransitionState()
        {
            //Set all game objects to initial Values (New link, new GOM)
            Globals.GameObjectManager = InitialStateHolder.InitialGameObjectManager;
            Globals.Camera = InitialStateHolder.InitialCamera;
            Globals.Link = InitialStateHolder.InitialLink;
        }


    }
}

