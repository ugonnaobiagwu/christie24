using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.GameStates;
using sprint0.HUDs;
using sprint0.BoundariesDoorsAndRooms;
using sprint0.AnimatedSpriteFactory;
using static sprint0.Globals;
using Microsoft.Xna.Framework.Content;
using sprint0.Sound.Ocarina;

namespace sprint0.GameStates
{
    public class GameStateManager
    {
        private IGameState DeathState;
        private IGameState InventoryState;
        private IGameState PlayState;
        private IGameState ScrollState;
        private IGameState PauseState;
        private IGameState TitleState;
        public IGameState CurrentState;
        HUD GameHud;
        private Door EnteredDoor { get; set; }
        public GameStateManager(SpriteFont font, SpriteBatch spriteBatch, SpriteBatch staticHudSB, Texture2D inventoryTexture, InventoryCursor cursor, HUD gameHud, int screenWidth, int screenHeight, SpriteFactory inventoryFactory, ContentManager content, Texture2D titleScreenTexture)
        {

            DeathState = new DeathState(this, font, content, this);
            InventoryState = new InventoryState(this, inventoryTexture, cursor, gameHud,inventoryFactory);
            PlayState = new PlayState(this, screenWidth, screenHeight, gameHud, spriteBatch,staticHudSB);
            ScrollState = new ScrollState(this, 0, Direction.Up,gameHud);
            PauseState = new PauseState(this, font, screenWidth, screenHeight,gameHud);
            TitleState = new TitleScreenState(this, titleScreenTexture,font);
            CurrentState = TitleState;
            Console.WriteLine("GameStateManager Constructor");
        }
        public void Update(GameTime gameTime)
        {
            //Call Update on current state
            CurrentState.Update(gameTime);

        }
        public void Draw(SpriteBatch spriteBatch, SpriteBatch HudInvSpriteBatch)
        {

            CurrentState.Draw(spriteBatch, HudInvSpriteBatch);
        }
        public void ChangeState(String newState)//Change to enum in the future - lazy for now
        {
            switch (newState)
            {
                case "death":
                    CurrentState = DeathState;
                    WindWaker.StopSong(WindWaker.Songs.DUNGEON);
                    WindWaker.PlaySong(WindWaker.Songs.ENDING);
                    break;
                case "inventory":
                    Console.WriteLine("inventory transition");
                    CurrentState = InventoryState;
                    break;
                case "play":
                    Console.WriteLine("play transition");
                    CurrentState = PlayState;
                    WindWaker.ResumeSong(WindWaker.Songs.DUNGEON);

                    break;
                case "scroll":
                    CurrentState = ScrollState;
                    break;
                case "pause":
                    CurrentState = PauseState;
                    WindWaker.PauseSong(WindWaker.Songs.DUNGEON);
                    break;
            }
        }
        public IGameState GetInventoryState() { return InventoryState; }
        //public void SetNewScrollState(int toRoomId, Direction sideOfRoom)
        //{
        //    ScrollState = new ScrollState(this,toRoomId,sideOfRoom);
        //    if (CurrentState.Equals(PlayState)) { this.ChangeState("scroll"); }
        //}
    }
}