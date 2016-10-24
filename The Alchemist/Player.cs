using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TexturePackerLoader;
using Microsoft.Xna.Framework.Content;
using WMPLib;

namespace The_Alchemist
{
    class Player
    {
        private int x;                                      //Player X Coordinate
        private int y;                                      //Player Y Coordinate
        private Vector2 position;                           //Player Position
        private int width;                                  //Player Image Width
        private int height;                                 //Player Image Height
        private Rectangle bounds;                           //Player Bounds
               
        private Level level;                                //Level the player is on
     
        private bool jumping;                               //Indicates if player is jumping 
        private bool jumped;                                //Indicates if player finished jumping
        private float jumpTime;                             //Times the duration of a jump
        private float descentTime;                          //Times the fall duration                          
        private const float jumpTimeEnd = 0.35f;            //Time the jump has to end at
        private const float jumpVelocity = -8500.0f;        //Velocity a jump starts with
        private const float gravity = 3400.0f;              //Acceleration of vertical movement
        private const float maxSpeedY = 550.0f;             //Maximum vertical movement speed
        private const float jumpControl = 0.6f;             //Allows jump to override downward velocity

        private float movement;                             //Indicates if player is moving horizontally
        private const float acceleration = 12000.0f;        //Acceleration of horizontal movement
        private const float maxSpeedX = 1850.0f;            //Maximum horizontal movement speed
        private const float groundFriction = 0.48f;         //Friction to make walking realistic
        private const float airFriction = 0.58f;            //Friction to make jumping realistic

        private bool onGround;                              //Flag to check if Player is on ground
        private bool isAlive;                               //Flag to check if Player is alive
        private Vector2 velocity;                           //Velocity when player moves
        float floor;                                        //Current floor position 

        //I'm adding in some comments here, to test GitHub commits/pushing 

        //---------------------------- NEW ANIMA -------------------------------//
        private ContentManager content;
        private GraphicsDeviceManager graphics;
        private AnimatorManager characterAnimator;

        private SpriteBatch idleSpriteBatch;
        private SpriteSheet idleSpriteSheet;
        private SpriteRender idleSpriteRender;
        private SpriteSheetLoader idleSpriteLoader;
        private Animator idleAnimation;
        private readonly TimeSpan idleTime = TimeSpan.FromSeconds(1f / 27f);
    
        Texture2D square;

        private SpriteBatch runSpriteBatch;
        private SpriteSheet runSpriteSheet;
        private SpriteRender runSpriteRender;
        private SpriteSheetLoader runSpriteLoader;
        private Animator runAnimation;
        private readonly TimeSpan runTime = TimeSpan.FromSeconds(1f / 65f);

        private SpriteBatch jumpSpriteBatch;
        private SpriteSheet jumpSpriteSheet;
        private SpriteRender jumpSpriteRender;
        private SpriteSheetLoader jumpSpriteLoader;
        private Animator jumpAnimation;
        private readonly TimeSpan jumpTim = TimeSpan.FromSeconds(1f / 15f);
        WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();

        public Player(int xC, int yC, Level l, IServiceProvider service, GraphicsDeviceManager g)
        {
            content = new ContentManager(service, "Content");
            graphics = g;

            x = xC;
            y = yC;
            position = new Vector2(x, y);

            width = Convert.ToInt16(246 * 0.33f);
            height = Convert.ToInt16(545 * 0.33f);
            bounds = new Rectangle(x, y, width, height);

            level = l;
          
            square = new Texture2D(graphics.GraphicsDevice, width, height);
            square.CreateBorder(5, Color.Red);

            this.idleSpriteBatch = new SpriteBatch(graphics.GraphicsDevice);
            this.idleSpriteRender = new SpriteRender(this.idleSpriteBatch);
            this.idleSpriteLoader = new SpriteSheetLoader(content);
            this.idleSpriteSheet = idleSpriteLoader.Load("Player/air_idle");

            var idleSprite = TextureDefinitions.air_idle.sprite;
            this.idleAnimation = new Animator(new Vector2(0, 0), idleTime, SpriteEffects.None, idleSprite);

            this.runSpriteBatch = new SpriteBatch(graphics.GraphicsDevice);
            this.runSpriteRender = new SpriteRender(this.runSpriteBatch);
            this.runSpriteLoader = new SpriteSheetLoader(content);
            this.runSpriteSheet = runSpriteLoader.Load("Player/air_run");

            var runSprite = TextureDefinitions.air_run.sprite;
            this.runAnimation = new Animator(new Vector2(0, 0), runTime, SpriteEffects.None, runSprite);

            this.jumpSpriteBatch = new SpriteBatch(graphics.GraphicsDevice);
            this.jumpSpriteRender = new SpriteRender(this.jumpSpriteBatch);
            this.jumpSpriteLoader = new SpriteSheetLoader(content);
            this.jumpSpriteSheet = jumpSpriteLoader.Load("Player/air_jump");

            var jumpSprite = TextureDefinitions.air_jump.sprite;
            this.jumpAnimation = new Animator(new Vector2(0, 0), jumpTim, SpriteEffects.None, jumpSprite);

            this.characterAnimator = new AnimatorManager(idleSpriteSheet, position, idleAnimation); ;

            wplayer.URL = "jump.wav";
        }

        //Calculates and returns the player's current bounds for collision purposes
        public Rectangle Bounds
        {
            get { return new Rectangle((int) Math.Round(position.X), (int) Math.Round(position.Y) - height, width, height); }
        }

        //Returns if player is on the ground
        public bool OnGround
        {
            get { return onGround; }
        }

        //Decrease the descentTime according to the game's time mechanism
        private void Descend(GameTime gameTime)
        {
            descentTime -= (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        //Only allows a jump once player has descended completely from it
        private bool JumpAllowed()
        {
            if (descentTime <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Sets the players position, this is used when hmmm?
        public void setPosition(int xC, int yC, Level l)
        {
            x = xC;
            y = yC;
            position = new Vector2(x, y);
            level = l;
        }

        //Returns the player's living status
        public bool IsAlive
        {
            get { return isAlive; }
        }

        //This function is called each frame and updates the player as necessary
        public void Update(GameTime gameTime, KeyboardState keyboardState)
        {
            this.characterAnimator.Update(gameTime);
            processInput(keyboardState, gameTime);
            jumping = false;
            movement = 0.0f;           
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //Set the player direction according to the side the player is moving towards
            if (velocity.X > 0)
            {
                characterAnimator.CurrentSpriteEffects = SpriteEffects.None;
            }
            else if (velocity.X < 0)
            {
                characterAnimator.CurrentSpriteEffects = SpriteEffects.FlipHorizontally;
            }

            //Draw the currently set player animation
            //animation.Draw(gameTime, spriteBatch, position, direction);

            this.idleSpriteBatch.Begin();
            // Draw character on screen

            spriteBatch.Draw(square, Bounds, Color.White);
            Vector2 newPos = new Vector2(position.X + width / 2, position.Y - height / 2);

            this.idleSpriteRender.Draw(
                this.characterAnimator.CurrentSprite,
                newPos,
                Color.White, 0, 0.33f,
                this.characterAnimator.CurrentSpriteEffects);
            this.idleSpriteBatch.End();
        }

        //Gets input from the keyboard and updates the player as necessary
        private void processInput(KeyboardState keyboardState, GameTime gameTime)
        {
            //If the up button is pressed and jump is allowed and the player is on the floor
            if (keyboardState.IsKeyDown(Keys.Up) && JumpAllowed() && position.Y >= floor)
            {
                descentTime = 0.6f;     //Start the descent timer
                jumping = true;         //Indicate that the player is jumping
            }
            else if (keyboardState.IsKeyDown(Keys.Right))
            {
                movement = 1.0f;        //Indicate that the player is moving right
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                movement = -1.0f;       //Indicate that the player is moving left
            }

            //If the player is currently in a jump/descent decrease the descentTime
            if (!JumpAllowed())         
                Descend(gameTime);

            //Elapsed game time
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            //Work out vertical velocity                 
            velocity.Y = MathHelper.Clamp(velocity.Y + gravity * elapsed, -maxSpeedY, maxSpeedY);       
            //Call the jump function so jumps can influence current velocity
            velocity.Y = Jump(velocity.Y, gameTime);

            //Detect any possible collisions                          
            Collide();
            //floor = level.gameHeight - 200;

            //Apply friction to the velocity
            if (OnGround)
                velocity.X *= groundFriction;
            else
                velocity.X *= airFriction;

            //Work out horizontal velocity     
            velocity.X = MathHelper.Clamp(velocity.X, -maxSpeedX, maxSpeedX);

            //Apply the velocity
            velocity.X += movement * acceleration * elapsed;
            
            //If player is on the floor and not jumping, set his animation accordingly
            if (position.Y >= floor && !jumping)
            {
                //If the absolute value of the current horizontal velocity isn't 0, 
                //set the animation to running
                if (Math.Abs(velocity.X) - 0.02f > 0)
                {
                    this.characterAnimator.animation = runAnimation;
                    this.characterAnimator.spriteSheet = runSpriteSheet;
                }
                //Otherwise set it to idle
                else
                {
                    this.characterAnimator.animation = idleAnimation;
                    this.characterAnimator.spriteSheet = idleSpriteSheet;
                    //animation = idleAnimation;
                    //animation.Play();
                }
                onGround = true;             //Indicate it
                velocity.Y = 0.0f;
            }
            else
                onGround = false;

            //Apply velocity.
            position += velocity * elapsed;

            //Round the velocity so bounds can be correctly updated
            position = new Vector2((float)Math.Round(position.X), (float)Math.Round(position.Y));
        }

        private float Jump(float velocityY, GameTime gameTime)
        {
            //If the player is currently jumping
            if (jumping)
            {
                //If the jump hasn't ended yet
                if ((!jumped && OnGround) || jumpTime > 0.0f)
                {
                    jumpTime += (float)gameTime.ElapsedGameTime.TotalSeconds;   //Increase the jump time

                    this.characterAnimator.animation = jumpAnimation;
                    this.characterAnimator.spriteSheet = jumpSpriteSheet;
                    //animation = jumpAnimation;          //Set the current animation to jumping      
                    //animation.Play();                   //Play the newly selected animation
                    wplayer.controls.play();
                }

                //If the descent hasn't started
                if (0.0f < jumpTime && jumpTime <= jumpTimeEnd)
                {
                    //Apply upwards velocity to override gravity
                    velocityY = jumpVelocity * (1.0f - (float)Math.Pow(jumpTime / jumpTimeEnd, jumpControl));
                }
                else
                {
                    jumpTime = 0.0f;        //End the jump by setting its time to 0
                }
            }
            else
            {
                jumpTime = 0.0f;            //End the jump by setting its time to 0
            }

            jumped = jumping;               //Appropriately set the value of jumped
            return velocityY;
        }

        //Detect possible collisions
        //Detect possible collisions
        private void Collide()
        {
            //onGround = false;               //It'll be set to true if player is on ground
            bool platformFound = false;     //Indicates whether a player is above or under a platform

            //Loop through the platforms in the current part of the level
            for (int k = 0; k < level.NumberOfPlatforms[level.Part]; k++)
            {
                //Get the current platform's bounds
                Rectangle platformBounds = level.Platforms[level.Part, k].Bounds;

                //If the player is above the current platform
                if ((Bounds.Left + width/2) >= platformBounds.Left && (Bounds.Left + width / 2) <= platformBounds.Right)
                {
                    //If the player bounds is intersecting with the platform bounds
                    if (Bounds.Intersects(platformBounds))
                    {
                        //If platform isn't broken - player can only get on from the top
                        if (level.Platforms[level.Part, k].collision == Collides.All)
                        {
                            //If the player approaches the platform from the top
                            if (position.Y < platformBounds.Top + 10)
                            {
                                position.Y = platformBounds.Top;    //Move the player onto the platform
                                floor = platformBounds.Top;         //Set the floor to this platform
                                platformFound = true;               //Player is above the platform
                            }
                        }
                        //If platform is broken - player can get onto it from the bottom
                        else
                        {
                            //If the player approaches the platform from the top
                            if (position.Y < platformBounds.Top + 10)
                            {
                                position.Y = platformBounds.Top;    //Move the player onto the platform
                                floor = platformBounds.Top;         //Set the floor to this platform
                                platformFound = true;               //Player is above the platform
                            }
                            else if (position.Y >= platformBounds.Top && position.Y <= platformBounds.Top + 50)
                                position.Y = platformBounds.Top;     //Move the player onto the platform

                        }


                    }
                }

                //If player is on the floor 
                //if (Bounds.Bottom > floor)
                //onGround = true;             //Indicate it
            }

            //This is for testing purposes so our sprite doesn't fall through the floor
            if (!platformFound)
            {
                floor = level.gameHeight + 400;
                //onGround = true;
            }
        }

        public bool DiedByFalling ()
        {
            if (level.Index == 2 && level.NumberOfEnemies[level.Part] > 0)
            {
                if (Bounds.Intersects(level.Enemies[level.Part, 0].Bounds))
                    return true;
                else
                    return false;
            }

            if (Bounds.Top > level.gameHeight)
                return true;
            else
                return false;
        }
        
        public bool ExitReached(GameTime gameTime)
        {
            Rectangle exit = level.Exits[level.Part];
            
            if ((Bounds.Contains(exit) || Bounds.Intersects(exit)) && Bounds.Bottom <= exit.Bottom)
                                      //&& Bounds.Bottom >= exit.Bottom)
            {
                return true;
            }
            else
                return false;
        }

        
    }
}
