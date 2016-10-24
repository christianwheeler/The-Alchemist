using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace The_Alchemist
{
  
    public class AnimatorManager
    {
        public Animator animation;

        private TimeSpan previousFrameChangeTime = TimeSpan.Zero;

        private TimeSpan previousMovementTime = TimeSpan.Zero;

        public TexturePackerLoader.SpriteSheet spriteSheet;

        private Vector2 currentPosition;

        public AnimatorManager(TexturePackerLoader.SpriteSheet spriteSheet, Vector2 initialPosition, Animator animation)
        {
            this.spriteSheet = spriteSheet;
            this.animation = animation;
            this.currentPosition = initialPosition;
        }

        public TexturePackerLoader.SpriteFrame CurrentSprite { get; private set; }

        public SpriteEffects CurrentSpriteEffects { get; set; }

        public int CurrentFrame { get; private set; }

        public int CurrentAnimation { get; set; }

        public Vector2 CurrentPosition
        {
            get { return this.currentPosition; }
        }

        public void Update(GameTime gameTime)
        {
            var nowTime = gameTime.TotalGameTime;
            var dtFrame = nowTime - this.previousFrameChangeTime;
            var dtPosition = nowTime - this.previousMovementTime;

            if (dtFrame >= animation.TimePerFrame)
            {
                this.previousFrameChangeTime = nowTime;
                this.CurrentFrame++;

                if (this.CurrentFrame >= animation.Sprites.Length)
                {
                    this.CurrentFrame = 0;
                }

                this.CurrentSpriteEffects = animation.Effect;
            }

            this.CurrentSprite = this.spriteSheet.Sprite(animation.Sprites[this.CurrentFrame]);

            this.currentPosition.X += animation.CharacterVelocity.X * dtPosition.Ticks / TimeSpan.TicksPerSecond;
            this.currentPosition.Y += animation.CharacterVelocity.Y * dtPosition.Ticks / TimeSpan.TicksPerSecond;
            this.previousMovementTime = nowTime;
        }
    }
}
