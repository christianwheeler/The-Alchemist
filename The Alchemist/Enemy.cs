using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace The_Alchemist
{
    //Enum to determine enemy direction
    enum Direction
    {
        Left = -1,
        Right = 1
    }

    //Enum to determine enemy type
    enum EnemyType
    {
        Shadow = 0,
        Demon = 1
     }

    class Enemy
    {
        private Animation animation;                    //Enemy Animation
        private Texture2D texture;                      //Enemy Image
        private EnemyType type;                         //Enemy Type
        private int x;                                  //Enemy X Coordinate
        private int y;                                  //Enemy Y Coordinate
        private Vector2 position;                       //Enemy Position
        private int width;                              //Enemy Image Width
        private int height;                             //Enemy Image Height
        private Rectangle bounds;                       //Enemy Bounds
        private Size platformSize;                      //Platform Size Enemy Is On
        private Direction direction = Direction.Left;   //Direction enemy is facing
        private const float moveSpeed = 75.0f;          //Speed of the enemy's movement

        public Enemy(Texture2D t, EnemyType eT, int xC, int yC, Size pS)
        {
            texture = t;
            type = eT;

            //Appropriately set the enemy's starting position according to platform its on
            platformSize = pS;
            if (platformSize == Size.Large)
            {
                x = xC + 180;
                y = yC + 60;
            }
            else
            {
                x = xC + 60;
                y = yC + 55;
            }
            position = new Vector2(x, y);

            //Set width and height according to the enemy's type
            switch (type)
            {
                case EnemyType.Shadow:
                    {
                        width = 230;
                        height = 300;
                    }
                    break;
            }

            //Create the enemy animation
            animation = new Animation(texture, 0.1f, true, width, height);
        }

        //Calculates and returns the enemy's current bounds for collision purposes
        public Rectangle Bounds
        {
            get
            {
                int left = (int)Math.Round(position.X);
                int top = (int)Math.Round(position.Y - height * 0.5f);

                int sWidth = (int)Math.Round(width * 0.5);
                int sHeight = (int)Math.Round(height * 0.5);


                return new Rectangle(left + 70, top + 20, sWidth - 140, sHeight);
            }
        }

        public Animation Animation
        {
            get { return animation; }
        }

        public Texture2D Texture
        {
            get { return texture; }
        }

        public EnemyType Collision
        {
            get { return type; }
        }

        public int X
        {
            get { return x; }
        }

        public int Y
        {
            get { return y; }
        }

        public Vector2 Position
        {
            get { return position; }
        }

        //Updates the enemy as neccessary each frame
        public void Update(GameTime gameTime)
        {
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;   //Elapsed game time

            //If the platform the enemy is created on is large
            if (platformSize == Size.Large)
            {
                //Change the direction of the enemy if it crosses its origin position
                if (position.X > X + 10)
                    direction = (Direction)(-(int)direction);

                //Change the direction of the enemy if it crosses its origin position - platform width
                else if (position.X < X - 130)
                    direction = (Direction)(-(int)direction);
            }
            else if (platformSize == Size.Small)
            {
                //Change the direction of the enemy if it crosses its origin position
                if (position.X > X + 20)
                    direction = (Direction)(-(int)direction);

                //Change the direction of the enemy if it crosses its origin position - platform width
                else if (position.X < X - 20)
                    direction = (Direction)(-(int)direction);
            }

            Vector2 velocity = new Vector2((int)direction * moveSpeed * elapsed, 0.0f);
            position = position + velocity;           
        }

        //Draws the enemy
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //Direction the animation is to be drawn facing
            SpriteEffects animationDirection;

            //Determing the animationDirection according to our direction variable
            if (direction > 0)
                animationDirection = SpriteEffects.FlipHorizontally;
            else
                animationDirection = SpriteEffects.None;

            //Play and draw the animation
            animation.Play();            
            animation.Draw(gameTime, spriteBatch, Position, animationDirection);
        }
    }
}
