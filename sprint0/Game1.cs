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
using sprint0.AnimatedSpriteFactory;
using sprint0.Enemies;

namespace sprint0
{
    public class Sprint0 : Game
    {

        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        public ILink LinkObj;
        Texture2D textureBlock;

        /* For Testing Purposes */
        public ISkeleton SkeletonObj;
        public IOktorok OktorokObj;
        public IBokoblin BokoblinObj;

        //Block
        public IBlock block;
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

            /*LINK TEST: TO BE DELETED*/
            Texture2D LinkTexture = Content.Load<Texture2D>("Link");
            /*NOTE: The 5 columns is to get one that is off the screen for damaged state*/
            SpriteFactory LinkFactory = new SpriteFactory(LinkTexture, 3, 4);
            LinkFactory.createAnimation("Up", new int[] { 0, 1 }, new int[] { 2, 2 }, 2);
            LinkFactory.createAnimation("Down", new int[] { 0, 1 }, new int[] { 0, 0 }, 2);
            LinkFactory.createAnimation("Left", new int[] { 0, 1 }, new int[] { 1, 1 }, 2);
            LinkFactory.createAnimation("Right", new int[] { 0, 1 }, new int[] { 3, 3 }, 2);
            LinkFactory.createAnimation("ItemUp", new int[] { 0, 2 }, new int[] { 2, 2 }, 2);
            LinkFactory.createAnimation("ItemDown", new int[] { 0, 2 }, new int[] { 0, 0 }, 2);
            LinkFactory.createAnimation("ItemLeft", new int[] { 0, 2 }, new int[] { 1, 1 }, 2);
            LinkFactory.createAnimation("ItemRight", new int[] { 0, 2 }, new int[] { 3, 3 }, 2);
            /*NOTE: This is to attempt and get a square outside of the sprite sheet so it is blank, may need tweaked if it can't find squares off of the sprite sheet*/
            LinkFactory.createAnimation("Damaged", new int[] { 0 }, new int[] { 0 }, 1);

            LinkObj = new sprint0.Link.Link(400, 200, 1, LinkFactory);

            /*ENEMY TESTS: TO BE DELETED*/
            Texture2D SkeletonTexture = Content.Load<Texture2D>("zelda-sprites-enemies-condensed");
            SpriteFactory SkeletonFactory = new SpriteFactory(SkeletonTexture, 15, 8);
            SkeletonFactory.createAnimation("Default", new int[] { 14, 14 }, new int[] { 4, 5 }, 2);
            SkeletonObj = new sprint0.Enemies.Skeleton(200, 400, 1, SkeletonFactory);

            Texture2D OktorokTexture = Content.Load<Texture2D>("zelda-sprites-enemies-condensed");
            SpriteFactory OktorokFactory = new SpriteFactory(OktorokTexture, 15, 8);
            OktorokFactory.createAnimation("Down", new int[] { 0, 0 }, new int[] { 0, 1 }, 2);
            OktorokFactory.createAnimation("Left", new int[] { 1, 1 }, new int[] { 0, 1 }, 2);
            OktorokFactory.createAnimation("Up", new int[] { 2, 2 }, new int[] { 0, 1 }, 2);
            OktorokFactory.createAnimation("Right", new int[] { 3, 3 }, new int[] { 0, 1 }, 2);
            OktorokObj = new sprint0.Enemies.Oktorok(200, 400, 1, OktorokFactory);

            Texture2D BokoblinTexture = Content.Load<Texture2D>("zelda-sprites-enemie-condensed");
            SpriteFactory BokoblinFactory = new SpriteFactory(OktorokTexture, 15, 8);
            BokoblinFactory.createAnimation("Down", new int[] { 4, 4 }, new int[] { 4, 5 }, 2);
            BokoblinFactory.createAnimation("Left", new int[] { 5, 5 }, new int[] { 4, 5 }, 2);
            BokoblinFactory.createAnimation("Up", new int[] { 6, 6 }, new int[] { 4, 5 }, 2);
            BokoblinFactory.createAnimation("Right", new int[] { 7, 7 }, new int[] { 4, 5 }, 2);
            BokoblinObj = new sprint0.Enemies.Bokoblin(200, 400, 1, BokoblinFactory);

            //ATTENTION: MouseController.cs exists, although it is never used due to the interface needing keys and Monogame lacking Keys.LButton and Keys.RButton
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // GROUND ITEM SYSTEM STUFF
            // SMELLY IMPLEMENTATION: These should really go in one big texture to cut down on factories.
            Texture2D groundBoomerangTexture = Content.Load<Texture2D>("groundItemSprites/groundBoomerang");
            SpriteFactory groundBoomerangFactory = new SpriteFactory(groundBoomerangTexture, 1, 1);
            groundBoomerangFactory.createAnimation("GroundBoomerang", new int[] { 0 }, new int[] { 0 }, 1); // single sprite animation

            Texture2D groundBombTexture = Content.Load<Texture2D>("groundItemSprites/groundBomb");
            SpriteFactory groundBombFactory = new SpriteFactory(groundBombTexture, 1, 1);
            groundBombFactory.createAnimation("GroundBomb", new int[] { 0 }, new int[] { 0 }, 1); // single sprite animation

            Texture2D groundBlazeTexture = Content.Load<Texture2D>("groundItemSprites/groundBlaze");
            SpriteFactory groundBlazeFactory = new SpriteFactory(groundBlazeTexture, 1, 1);
            groundBlazeFactory.createAnimation("GroundBlaze", new int[] { 0 }, new int[] { 0 }, 1); // single sprite animation

            Texture2D groundHeartTexture = Content.Load<Texture2D>("groundItemSprites/groundHeart");
            SpriteFactory groundHeartFactory = new SpriteFactory(groundHeartTexture, 1, 1);
            groundHeartFactory.createAnimation("GroundHeart", new int[] { 0 }, new int[] { 0 }, 1); // single sprite animation

            Texture2D groundTriforceTexture = Content.Load<Texture2D>("groundItemSprites/groundTriforce");
            SpriteFactory groundTriforceFactory = new SpriteFactory(groundTriforceTexture, 1, 1);
            groundTriforceFactory.createAnimation("GroundTriforce", new int[] { 0 }, new int[] { 0 }, 1); // single sprite animation

            Texture2D groundKeyTexture = Content.Load<Texture2D>("groundItemSprites/groundKey");
            SpriteFactory groundKeyFactory = new SpriteFactory(groundKeyTexture, 1, 1);
            groundKeyFactory.createAnimation("GroundKey", new int[] { 0 }, new int[] { 0 }, 1); // single sprite animation

            Texture2D groundPageTexture = Content.Load<Texture2D>("groundItemSprites/groundPage");
            SpriteFactory groundPageFactory = new SpriteFactory(groundPageTexture, 1, 1);
            groundPageFactory.createAnimation("GroundPage", new int[] { 0 }, new int[] { 0 }, 1); // single sprite animation

            Texture2D groundBigHeartTexture = Content.Load<Texture2D>("groundItemSprites/groundBigHeart");
            SpriteFactory groundBigHeartFactory = new SpriteFactory(groundBigHeartTexture, 1, 1);
            groundBigHeartFactory.createAnimation("GroundBigHeart", new int[] { 0 }, new int[] { 0 }, 1); // single sprite animation

            Texture2D groundCompassTexture = Content.Load<Texture2D>("groundItemSprites/groundCompass");
            SpriteFactory groundCompassFactory = new SpriteFactory(groundCompassTexture, 1, 1);
            groundCompassFactory.createAnimation("GroundCompass", new int[] { 0 }, new int[] { 0 }, 1); // single sprite animation
            // Level Loader should place these items in the right spots, yes? I can instantiate them here and draw them for testing purposes if we'd like.

            //LINK'S ITEM SYSTEM STUFF

            //Bow + Better Bow
            Texture2D bowTexture = Content.Load<Texture2D>("equippedItemSprites/equippedBowDown");
            SpriteFactory bowFactory = new SpriteFactory(bowTexture, 1, 1);
            bowFactory.createAnimation("Bow", new int[] { 0 }, new int[] { 0 }, 1); // single sprite animation 
            Texture2D betterBowTexture = Content.Load<Texture2D>("equippedItemSprites/equippedBetterBowDown");
            SpriteFactory betterBowFactory = new SpriteFactory(betterBowTexture, 1, 1);
            bowFactory.createAnimation("BetterBow", new int[] { 0 }, new int[] { 0 }, 1); // single sprite animation 
            Texture2D bowDespawnTexture = Content.Load<Texture2D>("equippedItemSprites/weaponProjectileHit");
            SpriteFactory bowDespawnFactory = new SpriteFactory(bowDespawnTexture, 1, 1);
            bowFactory.createAnimation("BowDespawn", new int[] { 0 }, new int[] { 0 }, 1); // single sprite animation
            linkItemSystem.LoadBow(bowFactory, bowDespawnFactory);
            linkItemSystem.LoadBetterBow(betterBowFactory, bowDespawnFactory);

            //Boomerang + Better Boomerang
            Texture2D boomerangTexture = Content.Load<Texture2D>("equippedItemSprites/equippedBoomerang");
            SpriteFactory boomerangFactory = new SpriteFactory(boomerangTexture, 2, 3);
            boomerangFactory.createAnimation("Coming", new int[] { 0, 0, 0 }, new int[] { 0, 1, 2 }, 3);
            boomerangFactory.createAnimation("Going", new int[] { 1, 1, 1 }, new int[] { 0, 1, 2 }, 3);
            Texture2D betterBoomerangTexture = Content.Load<Texture2D>("equippedItemSprites/equippedBetterBoomerang");
            SpriteFactory betterBoomerangFactory = new SpriteFactory(betterBoomerangTexture, 2, 3);
            betterBoomerangFactory.createAnimation("Coming", new int[] { 0, 0, 0 }, new int[] { 0, 1, 2 }, 3);
            betterBoomerangFactory.createAnimation("Going", new int[] { 1, 1, 1 }, new int[] { 0, 1, 2 }, 3);
            linkItemSystem.LoadBoomerang(boomerangFactory);
            linkItemSystem.LoadBetterBoomerang(betterBoomerangFactory);

            //Blaze
            Texture2D blazeTexture = Content.Load<Texture2D>("equippedItemSprites/equippedBlaze");
            SpriteFactory blazeFactory = new SpriteFactory(blazeTexture, 1, 2);
            blazeFactory.createAnimation("Blaze", new int[] { 0, 0 }, new int[] { 0, 1 }, 2);
            linkItemSystem.LoadBlaze(blazeFactory);

            //Bomb
            Texture2D bombTexture = Content.Load<Texture2D>("groundItemSprites/groundBomb");
            SpriteFactory bombFactory = new SpriteFactory(bombTexture, 1, 1);
            bombFactory.createAnimation("Bomb", new int[] { 0 }, new int[] { 0 }, 1); // single sprite animation 
            Texture2D bombExplodeTexture = Content.Load<Texture2D>("equippedItemSprites/equippedBombExplode");
            SpriteFactory bombExplodeFactory = new SpriteFactory(bombExplodeTexture, 1, 3);
            bombExplodeFactory.createAnimation("Going", new int[] { 0, 0, 0 }, new int[] { 0, 1, 2 }, 3);
            linkItemSystem.LoadBomb(bombFactory, bombExplodeFactory);

            // TODO: use this.Content to load your game content here

            KeyboardCont = new KeyboardController(this);

            //Register keys with this.
            KeyboardCont.registerKeys();
        }

        protected override void Update(GameTime gameTime)
        {

            // TODO: Add your update logic here

            KeyboardCont.Update();
            linkItemSystem.Update();

            /*LINK ADDED FOR TESTING: TO BE DELETED*/
            LinkObj.Update();

            /*ENEMY ADDED FOR TESTING: TO BE DELETED*/
            SkeletonObj.Update();
            OktorokObj.Update();
            BokoblinObj.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            //Block Draw
            spriteBatch.Begin();
            /*LINK ADDED FOR TESTING: TO BE DELETED*/
            LinkObj.Draw(spriteBatch);
            linkItemSystem.Draw();
            base.Draw(gameTime);
            spriteBatch.End();
        }
    }
}