using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static sprintzero.Game1;

namespace sprintzero
{

    public class Game1 : Game
    {
        public interface IController
        {
            public int processInput();
        }

        public interface ISprite
        {
            public void Update(Viewport viewPort);
            public void Draw(SpriteBatch spriteBatch);
        }

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D mario;
        private ISprite displayedSprite;
        private ISprite movingAnimatedSprite;
        private ISprite movingNonAnimatedSprite;
        private ISprite nonMovingAnimatedSprite;
        private ISprite nonMovingNonAnimatedSprite;
        private SpriteFont font;
        private IController keyboard;
        private IController mouse;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            keyboard = new KeyboardController();
            mouse = new MouseController();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            mario = Content.Load<Texture2D>("mario");
            movingAnimatedSprite = new MovingAnimatedSprite(mario, 1, 4);
            nonMovingNonAnimatedSprite = new NonMovingNonAnimatedSprite(mario, 1, 4);
            movingNonAnimatedSprite = new MovingNonAnimatedSprite(mario, 1, 4);
            nonMovingAnimatedSprite = new NonMovingAnimatedSprite(mario, 1, 4);
            displayedSprite = nonMovingNonAnimatedSprite;

            font = Content.Load<SpriteFont>("font");
            base.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            int spriteType = mouse.processInput();
            if (spriteType == -1) // no mouse input, so ask the keyboard
                spriteType = keyboard.processInput();
            switch (spriteType)
                {
                    case 0:
                        Exit();
                        break;
                    case 2:
                        displayedSprite = nonMovingAnimatedSprite;
                        break;
                    case 3:
                        displayedSprite = movingNonAnimatedSprite;
                        break;
                    case 4:
                        displayedSprite = movingAnimatedSprite;
                        break;
                    default:
                        displayedSprite = nonMovingNonAnimatedSprite;
                        break;
                }
            
            displayedSprite.Update(this.GraphicsDevice.Viewport);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            displayedSprite.Draw(_spriteBatch);
            _spriteBatch.Begin();
            _spriteBatch.DrawString(font, "Credits\nProgram Made By: UGONNA OBIAGWU\nSprites from: mariouniverse.com", new Vector2(100, 100), Color.Black);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}

