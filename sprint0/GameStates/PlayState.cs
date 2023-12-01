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
    public class PlayState : IGameState
    {

        public int ScreenWidth { get; set; }
        public int ScreenHeight { get; set; }
        private float inputPoll = 1;
        private bool inputLimit = true;
        public GraphicsDeviceManager graphics { get; set; }
        GameStateManager GameStateManager;
        HUD GameHud;
        SpriteBatch SpriteBatch,StaticHudSB;
        public PlayState(GameStateManager manager, int screenWidth, int screenHeight, HUD gameHud, SpriteBatch spriteBatch,  SpriteBatch staticHudSB)
        {
            GameStateManager = manager;
            ScreenHeight = screenHeight;
            ScreenWidth = screenWidth;
            GameHud = gameHud;
            StaticHudSB = staticHudSB;
            SpriteBatch = spriteBatch;
        }

        public void Update(GameTime gameTime)
        {
            //Globals.Camera.FollowLink(graphics, true);
            Globals.Camera.Update(gameTime);
            Globals.HudInventoryCamera.Update(gameTime);

            //KeyboardCont.Update();
            Globals.keyboardController.Update();
            Globals.LinkItemSystem.Update();

            //Updates list of updatables in GOM (blocks, enemies, items etc)
            List<IGameObject> Updateables = Globals.GameObjectManager.updateablesInRoom();
            foreach (IGameObject updateable in Updateables)
            {
                updateable.Update();
            }

            //Update global timer.
            Globals.Update(gameTime);

            //Collision iterator, 

            CollisionIterator.Iterate(Globals.GameObjectManager.getObjectsInCurrentRoom());

            this.TransitionState();
        }

        public void Draw(SpriteBatch spriteBatch, SpriteBatch HudInvSpriteBatch)
        {
            
            
            Globals.LinkItemSystem.Draw();
            List<IGameObject> Drawables = Globals.GameObjectManager.drawablesInRoom();
            foreach (IGameObject obj in Drawables)
            {
                obj.Draw(spriteBatch);
            }
            //GameHud.setSpriteBatch(spriteBatch);
            GameHud.Draw();
            if (Globals.Link != null)
            {
                Globals.Link.Draw(spriteBatch);
            }
        }

        public string GetState()
        {
            return "play";
        }

        public void TransitionState()
        {
            //Code for state transition here
            //Death State
            if (Globals.Link.GetHealth() <= 0)
            {
                GameStateManager.ChangeState("death");
            }

            //Scroll State
            if(Globals.startScrolling == true)
            {
                
                Globals.startScrolling = false;
                GameStateManager.ChangeState("scroll");
            }
            inputPoll -= Globals.TotalSeconds;
            if (inputPoll <= 0)
            {
                inputPoll += 1.0f;
                inputLimit = false;
            }
            //Checks for pause and inventory
            List<Keys> pressed = new List<Keys>(Keyboard.GetState().GetPressedKeys());
            if (!inputLimit)
            {
                foreach (Keys key in pressed)
                {
                    if (pressed.Contains(Keys.P))
                    {
                        GameStateManager.ChangeState("pause");
                        inputLimit = true;
                        inputPoll = 1.0f;
                        break;
                    }
                    else if (pressed.Contains(Keys.I))
                    {
                        GameStateManager.ChangeState("inventory");
                        inputLimit = true;
                    }
                }
            }
        }


    }
}