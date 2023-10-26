using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0.Commands;
using sprint0.Items.groundItems;
using System.Runtime.CompilerServices;
using sprint0.Controllers;
using sprint0.Blocks;
using sprint0.Link;
using System.Collections.Generic;
//using sprint0.Link;


namespace sprint0
{
    public class Sprint0 : Game
    {
        
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        //public ILink Link;
        Texture2D textureBlock;

        //Block
        public IBlock block;
        public IGroundItemSystem groundItems;
        public IItemSystem linkItemSystem;
      
        KeyboardController KeyboardCont;

        public Sprint0()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            //Moved here in order to have values initialized before key mapping
            spriteBatch = new SpriteBatch(GraphicsDevice);
         
            //Block 
            textureBlock = Content.Load<Texture2D>("block_image");
            block = new Block(textureBlock, 3, 4);

            // Linky
            //Link = new Link()
            //Link's Item System
            linkItemSystem = new ItemSystem();
            linkItemSystem.LoadSpriteBatch(spriteBatch);

            //Items on the Ground
            groundItems = new GroundItemSystem(spriteBatch, 200, 200);

            //ATTENTION: MouseController.cs exists, although it is never used due to the interface needing keys and Monogame lacking Keys.LButton and Keys.RButton
            base.Initialize();
        }
      
        protected override void LoadContent()
        {
            //GROUND ITEM SYSTEM STUFF
            Texture2D groundBow = Content.Load<Texture2D>("groundItemSprites/groundBow");
            Texture2D groundBoomerang = Content.Load<Texture2D>("groundItemSprites/groundBoomerang");
            Texture2D groundBomb = Content.Load<Texture2D>("groundItemSprites/groundBomb");
            Texture2D groundBlaze = Content.Load<Texture2D>("groundItemSprites/groundBlaze");
            Texture2D groundHeart = Content.Load<Texture2D>("groundItemSprites/groundHeart");
            Texture2D groundShimmeringRupee = Content.Load<Texture2D>("groundItemSprites/groundShimmeringRupee");
            Texture2D groundFairy = Content.Load<Texture2D>("groundItemSprites/groundFairy");
            Texture2D groundTriforce = Content.Load<Texture2D>("groundItemSprites/groundTriforce");
            Texture2D groundKey = Content.Load<Texture2D>("groundItemSprites/groundKey");
            Texture2D groundRupee = Content.Load<Texture2D>("groundItemSprites/groundRupee");
            Texture2D groundPage = Content.Load<Texture2D>("groundItemSprites/groundPage");
            Texture2D groundBigHeart = Content.Load<Texture2D>("groundItemSprites/groundBigHeart");
            Texture2D groundCompass = Content.Load<Texture2D>("groundItemSprites/groundCompass");
            Texture2D groundClock = Content.Load<Texture2D>("groundItemSprites/groundClock");
            groundItems.LoadBow(groundBow);
            groundItems.LoadBoomerang(groundBoomerang);
            groundItems.LoadBomb(groundBomb);
            groundItems.LoadBlaze(groundBlaze);
            groundItems.LoadHeart(groundHeart);
            groundItems.LoadShimmeringRupee(groundShimmeringRupee);
            groundItems.LoadFairy(groundFairy);
            groundItems.LoadTriforcePiece(groundTriforce);
            groundItems.LoadKey(groundKey);
            groundItems.LoadRupee(groundRupee);
            groundItems.LoadPage(groundPage);
            groundItems.LoadBigHeart(groundBigHeart);
            groundItems.LoadCompass(groundCompass);
            groundItems.LoadClock(groundClock);

            //LINK'S ITEM SYSTEM STUFF

            //Bow
            IList<Texture2D> bowSprites = new List<Texture2D>();
            Texture2D leftBow = Content.Load<Texture2D>("equippedItemSprites/equippedBowLeft");
            Texture2D rightBow = Content.Load<Texture2D>("equippedItemSprites/equippedBowRight");
            Texture2D downBow = Content.Load<Texture2D>("equippedItemSprites/equippedBowDown");
            Texture2D upBow = Content.Load<Texture2D>("equippedItemSprites/equippedBowUp");
            Texture2D bowDespawnSprite = Content.Load<Texture2D>("equippedItemSprites/weaponProjectileHit");
            bowSprites.Add(leftBow);
            bowSprites.Add(rightBow);
            bowSprites.Add(downBow);
            bowSprites.Add(upBow);
            bowSprites.Add(bowDespawnSprite);
            linkItemSystem.LoadBow(bowSprites);

            //BetterBow
            IList<Texture2D> betterBowSprites = new List<Texture2D>();
            Texture2D leftBetterBow = Content.Load<Texture2D>("equippedItemSprites/equippedBetterBowLeft");
            Texture2D rightBetterBow = Content.Load<Texture2D>("equippedItemSprites/equippedBetterBowRight");
            Texture2D downBetterBow = Content.Load<Texture2D>("equippedItemSprites/equippedBetterBowDown");
            Texture2D upBetterBow = Content.Load<Texture2D>("equippedItemSprites/equippedBetterBowUp");
            betterBowSprites.Add(leftBetterBow);
            betterBowSprites.Add(rightBetterBow);
            betterBowSprites.Add(downBetterBow);
            betterBowSprites.Add(upBetterBow);
            betterBowSprites.Add(bowDespawnSprite);
            linkItemSystem.LoadBetterBow(betterBowSprites);

            //Boomerang
            IList<Texture2D> boomerangSprites = new List<Texture2D>();
            Texture2D boomerangGoing = Content.Load<Texture2D>("equippedItemSprites/equippedBoomerangGoing");
            Texture2D boomerangComing = Content.Load<Texture2D>("equippedItemSprites/equippedBoomerangComing");
            boomerangSprites.Add(boomerangGoing);
            boomerangSprites.Add(boomerangComing);
            linkItemSystem.LoadBoomerang(boomerangSprites);

            //Boomerang
            IList<Texture2D> betterBoomerangSprites = new List<Texture2D>();
            Texture2D betterBoomerangGoing = Content.Load<Texture2D>("equippedItemSprites/equippedBetterBoomerangGoing");
            Texture2D betterBoomerangComing = Content.Load<Texture2D>("equippedItemSprites/equippedBetterBoomerangComing");
            betterBoomerangSprites.Add(betterBoomerangGoing);
            betterBoomerangSprites.Add(betterBoomerangComing);
            linkItemSystem.LoadBetterBoomerang(betterBoomerangSprites);

            //Blaze
            IList<Texture2D> blazeSprites = new List<Texture2D>();
            Texture2D blazeSprite = Content.Load<Texture2D>("equippedItemSprites/equippedBlaze");
            blazeSprites.Add(blazeSprite);
            linkItemSystem.LoadBlaze(blazeSprites);

            //Bomb
            IList<Texture2D> bombSprites = new List<Texture2D>();
            Texture2D bombExplodeSprite = Content.Load<Texture2D>("equippedItemSprites/equippedBombExplode");
            bombSprites.Add(groundBomb);
            bombSprites.Add(bombExplodeSprite);
            linkItemSystem.LoadBlaze(bombSprites);

            // TODO: use this.Content to load your game content here

            KeyboardCont = new KeyboardController(this);

            //Register keys with this.
            KeyboardCont.registerKeys();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            Globals.Update(gameTime);
            KeyboardCont.Update();
            groundItems.Update();
            //Link.Update();
            base.Update(gameTime);
            
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            //Block Draw
            spriteBatch.Begin();
            block.Draw(spriteBatch,300,200);
            groundItems.Draw();
            base.Draw(gameTime);
            spriteBatch.End();
        }
    }
}