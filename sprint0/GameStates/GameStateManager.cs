using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.GameStates;
using sprint0.HUDs;
namespace sprint0.GameStates
{
    public class GameStateManager
    {
        private IGameState DeathState;
        private IGameState InventoryState;
        private IGameState PlayState;
        private IGameState ScrollState;
        private IGameState PauseState;
        public IGameState CurrentState;
        HUD GameHud;

        public GameStateManager(SpriteFont font, SpriteBatch spriteBatch, Texture2D inventoryTexture, InventoryCursor cursor, HUD gameHud, int screenWidth, int screenHeight)
        {

            DeathState = new DeathState(this, font);
            InventoryState = new InventoryState(this, inventoryTexture, cursor, gameHud);
            PlayState = new PlayState(this, screenWidth, screenHeight);
            ScrollState = new ScrollState(this);
            PauseState = new PauseState(this, font, screenWidth, screenHeight);
            CurrentState = PlayState;
            Console.WriteLine("GameStateManager Constructor");
        }
        public void Update(GameTime gameTime)
        {
            //Call Update on current state
            CurrentState.Update(gameTime);

        }
        public void Draw(SpriteBatch spriteBatch)
        {

            CurrentState.Draw(spriteBatch);
        }
        public void ChangeState(String newState)//Change to enum in the future - lazy for now
        {
            switch (newState)
            {
                case "death":
                    CurrentState = DeathState;
                    break;
                case "inventory":
                    Console.WriteLine("inventory transition");
                    CurrentState = InventoryState;
                    break;
                case "play":
                    Console.WriteLine("play transition");
                    CurrentState = PlayState;
                    break;
                case "scroll":
                    CurrentState = ScrollState;
                    break;
                case "pause":
                    CurrentState = PauseState;
                    break;
            }
        }
        public IGameState GetInventoryState() { return InventoryState; }
    }
}