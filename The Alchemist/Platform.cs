using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace The_Alchemist
{
    public enum Collides
    {
        Top = 0,       //Player collides with the top of the platform (Can't fall off).
        All = 1        //Player collides with all sides of the platform.
    }

    public enum Size
    {
        Small = 0,
        Large = 1
    }

    class Platform
    {
        private Texture2D texture;              //Platform Image
        public Collides collision;              //Platform Collision
        private Size size;                      //Platform Size
        private int x;                          //Platform X Coordinate
        private int y;                          //Platform Y Coordinate
        private Vector2 position;               //Platform Position
        private int width;
        private int height;
        private Rectangle bounds;               //Platform Bounds
        
        public Texture2D Texture
        {
            get { return texture; }
        }

        public int Height
        {
            get { return (int) Math.Round(height * 0.6f); }
        }

        public int Width
        {
            get { return (int) Math.Round(width * 0.6f); }
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

        public Platform(Texture2D t, Collides p, Size s, int xC, int yC)
        {
            texture = t;
            collision = p;
            x = xC;
            y = yC;
            position = new Vector2(x, y);

            size = s;

            if (size == Size.Large)
            {
                width = 380;
                height = 94;
            }
            else if (size == Size.Small)
            {
                width = 200;
                height = 100;
            }

            float scale = 0.6f;

            //Calculate the source rectangle of the current frame of the animation
            int sWidth = (int)Math.Round(width * scale);
            int sHeight = (int)Math.Round(height * scale);

            bounds = new Rectangle(x,y,sWidth,sHeight);
        }   

        public Rectangle Bounds
        {
            get { return bounds; }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            float scale = 0.6f;

            //Calculate the source rectangle of the current frame of the animation
            int sWidth = (int)Math.Round(Texture.Width * scale);
            int sHeight = (int)Math.Round(Texture.Height * scale);

            Rectangle source = new Rectangle(X, Y, sWidth, sHeight);

            spriteBatch.Draw(texture, source, Color.White);
        }
    }
}
