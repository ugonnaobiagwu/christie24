using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.HUDs;
using sprint0.GameStates;
using sprint0.Commands.GameStateCommand;
using Microsoft.Xna.Framework.Input;
using static sprint0.HUDs.Inventory;
using sprint0.AnimatedSpriteFactory;

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
        SpriteFactory InventoryFactory;
        HUD GameHud;
        private bool ScrollOnce = false;
        private float inputPoll = 2.0f;
        private bool inputLimit = true;
        private const float ScaleHeight = 2.0f;
        private const float ScaleWidth = 3.5f;
        private const int InventoryBoxLeftBound = 440;
        private const int InventoryBoxRightBound = 710;
        private const int InventoryBoxUpperBound = -300;
        private const int InventoryBoxLowerBound = -260;
        GameStateManager GameStateManager;

        public InventoryState(GameStateManager manager, Texture2D inventoryTexture, InventoryCursor cursor, HUD gameHud, SpriteFactory inventoryFactory)

     //   public InventoryState(GameStateManager manager, Texture2D inventoryTexture, InventoryCursor cursor, HUD gameHud,  IDictionary<ItemTypes, Texture2D> itemTextureDict)
        {
            GameStateManager = manager;
            InventoryTexture = inventoryTexture;
            GameHud = gameHud;
            Cursor = cursor;
            GameHud.HudYOffset = -50;
            InventoryFactory = inventoryFactory;

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
            List<IGameObject> Updateables = Globals.GameObjectManager.getList("updateables");
            foreach (IGameObject updateable in Updateables)
            {
                updateable.Update();
            }

            //Draw the background

            int x = 0;
            //This is room height in camera class currently (160)- smelly magic number now that its in this class too
            //int y = -(int)((float)InventoryTexture.Height * ScaleHeight) - GameHud.ReturnHUDHeight();
            int y = -GameHud.ReturnHUDHeight() - InventoryTexture.Height + 20;
            

            int width = (int)(InventoryTexture.Width * ScaleWidth);
            int height = (int)(InventoryTexture.Height * ScaleHeight);
            Rectangle destinationRectangle = new Rectangle(x, y, width, height);
            spriteBatch.Draw(InventoryTexture, destinationRectangle, Color.White);

            //Draw the Hud
            GameHud.Draw();
            InventoryFactory.getAnimatedSprite("Boomerang").Draw(spriteBatch, 500, -300,0.0f);
            InventoryFactory.getAnimatedSprite("Bomb").Draw(spriteBatch, 500, -300,0.0f);
            InventoryFactory.getAnimatedSprite("Bow").Draw(spriteBatch, 600, -200, 0.0f);
            InventoryFactory.getAnimatedSprite("Blaze").Draw(spriteBatch, 700, -300, 0.0f);
            //Draw items
            //foreach (KeyValuePair<ItemTypes, Texture2D> itemEntry in itemTextureDict)
            //{
            //switch (itemEntry.Key)
            //    {
            //        case ItemTypes.BOOMERANG:
            //            InventoryFactory.getAnimatedSprite("Boomerang").Draw(spriteBatch, 400, -300);
            //            break;
            //        case ItemTypes.BOMB:
            //            InventoryFactory.getAnimatedSprite("Bomb").Draw(spriteBatch, 0, 0);
            //            break;
            //        case ItemTypes.BOW:
            //            InventoryFactory.getAnimatedSprite("Bow").Draw(spriteBatch,0,0);
            //            break;
            //        case ItemTypes.BLAZE:
            //            InventoryFactory.getAnimatedSprite("Blaze").Draw(spriteBatch, 0, 0);
            //            break;
            //    }
            //}

            //Draw Cursor
            Rectangle sourceRectangle = new Rectangle();
            sourceRectangle.Height = Cursor.CursorTexture.Height;
            sourceRectangle.Width = Cursor.CursorTexture.Width;
            spriteBatch.Draw(Cursor.CursorTexture, Cursor.CursorPosition, sourceRectangle, Color.White, 0.0f, new Vector2(0, 0), new Vector2(1.15f, 0.7f), SpriteEffects.None, 0.0f);

            if (!ScrollOnce)
            {
                //Console.WriteLine(Globals.Camera.getCameraYPos());
                ScrollOnce = true;
                Globals.Camera.MoveCameraUp((int)((float)InventoryTexture.Height * ScaleHeight));
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
                        Globals.Camera.MoveCameraDown((int)((float)InventoryTexture.Height * ScaleHeight));
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