using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Xml;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0.GameStates;
using sprint0.LevelLoading;
using Microsoft.Xna.Framework.Content;
using sprint0.Controllers;

namespace sprint0.GameStates
{
    public class DeathState : IGameState
    {

        SpriteFont Font;
        ContentManager Content;
        GameStateManager GameStateManager;
        public DeathState(GameStateManager manager, SpriteFont font, ContentManager content, GameStateManager gameStateManager)
        {
            Font = font;
            Content = content;
            GameStateManager = gameStateManager;
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

        public void Draw(SpriteBatch spriteBatch, SpriteBatch HudInvSpriteBatch)
        {
            //Draw Screen
            List<IGameObject> Drawables = Globals.GameObjectManager.drawablesInRoom();
            foreach (IGameObject obj in Drawables)
            {
                obj.Draw(spriteBatch);
            }

            //Draw Menu - magic numbers here
            HudInvSpriteBatch.DrawString(Font, "Press R to reset game", new Vector2(150, 150), Color.White);
        }

        public string GetState()
        {
            return "death";
        }

        public void TransitionState()
        {
            //Note for future - camera does not currently reset, needs fix
            //Set all game objects to initial Values (New link, new GOM)
            Globals.GameObjectManager.ResetGOM();
            XmlDocument xmlFile = new XmlDocument();
            xmlFile.Load("Content/FirstDungeon.xml");
            XmlParser.ParseFile(xmlFile, Content);
            Globals.keyboardController.resetLinkCommands();
            GameStateManager.ChangeState("play");
        }


    }
}