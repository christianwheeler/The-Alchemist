using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using System.IO;
using Microsoft.Xna.Framework.Input;

namespace The_Alchemist
{
    class Level : IDisposable
    {
        private int levelIndex = 1;                                 //Current level
        private int part = 0;                                       //Current part of level
        private Texture2D background;                               //Level background
        
        private Platform [,] platforms = new Platform[3,12];        //Platforms in level part
        private int[] numberOfPlatforms = new int[3];               //Number of platforms in each part
        
        private Enemy [,] enemies = new Enemy[3,7];                 //Enemies in level part
        private int[] numberOfEnemies = new int[3];                 //Number of enemies in each part

        private Rectangle[] exits = new Rectangle[3];               //Exit for each part

        private bool gameOver = false;

        

        private Player player;
        private OldMan oldman;
        private Texture2D om;
        //Player in level
        //private Vector2 playerStart;                                //Player start position
        //private Point playerExit;                                   //Player exit position
        //private bool exitReached;                                   //Flags the player's exit
        private ContentManager content;                             //Loads level content

        public int gameHeight;
        public int gameWidth;
        
        public int Index
        {
            get { return levelIndex; }
        }

        public int Part
        {
            get { return part; }
        }

        public int [] NumberOfPlatforms
        {
            get { return numberOfPlatforms; }
        }

        public Platform [,] Platforms
        {
            get { return platforms; }
        }

        public int[] NumberOfEnemies
        {
            get { return numberOfEnemies; }
        }

        public Enemy [,] Enemies
        {
            get { return enemies; }
        }

        public Rectangle [] Exits
        {
            get { return exits; }
        }

        public bool ExitReached
        {
            get { return false; }//exitReached; }
        }

        public ContentManager Content
        {
            get { return content; }
        }

        public bool GameOver
        {
            get { return gameOver; }
        }

        public Level(IServiceProvider serviceProvider, GraphicsDeviceManager gfx, int levelIndex)
        {
            // Create a new content manager to load content used just by this level.
            content = new ContentManager(serviceProvider, "Content");
            //index = levelIndex;

            gameHeight = gfx.GraphicsDevice.Viewport.Height;
            gameWidth = gfx.GraphicsDevice.Viewport.Width;

            LoadPlatforms();
            LoadEnemies();
            //LoadPlayer();
            player = new Player(340, gameHeight - 530, this, serviceProvider, gfx);
        }

        public void LoadPlatforms()
        {
            //Load the appropriate background
            switch (levelIndex)
            {
                case 1 :
                    {
                        if (part == 0)
                            background = Content.Load<Texture2D>("Backgrounds/bgLevel1Part1");
                        else if (part == 1)
                            background = Content.Load<Texture2D>("Backgrounds/bgLevel1Part2");
                        else if (part == 2)
                            background = Content.Load<Texture2D>("Backgrounds/bgLevel1Part3");
                    }
                    break;
                case 2:
                    {
                        if (part == 0)
                            background = Content.Load<Texture2D>("Backgrounds/bgLevel2Part1");
                        else if (part == 1)
                            background = Content.Load<Texture2D>("Backgrounds/bgLevel2Part2");
                        else if (part == 2)
                            background = Content.Load<Texture2D>("Backgrounds/bgLevel2Part3");
                    }                 
                    break;
                case 3:
                    {
                        if (part == 0)
                            background = Content.Load<Texture2D>("Backgrounds/bgLevel1Part1");
                        else if (part == 1)
                            background = Content.Load<Texture2D>("Backgrounds/bgLevel1Part2");
                        else if (part == 2)
                            background = Content.Load<Texture2D>("Backgrounds/bgLevel1Part3");
                    }
                    break;
            }

            //Load the appropriate platforms
            if (levelIndex == 1)
            {
                Texture2D small = Content.Load<Texture2D>("Platforms/intro_ground_small");
                Texture2D smallBroken = Content.Load<Texture2D>("Platforms/intro_ground_small_broken");
                Texture2D normal = Content.Load<Texture2D>("Platforms/intro_ground");
                Texture2D normalBroken = Content.Load<Texture2D>("Platforms/intro_ground_broken");

                // texture: can be one of the above (small, normal, smallBroken, normalBroken)
                // type: either 0 or 1, check Platform.cs PlatformCollision enum
                // x: horizontal position on the screen
                // y: vertical position on the screen

                //Initializes the platforms for part 0
                numberOfPlatforms[0] = 4;
                platforms[0, 0] = new Platform(normal, Collides.All, Size.Large, 200, gameHeight - 170);
                platforms[0, 1] = new Platform(small, Collides.All, Size.Small, 500, gameHeight - 330);
                platforms[0, 2] = new Platform(normal, Collides.All, Size.Large, 700, gameHeight - 500);
                platforms[0, 3] = new Platform(normal, Collides.All, Size.Large, 720, gameHeight - 150);



                exits[0] = new Rectangle(760, gameHeight - 500 - 50, 50, 50);
                
                numberOfPlatforms[1] = 7;
                platforms[1, 0] = new Platform(small, Collides.All, Size.Small, 50, gameHeight - 50);
                platforms[1, 1] = new Platform(normalBroken, Collides.Top, Size.Large, 500, gameHeight - 200);
                platforms[1, 2] = new Platform(smallBroken, Collides.Top, Size.Small, 450, gameHeight - 270);
                platforms[1, 3] = new Platform(small, Collides.All, Size.Small, 870, gameHeight - 370);
                platforms[1, 4] = new Platform(normalBroken, Collides.Top, Size.Large, 300, gameHeight - 470);
                platforms[1, 5] = new Platform(normal, Collides.All, Size.Large, 0, gameHeight - 450);
                platforms[1, 6] = new Platform(normal, Collides.All, Size.Large, 800, gameHeight - 50);

                exits[1] = new Rectangle(935, gameHeight - 370 - 50, 50, 50);
                
                numberOfPlatforms[2] = 7;
                platforms[2, 0] = new Platform(small, Collides.All, Size.Small, 400, gameHeight - 50);
                platforms[2, 1] = new Platform(normalBroken, Collides.Top, Size.Large, 0, gameHeight - 180);
                platforms[2, 2] = new Platform(small, Collides.All, Size.Small, 200, gameHeight - 420);
                platforms[2, 3] = new Platform(normal, Collides.All, Size.Large, 450, gameHeight - 500);
                platforms[2, 4] = new Platform(smallBroken, Collides.All, Size.Small, 800, gameHeight - 400);
                platforms[2, 5] = new Platform(normal, Collides.All, Size.Large, 800, gameHeight - 250);
                platforms[2, 6] = new Platform(smallBroken, Collides.Top, Size.Small, 0, gameHeight - 380);

                exits[2] = new Rectangle(850, gameHeight - 400 - 50, 50, 50);

                  
            }

            if (levelIndex == 2)
            {
                Texture2D small = Content.Load<Texture2D>("Platforms/nigredo_ground_small");
                Texture2D smallBroken = Content.Load<Texture2D>("Platforms/nigredo_ground_small_broken");
                Texture2D normal = Content.Load<Texture2D>("Platforms/nigredo_ground");
                Texture2D normalBroken = Content.Load<Texture2D>("Platforms/nigredo_ground_broken");

                numberOfPlatforms[0] = 6;
                platforms[0, 0] = new Platform(normal, Collides.All, Size.Large, 200, gameHeight - 100);
                platforms[0, 1] = new Platform(normal, Collides.All, Size.Large, 800, gameHeight - 250);
                platforms[0, 2] = new Platform(small, Collides.All, Size.Small, 550, gameHeight - 200);
                platforms[0, 3] = new Platform(smallBroken, Collides.Top, Size.Small, 400, gameHeight - 450);
                platforms[0, 4] = new Platform(smallBroken, Collides.Top, Size.Small, 950, gameHeight - 400);
                platforms[0, 5] = new Platform(small, Collides.All, Size.Small, 650, gameHeight - 450);

                exits[0] = new Rectangle(430, gameHeight - 450 - 46, 50, 50);

                //--------------NEW WAY OF CREATING PLATFORMS ------------------------------------------------------------------
                // if you choose a small texture make the size small (this is crucial for correct collision)
                // otherwise make the size large
                // if you choose a broken texture make the collision Top (also very important)
                // otherwise make the collision all

                // Keep this in mind when you're designing the layout. Our player will be able to jump 
                // through the bottom of broken platforms to get onto them, but will only be able to 
                // get onto normal platforms by coming from the top.

                //You'll also notice that the 800 has been replaced with gameHeight. This enables us to later
                //change the resolution if we'd like. For now, when designing, take note that the resolution
                //is 1024x576 - IN OTHER WORDS: if a platform is created higher than 576, it won't be seen
                //and if a platform is created wider than 1024 it won't be seen. (Cause they'll be off screen)
//--------------------------------------------------------------------------------------------------------------

                numberOfPlatforms[1] = 6;      //   texture, Collision   , Size      , X, Y   
                platforms[1, 0] = new Platform(normalBroken, Collides.Top, Size.Large, 0, gameHeight - 70);
                platforms[1, 1] = new Platform(smallBroken, Collides.Top, Size.Small, 30, gameHeight - 220);
                platforms[1, 2] = new Platform(normal, Collides.All, Size.Large, 320, gameHeight - 200);
                //platforms[1, 3] = new Platform(small, Collides.All, Size.Small, 600, gameHeight - 400);
                platforms[1, 3] = new Platform(normalBroken, Collides.Top, Size.Large, 500, gameHeight - 400);
                //platforms[1, 4] = new Platform(small, Collides.All, Size.Small, 600, gameHeight - 300);
                platforms[1, 4] = new Platform(normalBroken, Collides.Top, Size.Large, 200, gameHeight - 450);
                platforms[1, 5] = new Platform(smallBroken, Collides.Top, Size.Small, 850, gameHeight - 470);

                exits[1] = new Rectangle(880, gameHeight - 470 - 50, 50, 50);
                
            //    numberOfPlatforms[2] = 7;
            //    platforms[2, 0] = new Platform(small, Collides.All, Size.Small, 0, gameHeight - 50);
            //    platforms[2, 1] = new Platform(smallBroken, Collides.Top, Size.Small, 0, gameHeight - 250);
            //    platforms[2, 2] = new Platform(smallBroken, Collides.Top, Size.Small, 0, gameHeight - 450);
            //    platforms[2, 3] = new Platform(normal, Collides.All, Size.Large, 160, gameHeight - 350);
            //    //platforms[2, 4] = new Platform(normal, Collides.All, Size.Large, 400, gameHeight - 250);
            //    platforms[2, 4] = new Platform(normal, Collides.All, Size.Large, 600, gameHeight - 150);
            //  //  platforms[2, 6] = new Platform(normalBroken, Collides.Top, Size.Large, 1000, gameHeight - 250);
            ////    platforms[2, 7] = new Platform(smallBroken, Collides.Top, Size.Small, 1000, gameHeight - 450);
            //   // platforms[2, 8] = new Platform(small, Collides.All, Size.Small, 950, gameHeight - 600);
            //    platforms[2, 5] = new Platform(small, Collides.All, Size.Small, 520, gameHeight - 360);
            //    platforms[2, 6] = new Platform(normal, Collides.All, Size.Large, 800, gameHeight - 400);

            //    exits[2] = new Rectangle(15, gameHeight - 50 - 50, 50, 50);
                
            }

            if (levelIndex == 3)
            {
                Texture2D small = Content.Load<Texture2D>("Platforms/nigredo_ground_small");
                Texture2D smallBroken = Content.Load<Texture2D>("Platforms/nigredo_ground_small_broken");
                Texture2D normal = Content.Load<Texture2D>("Platforms/nigredo_ground");
                Texture2D normalBroken = Content.Load<Texture2D>("Platforms/nigredo_ground_broken");

                numberOfPlatforms[0] = 10;
                platforms[0, 0] = new Platform(small, Collides.All, Size.Small, 20, gameHeight - 50);
                platforms[0, 1] = new Platform(normal, Collides.All, Size.Large, 200, gameHeight - 50);
                platforms[0, 2] = new Platform(small, Collides.All, Size.Small, 400, gameHeight - 120);
                platforms[0, 3] = new Platform(normal, Collides.Top, Size.Large, 200, gameHeight - 250);
                platforms[0, 4] = new Platform(normalBroken, Collides.Top, Size.Large, 700, gameHeight - 350);
                platforms[0, 5] = new Platform(normalBroken, Collides.All, Size.Large, 530, gameHeight - 450);
                platforms[0, 6] = new Platform(smallBroken, Collides.All, Size.Small, 400, gameHeight - 450);
                platforms[0, 7] = new Platform(small, Collides.All, Size.Small, 900, gameHeight - 50);
                platforms[0, 8] = new Platform(smallBroken, Collides.Top, Size.Small, 20, gameHeight - 350);
                platforms[0, 9] = new Platform(smallBroken, Collides.Top, Size.Small, 200, gameHeight - 450);

                exits[0] = new Rectangle(900, gameHeight - 50 - 50, 50, 50);

                numberOfPlatforms[1] = 9;      //   texture, Collision   , Size      , X, Y   
                platforms[1, 0] = new Platform(normal, Collides.Top, Size.Large, 200, gameHeight - 50);
                platforms[1, 1] = new Platform(normalBroken, Collides.Top, Size.Large, 640, gameHeight - 420);
                platforms[1, 2] = new Platform(smallBroken, Collides.All, Size.Small, 50, gameHeight - 250);
                platforms[1, 3] = new Platform(normal, Collides.Top, Size.Large, 220, gameHeight - 430);
                platforms[1, 4] = new Platform(smallBroken, Collides.Top, Size.Small, 550, gameHeight - 300);
                platforms[1, 5] = new Platform(normal, Collides.Top, Size.Large, 400, gameHeight - 300);
                platforms[1, 6] = new Platform(normalBroken, Collides.Top, Size.Large, 600, gameHeight - 50);
                platforms[1, 7] = new Platform(small, Collides.Top, Size.Small, 750, gameHeight - 150);
                platforms[1, 8] = new Platform(small, Collides.All, Size.Small, 900, gameHeight - 50);

                exits[1] = new Rectangle(60, gameHeight - 250 - 46, 50, 50);

                //numberOfPlatforms[2] = 7;
                //platforms[2, 0] = new Platform(small, Collides.All, Size.Small, 0, gameHeight - 50);
                //platforms[2, 1] = new Platform(smallBroken, Collides.Top, Size.Small, 0, gameHeight - 250);
                //platforms[2, 2] = new Platform(smallBroken, Collides.Top, Size.Small, 0, gameHeight - 450);
                //platforms[2, 3] = new Platform(normal, Collides.All, Size.Large, 160, gameHeight - 350);
                //platforms[2, 4] = new Platform(normal, Collides.All, Size.Large, 600, gameHeight - 150);
                //platforms[2, 5] = new Platform(small, Collides.All, Size.Small, 520, gameHeight - 360);
                //platforms[2, 6] = new Platform(normal, Collides.All, Size.Large, 800, gameHeight - 400);

                //exits[2] = new Rectangle(15, gameHeight - 50 - 50, 50, 50);

            }
        }

        public void LoadEnemies()
        {
            if (levelIndex == 1)
            {
                om = Content.Load<Texture2D>("Player/Old Man");

             //   numberOfEnemies[1] = 1;
               oldman = new OldMan(om, 720, gameHeight - 150 - 147, content);

            }
            
            if (levelIndex == 2)
            {
                Texture2D shadow = Content.Load<Texture2D>("Enemies/shadow");
                //Texture2D smallBroken = Content.Load<Texture2D>("Platforms/nigredo_ground_small_broken");

                //numberOfEnemies[0] = 1;
                //enemies[0, 0] = new Enemy(shadow, EnemyType.Shadow, 800 + 190, 800 - 150 + 94, "long");

                //The enemies work more or less the same as the platforms in terms of creation. When you 
                //create an enemy, create it according to a platform (in terms of x, y and size)

                //we only have the shadow type right now, so make all the enemies shadows please

                numberOfEnemies[1] = 1;//texture, type is shadow  , X   , Y                , Size of the platform its on (important for movement) 
                enemies[1, 0] = new Enemy(shadow, EnemyType.Shadow, 0 , gameHeight - 70 , Size.Large);
                //enemies[1, 1] = new Enemy(shadow, EnemyType.Shadow, 550 , gameHeight - 400 , Size.Small);

                //numberOfEnemies[2] = 2;
                //enemies[2, 0] = new Enemy(shadow, EnemyType.Shadow, 320, gameHeight - 200, Size.Large);
                //enemies[2, 1] = new Enemy(shadow, EnemyType.Shadow, 550, gameHeight - 400, Size.Small);
            }
        }

       /* public void LoadPlayer()
        {
            Texture2D idle = Content.Load<Texture2D>("Player/Alchemist Lead Idle");
            Texture2D jump = Content.Load<Texture2D>("Player/Alchemist Lead Jump");
            Texture2D run = Content.Load<Texture2D>("Player/Alchemist Lead Sheet");
            
            //Player creation is super simple for now. We just pass the textures it needs
            //pass the position coordinates and pass the level so that the player can access
            //its platforms to check collisions. So just change the X and Y of the player as
            //necessary for the levels you design

            if (levelIndex == 1)
            {
                switch (part)
                {                               // textures    , X  , Y               , level  
                    case 0: player = new Player(run, idle, jump, 340, gameHeight - 230, this);
                        break;
                    case 1: player = new Player(run, idle, jump, 340, gameHeight - 200, this);
                        break;
                    case 2: player = new Player(run, idle, jump, 340, gameHeight - 200, this);
                        break;
                }
            }

            if (levelIndex == 2)
            {
                switch (part)
                {
                    case 0: player = new Player(run, idle, jump, 340, gameHeight - 230 , this);
                        break;
                    case 1: player = new Player(run, idle, jump, 340, gameHeight - 200, this);
                        break;
                   // case 2: player = new Player(run, idle, jump, 340, gameHeight - 200, this);
                    //    break;
                }
            }

            if (levelIndex == 3)
            {
                switch (part)
                {
                    case 0:
                        player = new Player(run, idle, jump, 340, gameHeight - 230, this);
                        break;
                    case 1:
                        player = new Player(run, idle, jump, 340, gameHeight - 200, this);
                        break;
                        // case 2: player = new Player(run, idle, jump, 340, gameHeight - 200, this);
                        //    break;
                }
            }

        }*/

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, new Rectangle(0,0,1024,576), Color.White);
            
            for (int i = 0; i < numberOfPlatforms[part]; i++)
            {
                platforms[part, i].Draw(spriteBatch);      
            }
            if (levelIndex == 1 && part == 0)
            {
                oldman.Draw(gameTime, spriteBatch);
            }
            for (int k = 0; k < numberOfEnemies[part]; k++)
            {
                enemies[part, k].Draw(gameTime, spriteBatch);
            }

            Texture2D exit = Content.Load<Texture2D>("Platforms/Exit Light");
            spriteBatch.Draw(exit, exits[part], Color.White);

            player.Draw(gameTime, spriteBatch);
        }

        float exitWait = 0.0f;

        private void ExitWait(GameTime gameTime)
        {
            if (exitWait != 0)
                exitWait -= (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public void Update(GameTime gameTime, KeyboardState keyboardState)
        {
            ExitWait(gameTime);

            for (int k = 0; k < numberOfEnemies[part]; k++)
            {
                enemies[part, k].Update(gameTime);
            }

            player.Update(gameTime, keyboardState);
            if (levelIndex == 1)
                oldman.Update(gameTime);

            if (player.ExitReached(gameTime))
            {
                if (exitWait == 0.0f)
                    exitWait = 0.7f;
            }

            if (player.DiedByFalling())
            {
                gameOver = true;
            }

            if (exitWait < 0.0f)
            {
                exitWait = 0.0f;
            //provides the level and part counters
                if (levelIndex == 1)
                {
                    if (part + 1 == 3)
                    {
                        part = 0;
                        levelIndex++;

                        Dispose();
                        LoadPlatforms();
                        LoadEnemies();
                        //LoadPlayer();
                    }
                    else
                        part++;

                }
                else {

                    if (part + 1 == 2)
                    {
                        part = 0;
                        levelIndex++;

                        Dispose();
                        LoadPlatforms();
                        LoadEnemies();
                        //LoadPlayer();
                    }
                    else
                        part++;
                }
            }
        }

        public void Dispose()
        {
            Content.Unload();
        }



    }
}

