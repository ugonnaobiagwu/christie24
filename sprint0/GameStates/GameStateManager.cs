using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.GameStates;
using sprint0.HUDs;
using sprint0.BoundariesDoorsAndRooms;
using sprint0.AnimatedSpriteFactory;
using static sprint0.Globals;

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
        private Door EnteredDoor { get; set; }
        public GameStateManager(SpriteFont font, SpriteBatch spriteBatch, Texture2D inventoryTexture, InventoryCursor cursor, HUD gameHud, int screenWidth, int screenHeight, SpriteFactory inventoryFactory)
        {

            DeathState = new DeathState(this, font);
            InventoryState = new InventoryState(this, inventoryTexture, cursor, gameHud,inventoryFactory);
            PlayState = new PlayState(this, screenWidth, screenHeight, gameHud);
            ScrollState = new ScrollState(this, 0, Direction.Up);
            PauseState = new PauseState(this, font, screenWidth, screenHeight,gameHud);
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
        public void SetNewScrollState(int toRoomId, Direction sideOfRoom)
        {
            ScrollState = new ScrollState(this,toRoomId,sideOfRoom);
            if (CurrentState.Equals(PlayState)) { this.ChangeState("scroll"); }
        }
    }
}