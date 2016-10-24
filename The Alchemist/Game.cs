using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace The_Alchemist
{
    enum GameState
    {
        StartMenu,
        Loading,
        Playing,
        Paused
    }

    //This class handles the game loop. It calls on other classes to create the Game.
    public class AlchemistGame : Microsoft.Xna.Framework.Game
    {
        public GraphicsDeviceManager graphics;                     //Gets info from the display device the game is running on
        SpriteBatch spriteBatch;                            //Draws textures for game (platforms, character, etc)  
        public Vector2 gameResolution = new Vector2(1024, 576);    //Game resolution 1024x576
        private Matrix resolutionScaling;                   //Will be used to scale objects when game goes full screen
        private KeyboardState keyboardState;                //Variable to save the keyboard state once per frame for movement
        private MouseState mouseState;
        private MouseState previousMouseState;

        private int currentLevel = 1;                       //Will be increased as levels are completed
        private Level level;                                //Instance of the level class that will determine the kind of level

        private SpriteFont font;
        private SpriteFont fontLarge;

        private Texture2D menuBackground;
        private Rectangle menu;
        private Rectangle startButton;
        private Rectangle loadButton;
        private Rectangle exitButton;
        private Vector2 startButtonPosition;
        private Vector2 titlePosition;

        private Texture2D deathOverlay;                     //Displayed when player dies

        private GameState gameState;
        private bool loadGame;
        private bool ded = false;

        public AlchemistGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";              //Directory of our images/sounds

            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferHeight = 576;
            graphics.PreferredBackBufferWidth = 1024;
        }

        //Load services and non-graphic content
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            keyboardState = Keyboard.GetState();
            mouseState = Mouse.GetState();
            
            IsMouseVisible = true;
            gameState = GameState.StartMenu;

            base.Initialize();  //Initializes related components
        }

        //Loads all the content we want for the game class
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //Load the menu
            menuBackground = Content.Load<Texture2D>("Backgrounds/Menu");

            // Load font
            font = Content.Load<SpriteFont>("Font/Papyrus");
            fontLarge = Content.Load<SpriteFont>("Font/Papyrus Large");

            //Create Positions
            startButtonPosition = new Vector2(GraphicsDevice.Viewport.Width / 2 - 130, 450);
            titlePosition = new Vector2(GraphicsDevice.Viewport.Width / 2 - 180, 70);

            //Create Rectangles
            menu = new Rectangle(0, 0, 1024, 576);
            startButton = new Rectangle((int)startButtonPosition.X, (int)startButtonPosition.Y, 260, 60);

            //deathOverlay = Content.Load<Texture2D>("Overlays/you_died");

            //This works out how much everything needs to be scaled when we go full screen
            float horizontalScale = GraphicsDevice.PresentationParameters.BackBufferWidth / gameResolution.X;
            float verticalScale = GraphicsDevice.PresentationParameters.BackBufferHeight / gameResolution.Y;
            Vector3 resolutionScaleFactor = new Vector3(horizontalScale, verticalScale, 1);
            resolutionScaling = Matrix.CreateScale(resolutionScaleFactor);          
        }

        private void LoadLevel()
        {
            //Increase level counter to begin the next level 
            currentLevel++;

            //Clears content used by the current level.
            if (level != null)
                level.Dispose();

            //Loads the new level.
            level = new Level(Services, graphics, currentLevel);
        }


        //---------------------------------------------------------------------------------

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            keyboardState = Keyboard.GetState();
            mouseState = Mouse.GetState();

            //create a rectangle around the place where the mouse was clicked
            Rectangle click = new Rectangle(mouseState.X,mouseState.Y,10,10);

            //check the start menu
            if (previousMouseState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released)
            {
                if (gameState == GameState.StartMenu)
                {
                    if (click.Intersects(startButton))
                    {
                        gameState = GameState.Playing;
                        loadGame = true;
                        IsMouseVisible = false;
                        ded = false;
                    }
                }
            }

            previousMouseState = mouseState;

            if (gameState == GameState.Playing && loadGame)
            {
                LoadLevel();  
                loadGame = false;
            }
            
            if (gameState == GameState.Playing && !loadGame)
            {
                level.Update(gameTime, keyboardState);
                
                if (level.GameOver)
                {
                    gameState = GameState.StartMenu;
                    IsMouseVisible = true;
                    ded = true;                    
                }
            }

            

            // TODO: Add your update logic here
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null, resolutionScaling);            
            
            if(gameState == GameState.StartMenu)
            {
                spriteBatch.Draw(menuBackground, menu, Color.White);
                spriteBatch.DrawString(font, "Begin Quest", startButtonPosition, Color.DimGray);
                spriteBatch.DrawString(fontLarge, "The Alchemist", titlePosition, Color.Gray);
            }

            else if (gameState == GameState.Playing)
            {
                level.Draw(gameTime, spriteBatch); 
            }      
    
            if (ded)
            {
                spriteBatch.DrawString(fontLarge, "Lol u ded! #noob", new Vector2(320, 0), Color.WhiteSmoke);
            }
                      
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
