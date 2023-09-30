using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0.Items.groundItems;
using System.Runtime.CompilerServices;

namespace sprint0
{
    public class Sprint0 : Game
    {
        
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        //ATTENTION: Additional Sprites added for demonstration
        public ISprite FacingUpLink;
        public ISprite FacingDownLink;
        public ISprite FacingLeftLink;
        public ISprite FacingRightLink;
        public ISprite AttackingUpLink;
        public ISprite AttackingDownLink;
        public ISprite AttackingLeftLink;
        public ISprite AttackingRightLink;

        public int xLoc = 400;
        public int yLoc = 200;
        Texture2D texture;
        IGroundItemSystem groundItems;
       
        
        //Concrete Commands
      
        IController KeyboardCont;
       

        //Textbox variables
        public SpriteFont font;
        ISprite TextBox;
        public Sprint0()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            KeyboardCont = new KeyboardController();
            
            
        }

        protected override void Initialize()
        {
          
            //Moved here in order to have values initialized before key mapping
            spriteBatch = new SpriteBatch(GraphicsDevice);
            texture = Content.Load<Texture2D>("luigiSpriteSheet");
           
            //ATTENTION: MouseController.cs exists, although it is never used due to the interface needing keys and Monogame lacking Keys.LButton and Keys.RButton
           
            KeyboardCont.registerKey(Keys.D0, new QuitCommand(this));

            
            /*MULTIPLE SPRITES FOR DEMONSTRATION - TO BE REMOVED*/
            //Creates Link's default state
            FacingUpLink = new FacingUpLinkState(texture, 7, 14);
            FacingDownLink = new FacingDownLinkState(texture, 7, 14);
            FacingLeftLink = new FacingLeftLinkState(texture, 7, 14);
            FacingRightLink = new FacingRightLinkState(texture, 7, 14);
            AttackingUpLink = new AttackUpLinkState(texture, 7, 14);
            AttackingDownLink = new AttackDownLinkState(texture, 7, 14);
            AttackingRightLink = new AttackRightLinkState(texture, 7, 14);
            AttackingLeftLink = new  AttackLeftLinkState(texture, 7, 14);

            //BAD CODE POTENTIAL: This can probably be shunted to a class function
            //These keys successfully bind to something, as there is no error message when pressed
            KeyboardCont.registerKey(Keys.D1, new FixedSingleCommand(this, texture));
            KeyboardCont.registerKey(Keys.D2, new FixedAnimatedCommand(this, texture));
            KeyboardCont.registerKey(Keys.D3, new UpAndDownCommand(this, texture));
            KeyboardCont.registerKey(Keys.D4, new MovingAnimatedCommand(this, texture));
            base.Initialize();
        }
      
        protected override void LoadContent()
        {
            //Iniitializes the textbox
            //POSSIBLE BAD CODE: Not sure if these should be in here or Initialize
            font = Content.Load<SpriteFont>("Font");

            TextBox = new TextSprite(font);

            //GROUND ITEM SYSTEM STUFF
            groundItems = new GroundItemSystem(spriteBatch, 200, 200);
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
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
           
            KeyboardCont.Update();

            
            groundItems.Update();
            //Additional Update() added for testing
            FacingUpLink.Update();
            FacingDownLink.Update();
            FacingLeftLink.Update();
            FacingRightLink.Update();
            AttackingUpLink.Update();
            AttackingDownLink.Update();
            AttackingRightLink.Update();
            AttackingLeftLink.Update();

            base.Update(gameTime);
            
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);


            /*MULTIPLE SPRITES FOR DEMONSTRATION - TO BE REMOVED*/
            //Draws Luigi
            FacingUpLink.Draw(spriteBatch,0,100);
            FacingDownLink.Draw(spriteBatch, 50, 100);
            FacingLeftLink.Draw(spriteBatch, 100, 100);
            FacingRightLink.Draw(spriteBatch, 150, 100);
            AttackingUpLink.Draw(spriteBatch, 200, 100);
            AttackingDownLink.Draw(spriteBatch, 250, 100);
            AttackingLeftLink.Draw(spriteBatch, 300, 100);
            AttackingRightLink.Draw(spriteBatch, 350, 100);

            //Draws the Textbox
            TextBox.Draw(spriteBatch, 100, 300);
            groundItems.Draw();
            base.Draw(gameTime);
        }

        public void SetSprite(ISprite NewSpriteType)
        {
            FacingLeftLink = NewSpriteType;
            
        }
    }
}