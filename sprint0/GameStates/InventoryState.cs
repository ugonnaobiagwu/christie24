using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.HUDs;
using sprint0.GameStates;
using sprint0.Commands.GameStateCommand;
using Microsoft.Xna.Framework.Input;

namespace sprint0.GameStates
{
    //To do
    //Draw items in links inventory,
    //Make cursor select items and assign them to buttons
    public class InventoryState : IGameState
    {
        private ICommand ScrollUp;
        Texture2D InventoryTexture;
        public InventoryCursor Cursor { get; set; }
        IDictionary<String, Texture2D> ItemTextureDict;
        HUD GameHud;
        private bool ScrollOnce = false;
        private float inputPoll = 2.0f;
        private bool inputLimit = true;
        GameStateManager GameStateManager;
        public InventoryState(GameStateManager manager, Texture2D inventoryTexture, InventoryCursor cursor, HUD gameHud)
        {
            GameStateManager = manager;
            InventoryTexture = inventoryTexture;
            GameHud = gameHud;
            Cursor = cursor;
            GameHud.HudYOffset = 100;

        }
        public void Update(GameTime gameTime)
        {
            //Cursor and inventory system will be updated

            Globals.inventoryController.Update();
            Globals.Camera.Update(gameTime);
            //Look into updating LinkItemSystem as well

            //Check for state transition
            this.TransitionState();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //Draw paused game to scroll out of
            Globals.LinkItemSystem.Draw();
            List<IGameObject> Drawables = Globals.GameObjectManager.getList("drawables");
            foreach (IGameObject obj in Drawables)
            {
                obj.Draw(spriteBatch);
            }

            //Draw the background
            float scaledWidth = 1.15f;
            float scaledHeight = 0.75f;
            int x = 0;
            //This is room height in camera class currently (160)- smelly magic number now that its in this class too
            int y = -160 - 40;

            int width = (int)(InventoryTexture.Width * scaledWidth);
            int height = (int)(InventoryTexture.Height * scaledHeight);
            Rectangle destinationRectangle = new Rectangle(x, y, width, height);
            spriteBatch.Draw(InventoryTexture, destinationRectangle, Color.White);

            //Draw the Hud
            GameHud.Draw();

            //Draw Cursor
            Rectangle larry = new Rectangle();
            larry.Height = Cursor.CursorTexture.Height;
            larry.Width = Cursor.CursorTexture.Width;
            spriteBatch.Draw(Cursor.CursorTexture, Cursor.CursorPosition, larry, Color.White, 0.0f, new Vector2(0, 0), new Vector2(1.15f, 0.7f), SpriteEffects.None, 0.0f);

            if (!ScrollOnce)
            {
                //Console.WriteLine(Globals.Camera.getCameraYPos());
                ScrollOnce = true;
                Globals.Camera.MoveCameraToTopRoom();
                //Globals.Camera.MoveCameraUp(100);
                //Console.WriteLine(Globals.Camera.getCameraYPos());
            }

        }

        public string GetState()
        {
            return "inventory";
        }

        public void TransitionState()
        {
            inputPoll -= Globals.TotalSeconds;
            if (inputPoll <= 0)
            {
                inputPoll += 2.0f;
                inputLimit = false;
            }

            //Checks for pause and inventory
            List<Keys> pressed = new List<Keys>(Keyboard.GetState().GetPressedKeys());
            if (!inputLimit)
            {
                foreach (Keys key in pressed)
                {
                    if (pressed.Contains(Keys.I))
                    {
                        Globals.Camera.MoveCameraToBottomRoom();
                        inputPoll = 2.0f;
                        inputLimit = true;
                        ScrollOnce = false;
                        GameStateManager.ChangeState("play");
                    }
                }
            }
        }


    }
}