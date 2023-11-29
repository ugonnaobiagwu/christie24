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
using sprint0.GameStates;

using sprint0.HUDs;


using sprint0.Collision;
using sprint0.LevelLoading;
using System.Xml;
using System;

namespace sprint0
{
    public class Sprint0 : Game
    {

        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        //public ILink LinkObj;
        Texture2D textureBlock;

        //HUD
     
        SpriteFont font;
        
        HUD hud;

        /* For Testing Purposes */
        public Skeleton SkeletonObj;
        public Oktorok OktorokObj;
        public Bokoblin BokoblinObj;
        public Dragon DragonObj;

        public GroundHeart heart;

        //Camera
        public Camera camera;
        ScrollState scrollState;
        MouseState mouse;
        
        //Block
        public IBlock block;
        KeyboardController KeyboardCont;
        ItemSystem itemSystem;

        //State Manager - in progress
        GameStateManager gameStateManager;
        SpriteFactory InventoryFactory;
        InventoryController InventoryCont;
        InventoryCursor Cursor;


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

            //HUD
            font = Content.Load<SpriteFont>("hudFont");

            //hud = new HUD(spriteBatch, font);
           Inventory.SetContentManager(Content);
           
            //TEST for XP
            // //Highest point is 9.0. Antyhing below 0 or above a 9 becomes the default green link
            // Low 0 - 2.9 Mid 3.0 - 5.9 High 6-8.9
            // Each block per bar is .375, so a full block would be 3
           /* Inventory.UpdateXPLevel(6f);
            Inventory.UpdateXPLevel(.22f);
            Inventory.UpdateXPLevel(.22f);
            Inventory.UpdateXPLevel(-.375f)*/;
            Inventory.UpdateXPLevel(6f);
           // Inventory.UpdateXPLevel(.375f);

            hud = new HUD(spriteBatch, font, hudSpriteSheet, lifeSpriteSheet,miniMapSpriteSheet, linkLocatorSpriteSheet);
            /*
            //Block 
            textureBlock = Content.Load<Texture2D>("Dungeon1BlockSpriteSheet");
            SpriteFactory blockFactory = new SpriteFactory(textureBlock, 3, 4);
            blockFactory.createAnimation("DungeonBlueBlock",new int[] {0 },new int[] {0 }, 1);
            blockFactory.createAnimation("DungeonPyramidBlock", new int[] { 0 }, new int[] { 1 }, 1,0.0f,0.3f,0.2f);
            blockFactory.createAnimation("DungeonFishBlock", new int[] { 0 }, new int[] { 2 }, 1);
            blockFactory.createAnimation("DungeonDragonBlock", new int[] { 0 }, new int[] { 3 }, 1);
            blockFactory.createAnimation("BlackBlock", new int[] { 1 }, new int[] { 0 }, 1);
            blockFactory.createAnimation("GrassBlock", new int[] { 1 }, new int[] { 1 }, 1);
            blockFactory.createAnimation("StairBlock", new int[] { 1 }, new int[] { 2 }, 1);
            blockFactory.createAnimation("WaterBlock", new int[] { 1 }, new int[] { 3 }, 1);
            blockFactory.createAnimation("PyramidRedBlock", new int[] { 2 }, new int[] { 0 }, 1);
            blockFactory.createAnimation("BlueFishBlock", new int[] { 2 }, new int[] { 1 }, 1);
            blockFactory.createAnimation("BlueDragonBlock", new int[] { 2 }, new int[] { 2 }, 1);

            block = new DungeonPyramidBlock(0, 0, 1, blockFactory);
            */
            // Linky
            //Link = new Link()
            //Link's Item System
            Globals.LinkItemSystem.LoadSpriteBatch(spriteBatch);

            /*LINK TEST: TO BE DELETED*/
            //Texture2D LinkTexture = Content.Load<Texture2D>("Link");
            ///*NOTE: The 5 columns is to get one that is off the screen for damaged state*/
            //SpriteFactory LinkFactory = new SpriteFactory(LinkTexture, 5, 4);

            
            
            
            //LinkFactory.createAnimation("GreenUp", new int[] { 0, 1 }, new int[] { 2, 2 }, 2,1.5f,1.5f);
            //LinkFactory.createAnimation("GreenDown", new int[] { 0, 1 }, new int[] { 0, 0 }, 2, 1.5f, 1.5f);
            //LinkFactory.createAnimation("GreenLeft", new int[] { 0, 1 }, new int[] { 1, 1 }, 2, 1.5f, 1.5f);
            //LinkFactory.createAnimation("GreenRight", new int[] { 0, 1 }, new int[] { 3, 3 }, 2, 1.5f, 1.5f);
            //LinkFactory.createAnimation("GreenItemUp", new int[] { 0, 2 }, new int[] { 2, 2 }, 2, 1.5f, 1.5f);
            //LinkFactory.createAnimation("GreenItemDown", new int[] { 0, 2 }, new int[] { 0, 0 }, 2, 1.5f, 1.5f);
            //LinkFactory.createAnimation("GreenItemLeft", new int[] { 0, 2 }, new int[] { 1, 1 }, 2, 1.5f, 1.5f);
            //LinkFactory.createAnimation("GreenItemRight", new int[] { 0, 2 }, new int[] { 3, 3 }, 2, 1.5f, 1.5f);
           
            //LinkFactory.createAnimation("Damaged", new int[] { 3}, new int[] { 3 }, 1, 1.5f, 1.5f);

            //LinkObj = new sprint0.LinkObj.Link(400, 200, LinkFactory);
            //LinkObj.SetRoomId(0);

            /*ENEMY TESTS: TO BE DELETED*/
            //Texture2D EnemyTexture = Content.Load<Texture2D>("zelda-sprites-enemies-condensed");

            //SpriteFactory SkeletonFactory = new SpriteFactory(EnemyTexture, 6, 15);
            //SkeletonFactory.createAnimation("Default", new int[] { 4, 5 }, new int[] { 14, 14 }, 2, 0.25f, 1.5f, 1.5f);
            //SkeletonObj = new sprint0.Enemies.Skeleton(0, 600, 1, SkeletonFactory);

            //SpriteFactory OktorokFactory = new SpriteFactory(EnemyTexture, 6, 15);
            //SpriteFactory OktorokProjectileFactory = new SpriteFactory(EnemyTexture, 6, 15);
            //OktorokFactory.createAnimation("Down", new int[] { 0, 1 }, new int[] { 0, 0 }, 2, 0.25f, 1.5f, 1.5f);
            //OktorokFactory.createAnimation("Left", new int[] { 0, 1 }, new int[] { 1, 1 }, 2, 0.25f, 1.5f, 1.5f);
            //OktorokFactory.createAnimation("Up", new int[] { 0, 1 }, new int[] { 2, 2 }, 2, 0.25f, 1.5f, 1.5f);
            //OktorokFactory.createAnimation("Right", new int[] { 0, 1 }, new int[] { 3, 3 }, 2, 0.25f, 1.5f, 1.5f);
            //OktorokProjectileFactory.createAnimation("Blaze", new int[] { 1 }, new int[] { 12 }, 1, 0.125f, 1.5f, 1.5f);
            //OktorokObj = new sprint0.Enemies.Oktorok(100, 600, 1, OktorokFactory, OktorokProjectileFactory);

            //SpriteFactory BokoblinFactory = new SpriteFactory(EnemyTexture, 6, 15);
            //Texture2D BokoblinBoomerangTexture = Content.Load<Texture2D>("equippedItemSprites/equippedBoomerang");
            //SpriteFactory BokoblinBoomerangFactory = new SpriteFactory(BokoblinBoomerangTexture, 2, 3);
            //BokoblinFactory.createAnimation("Down", new int[] { 4, 5 }, new int[] { 4, 4 }, 2, 0.25f, 1.5f, 1.5f);
            //BokoblinFactory.createAnimation("Left", new int[] { 4, 5 }, new int[] { 5, 5 }, 2, 0.25f, 1.5f, 1.5f);
            //BokoblinFactory.createAnimation("Up", new int[] { 4, 5 }, new int[] { 6, 6 }, 2, 0.25f, 1.5f, 1.5f);
            //BokoblinFactory.createAnimation("Right", new int[] { 4, 5 }, new int[] { 7, 7 }, 2, 0.25f, 1.5f, 1.5f);
            //BokoblinBoomerangFactory.createAnimation("Coming", new int[] { 0, 0, 0 }, new int[] { 0, 1, 2 }, 3, 0.125f, 1.5f, 1.5f);
            //BokoblinBoomerangFactory.createAnimation("Going", new int[] { 1, 1, 1 }, new int[] { 0, 1, 2 }, 3, 0.125f, 1.5f, 1.5f);
            //BokoblinObj = new sprint0.Enemies.Bokoblin(200, 600, 1, BokoblinFactory, BokoblinBoomerangFactory);

            //Texture2D DragonTexture = Content.Load<Texture2D>("legendofzelda_bosses_sheet");
            //SpriteFactory DragonFactory = new SpriteFactory(DragonTexture, 1, 4);
            //SpriteFactory DragonBlazeFactory = new SpriteFactory(EnemyTexture, 6, 15);
            //DragonFactory.createAnimation("Default", new int[] {0, 0, 0, 0}, new int[] {0, 1, 2, 3}, 4, 0.25f, 2.0f, 2.0f);
            //DragonBlazeFactory.createAnimation("Blaze", new int[] { 0 }, new int[] { 11 }, 1, 0.125f, 1.5f, 1.5f);
            //DragonObj = new sprint0.Enemies.Dragon(300, 600, 1, DragonFactory, DragonBlazeFactory);



            //Game States - in progress
            Texture2D InventoryTexture = Content.Load<Texture2D>("zeldaMenuBlank");
            Texture2D CursorTexture = Content.Load<Texture2D>("zeldaCursor");
            Texture2D inventoryItemsTexture = Content.Load<Texture2D>("itemSpriteSheet");
            InventoryFactory = new SpriteFactory(inventoryItemsTexture, 4, 15);
            InventoryFactory.createAnimation("Boomerang", new int[] { 3 }, new int[] { 7 }, 1, 1, 3, 2);
            InventoryFactory.createAnimation("Bomb", new int[] { 1 }, new int[] { 13 }, 1, 1, 3, 2);
            InventoryFactory.createAnimation("Bow", new int[] { 2 }, new int[] { 15 }, 1, 1, 3, 2);
            InventoryFactory.createAnimation("Blaze", new int[] { 0 }, new int[] { 14 }, 1, 1, 3, 2);
            Cursor = new InventoryCursor(CursorTexture, 450, -300);
            gameStateManager = new GameStateManager(font, spriteBatch, InventoryTexture, Cursor, hud, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height, InventoryFactory);
           
            mouse = Mouse.GetState();

            //ATTENTION: MouseController.cs exists, although it is never used due to the interface needing keys and Monogame lacking Keys.LButton and Keys.RButton
            base.Initialize();
        }

        protected override void LoadContent()
        {
            XmlDocument xmlFile = new XmlDocument();
            xmlFile.Load("Content/FirstDungeon.xml");
            XmlParser.ParseFile(xmlFile, Content);

            //Sword
            Texture2D swordTexture = Content.Load<Texture2D>("linkSword");
            Texture2D iceSwordTexture = Content.Load<Texture2D>("linkIceSword");
            Texture2D fireSwordTexture = Content.Load<Texture2D>("linkFireSword");
            SpriteFactory swordFactory = new SpriteFactory(swordTexture, 1, 4);
            swordFactory.createAnimation("ItemDown", new int[] { 0 }, new int[] { 0 }, 1); // single sprite animation 
            swordFactory.createAnimation("ItemLeft", new int[] { 0 }, new int[] { 1 }, 1); // single sprite animation 
            swordFactory.createAnimation("ItemUp", new int[] { 0 }, new int[] { 2 }, 1); // single sprite animation 
            swordFactory.createAnimation("ItemRight", new int[] { 0 }, new int[] { 3 }, 1); // single sprite animation
            SpriteFactory iceSwordFactory = new SpriteFactory(iceSwordTexture, 1, 4);
            iceSwordFactory.createAnimation("ItemDown", new int[] { 0 }, new int[] { 0 }, 1); // single sprite animation 
            iceSwordFactory.createAnimation("ItemLeft", new int[] { 0 }, new int[] { 1 }, 1); // single sprite animation 
            iceSwordFactory.createAnimation("ItemUp", new int[] { 0 }, new int[] { 2 }, 1); // single sprite animation 
            iceSwordFactory.createAnimation("ItemRight", new int[] { 0 }, new int[] { 3 }, 1); // single sprite animation
            SpriteFactory fireSwordFactory = new SpriteFactory(fireSwordTexture, 1, 4);
            fireSwordFactory.createAnimation("ItemDown", new int[] { 0 }, new int[] { 0 }, 1); // single sprite animation 
            fireSwordFactory.createAnimation("ItemLeft", new int[] { 0 }, new int[] { 1 }, 1); // single sprite animation 
            fireSwordFactory.createAnimation("ItemUp", new int[] { 0 }, new int[] { 2 }, 1); // single sprite animation 
            fireSwordFactory.createAnimation("ItemRight", new int[] { 0 }, new int[] { 3 }, 1); // single sprite animation 
            Globals.LinkItemSystem.LoadSword(swordFactory, iceSwordFactory, fireSwordFactory);

            Globals.LinkItemSystem.CurrentTunic = Globals.LinkTunic.FIRE;

            //SoundEffects
            SoundEffect SWORD_SLASH = Content.Load<SoundEffect>("soundEffects/SWORD_SLASH");
            SoundEffect SWORD_SHOOT = Content.Load<SoundEffect>("soundEffects/SWORD_SHOOT");
            SoundEffect SHIELD = Content.Load<SoundEffect>("soundEffects/SHIELD");
            SoundEffect ARROW_BOOMERANG_LAUNCH = Content.Load<SoundEffect>("soundEffects/ARROW_BOOMERANG_LAUNCH");
            SoundEffect BOMB_DROP = Content.Load<SoundEffect>("soundEffects/BOMB_DROP");
            SoundEffect BOMB_EXPLODE = Content.Load<SoundEffect>("soundEffects/BOMB_EXPLODE");
            SoundEffect ENEMY_HIT = Content.Load<SoundEffect>("soundEffects/ENEMY_HIT");
            SoundEffect ENEMY_DIE = Content.Load<SoundEffect>("soundEffects/ENEMY_DIE");
            SoundEffect LINK_TAKE_DAMAGE = Content.Load<SoundEffect>("soundEffects/LINK_TAKE_DAMAGE");
            SoundEffect LINK_DEATH = Content.Load<SoundEffect>("soundEffects/LINK_DEATH");
            SoundEffect LINK_LOW_HEALTH = Content.Load<SoundEffect>("soundEffects/LINK_LOW_HEALTH");
            SoundEffect FANFARE = Content.Load<SoundEffect>("soundEffects/FANFARE");
            SoundEffect LINK_ITEM_GET = Content.Load<SoundEffect>("soundEffects/INVENTORY_LINK_ITEM_GET");
            SoundEffect GET_GROUND_HEART_KEY = Content.Load<SoundEffect>("soundEffects/GET_GROUND_HEART_KEY");
            SoundEffect GET_GROUND_RUPEE = Content.Load<SoundEffect>("soundEffects/GET_GROUND_RUPEE");
            SoundEffect REFILL = Content.Load<SoundEffect>("soundEffects/REFILL");
            SoundEffect TEXT_APPEAR = Content.Load<SoundEffect>("soundEffects/TEXT_APPEAR");
            SoundEffect GROUND_KEY_APPEAR = Content.Load<SoundEffect>("soundEffects/GROUND_KEY_APPEAR");
            SoundEffect DOOR_UNLOCK = Content.Load<SoundEffect>("soundEffects/DOOR_UNLOCK");
            SoundEffect BOSS_AQUAMENTUS_SCREAM = Content.Load<SoundEffect>("soundEffects/BOSS_AQUAMENTUS_SCREAM");
            SoundEffect BOSS_TAKE_DAMAGE = Content.Load<SoundEffect>("soundEffects/BOSS_TAKE_DAMAGE");
            SoundEffect STAIRS = Content.Load<SoundEffect>("soundEffects/STAIRS");
            SoundEffect PUZZLE_SOLVED = Content.Load<SoundEffect>("soundEffects/PUZZLE_SOLVED");
            SoundEffect BLAZE = Content.Load<SoundEffect>("soundEffects/BLAZE");

            Ocarina.LoadSoundEffect(Ocarina.SoundEffects.SWORD_SLASH, SWORD_SLASH);
            Ocarina.LoadSoundEffect(Ocarina.SoundEffects.SWORD_SHOOT, SWORD_SHOOT);
            Ocarina.LoadSoundEffect(Ocarina.SoundEffects.SHIELD, SHIELD);
            Ocarina.LoadSoundEffect(Ocarina.SoundEffects.BOOMERANG_LAUNCH, ARROW_BOOMERANG_LAUNCH, true);
            Ocarina.LoadSoundEffect(Ocarina.SoundEffects.ARROW_LAUNCH, ARROW_BOOMERANG_LAUNCH, false);
            Ocarina.LoadSoundEffect(Ocarina.SoundEffects.BOMB_DROP, BOMB_DROP);
            Ocarina.LoadSoundEffect(Ocarina.SoundEffects.BOMB_EXPLODE, BOMB_EXPLODE);
            Ocarina.LoadSoundEffect(Ocarina.SoundEffects.ENEMY_HIT, ENEMY_HIT);
            Ocarina.LoadSoundEffect(Ocarina.SoundEffects.ENEMY_DIE, ENEMY_DIE);
            Ocarina.LoadSoundEffect(Ocarina.SoundEffects.LINK_TAKE_DAMAGE, LINK_TAKE_DAMAGE);
            Ocarina.LoadSoundEffect(Ocarina.SoundEffects.LINK_DEATH, LINK_DEATH);
            Ocarina.LoadSoundEffect(Ocarina.SoundEffects.LINK_LOW_HEALTH, LINK_LOW_HEALTH);
            Ocarina.LoadSoundEffect(Ocarina.SoundEffects.FANFARE, FANFARE);
            Ocarina.LoadSoundEffect(Ocarina.SoundEffects.LINK_ITEM_GET, LINK_ITEM_GET);
            Ocarina.LoadSoundEffect(Ocarina.SoundEffects.GET_GROUND_HEART_KEY, GET_GROUND_HEART_KEY);
            Ocarina.LoadSoundEffect(Ocarina.SoundEffects.GET_GROUND_RUPEE, GET_GROUND_RUPEE);
            Ocarina.LoadSoundEffect(Ocarina.SoundEffects.REFILL, REFILL);
            Ocarina.LoadSoundEffect(Ocarina.SoundEffects.TEXT_APPEAR, TEXT_APPEAR);
            Ocarina.LoadSoundEffect(Ocarina.SoundEffects.GROUND_KEY_APPEAR, GROUND_KEY_APPEAR);
            Ocarina.LoadSoundEffect(Ocarina.SoundEffects.DOOR_UNLOCK, DOOR_UNLOCK);
            Ocarina.LoadSoundEffect(Ocarina.SoundEffects.BOSS_AQUAMENTUS_SCREAM, BOSS_AQUAMENTUS_SCREAM);
            Ocarina.LoadSoundEffect(Ocarina.SoundEffects.BOSS_TAKE_DAMAGE, BOSS_TAKE_DAMAGE);
            Ocarina.LoadSoundEffect(Ocarina.SoundEffects.STAIRS, STAIRS);
            Ocarina.LoadSoundEffect(Ocarina.SoundEffects.PUZZLE_SOLVED, PUZZLE_SOLVED);
            Ocarina.LoadSoundEffect(Ocarina.SoundEffects.BLAZE, BLAZE);

            //Songs
            SoundEffect TITLE = Content.Load<SoundEffect>("songs/TITLE");
            SoundEffect OVERWORLD = Content.Load<SoundEffect>("songs/OVERWORLD");
            SoundEffect DUNGEON = Content.Load<SoundEffect>("songs/DUNGEON");
            SoundEffect ENDING = Content.Load<SoundEffect>("songs/ENDING");
            SoundEffect TRIFORCE_OBTAIN = Content.Load<SoundEffect>("songs/TRIFORCE_OBTAIN");

            WindWaker.LoadSong(WindWaker.Songs.TITLE, TITLE, true);
            WindWaker.LoadSong(WindWaker.Songs.OVERWORLD, OVERWORLD, true);
            WindWaker.LoadSong(WindWaker.Songs.DUNGEON, DUNGEON, true);
            WindWaker.LoadSong(WindWaker.Songs.ENDING, ENDING, true);
            WindWaker.LoadSong(WindWaker.Songs.TRIFORCE_OBTAIN, TRIFORCE_OBTAIN);

            WindWaker.PlaySong(WindWaker.Songs.DUNGEON);

            // Camera, keep this since I need graphics -- DELETE WHEN SCROLLING IS GOOD.
            Globals.Camera.FollowLink(graphics, true);
            // TODO: use this.Content to load your game content here

            KeyboardCont = new KeyboardController(this);

            //Register keys with this.
            KeyboardCont.registerKeys();
            //Everything below this is temp work for GameStates
            Globals.keyboardController = KeyboardCont;
           InventoryCont = new InventoryController(this, Cursor);
            InventoryCont.registerKeys();
            Globals.inventoryController = InventoryCont;

            InitialStateHolder.InitialCamera = Globals.Camera;
            InitialStateHolder.InitialGameObjectManager = Globals.GameObjectManager;
            InitialStateHolder.InitialLink = Globals.Link;

        }

        protected override void Update(GameTime gameTime)
        {

            // TODO: Add your update logic here
            //GameState testing
            gameStateManager.Update(gameTime);
            Globals.GameObjectManager.deleteObjects();

            //SkeletonObj.Update();
            //OktorokObj.Update();
            //BokoblinObj.Update();
            //DragonObj.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(transformMatrix: Globals.Camera.Transform);
            gameStateManager.Draw(spriteBatch);
            base.Draw(gameTime);
            spriteBatch.End();
        }
    }
}
