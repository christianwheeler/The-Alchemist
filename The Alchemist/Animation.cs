using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace The_Alchemist
{
    class Animation
    {
        //Properties of the animation image
        Texture2D texture;
        float frameTime;
        int width;
        int height;

        //Properties of the animation loop
        int frameIndex;
        private float time;
        bool isLooping;
        bool isPlaying = false;

        public Animation(Texture2D t, float fT, bool iL, int w, int h)
        {
            texture = t;
            frameTime = fT;
            isLooping = iL;
            width = w;
            height = h;            
        }

        public Texture2D Texture
        {
            get { return texture; }
        }

        public float FrameTime
        {
            get { return frameTime; }
        }

        public bool IsLooping
        {
            get { return isLooping; }
        }

        public int FrameCount
        {
            get { return Texture.Width / FrameWidth; }
        }

        public int FrameWidth
        {
            get { return width; }
        }

        public int FrameHeight
        {
            get { return height; }
        }

        public int FrameIndex
        {
            get { return frameIndex; }
        }

        //The origin point of the animation
        public Vector2 Origin
        {
            //We divide FrameWidth by 2 to get the middle of the Frame
            get { return new Vector2(FrameWidth / 2.0f, FrameHeight); }
        }

        //Begins or continues animation
        public void Play()
        {
            //If animation is playing don't restart it
            if (isPlaying)
            {
                return;
            }

            //Otherwise start the animation
            isPlaying = true;
            frameIndex = 0;
            time = 0.0f;
        }

        //Increases time, moves the image, and draws the sprite
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, Vector2 position, SpriteEffects spriteEffects)
        {
            // Process the amount of time passing
            time += (float)gameTime.ElapsedGameTime.TotalSeconds;
            while (time > FrameTime)
            {
                time -= FrameTime;

                // Advance the frame index and restart if necessary
                if (IsLooping)
                {
                    frameIndex = (frameIndex + 1) % FrameCount;
                }
                else
                {
                    frameIndex = Math.Min(frameIndex + 1, FrameCount - 1);
                }
            }
            //Calculate the source rectangle of the current frame of the animation
            Rectangle source = new Rectangle(FrameIndex * FrameWidth, 0, FrameWidth, FrameHeight);

            //Draw the current frame of the animation
            spriteBatch.Draw(Texture, position, source, Color.White, 0.0f, Origin, 0.5f, spriteEffects, 0.0f);
        }
    }
}
