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
        private IGameState WinState;
        public IGameState CurrentState;
        HUD GameHud;
        private Door EnteredDoor { get; set; }
        public GameStateManager(SpriteFont font, SpriteBatch spriteBatch, SpriteBatch staticHudSB, Texture2D inventoryTexture, InventoryCursor cursor, HUD gameHud, int screenWidth, int screenHeight, SpriteFactory inventoryFactory, ContentManager content, Texture2D titleScreenTexture, Cartographer cartographer,Texture2D winScreenTexture)
        {

            DeathState = new DeathState(this, font, content, this);
            InventoryState = new InventoryState(this, inventoryTexture, cursor, gameHud,inventoryFactory,cartographer);
            PlayState = new PlayState(this, screenWidth, screenHeight, gameHud, spriteBatch,staticHudSB);
            ScrollState = new ScrollState(this, 0, Direction.Up,gameHud,cartographer);
            PauseState = new PauseState(this, font, screenWidth, screenHeight,gameHud);
            TitleState = new TitleScreenState(this, titleScreenTexture,font);
            WinState = new WinState( font, content, this,winScreenTexture);
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
                case "win":
                    CurrentState = WinState;
                    WindWaker.StopSong(WindWaker.Songs.DUNGEON);
                    WindWaker.PlaySong(WindWaker.Songs.TRIFORCE_OBTAIN);
                    break;
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
                    WindWaker.StopSong(WindWaker.Songs.TRIFORCE_OBTAIN);
                    WindWaker.StopSong(WindWaker.Songs.TITLE);
                    WindWaker.StopSong(WindWaker.Songs.ENDING);
                    WindWaker.PlaySong(WindWaker.Songs.DUNGEON);
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
                case "title":
                    CurrentState = TitleState;
                    WindWaker.StopSong(WindWaker.Songs.DUNGEON);
                    WindWaker.StopSong(WindWaker.Songs.ENDING);
                    WindWaker.StopSong(WindWaker.Songs.TRIFORCE_OBTAIN);
                    WindWaker.PlaySong(WindWaker.Songs.TITLE);
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