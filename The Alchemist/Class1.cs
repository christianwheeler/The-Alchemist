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
    class OldMan
    {
        private SpriteFont font;
        GraphicsDevice graphics;
        Texture2D oldman;
        Vector2 position;
        int width = 180;
        int height = 267;
        private ContentManager content;
        //This is the timer to check how long bfore the oldman appears
        ClockTimer firstClock;
        //This is to determine how long he remains visible before he fades
        ClockTimer secondClock;
        //This is the overall time from the time the level starts to the time the old man disappears
        ClockTimer thirdClock;
       
        public ContentManager Content
        {
            get { return content; }
        }

       // IServiceProvider serviceProvider;

        // Fading values
        int AlphaValue = 0;
        int FadeIncrement = 3;
        double Delay = 0.035;
        SpriteBatch fade;


        Rectangle source;
        public OldMan(Texture2D om,int x, int y, ContentManager c)
        {

            //graphics = new GraphicsDeviceManager(this);
           // Content.RootDirectory = "Content";
            // content = new ContentManager(serviceProvider, "Content");
            int sWidth = (int)Math.Round(width * 0.55f);
            int sHeight = (int)Math.Round(height * 0.55f);

            content = c;

            try
            {
                font = Content.Load<SpriteFont>("Font/Papyrus Small");
            }
            catch
            {
                
            }

            oldman = om;
            position = new Vector2(x,y);
            source = new Rectangle(x, y, sWidth,sHeight);
            firstClock = new ClockTimer();
            secondClock = new ClockTimer();
            thirdClock = new ClockTimer();
            firstClock.Start(5);
            secondClock.Start(5);
            thirdClock.Start(17);
          //  fade = new SpriteBatch(graphics);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //Set the player direction according to the side the player is moving towards

            //Draw the currently set player animation
            // spriteBatch.Draw(gameTime, spriteBatch, position, direction);

           //fade.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied);
            if(thirdClock.checkTime(gameTime)){
            
            
            }
            else if(firstClock.checkTime(gameTime)){
            spriteBatch.Draw(oldman,source, new Color(255, 255, 255, (byte)MathHelper.Clamp(AlphaValue, 0, 255)));
            spriteBatch.DrawString(font, "The only meaning to life is completing the Great Work.", new Vector2(position.X - 145, position.Y - 60), new Color(201, 11, 11, (byte)MathHelper.Clamp(AlphaValue, 0, 255)));
            spriteBatch.DrawString(font, "Follow the light young Alchemist!", new Vector2(100, 100), new Color(255, 255, 255, (byte)MathHelper.Clamp(AlphaValue, 0, 255)));
            
            }
          // fade.End();

        }

        public void Update(GameTime gameTime)
        {

            //Decrement the delay by the number of seconds that have elapsed since
            //the last time that the Update method was called
            
            if(firstClock.checkTime(gameTime)){
                Delay -= gameTime.ElapsedGameTime.TotalSeconds;
            //if the delay is dropped below 0, then the fading in/out happens a little bit
            if (Delay <= 0)
            {

                //resets the delay
                Delay = 0.035;

                //increment/decrement the fade value
                if (AlphaValue >= 255)
               {
                   if (secondClock.checkTime(gameTime)) {
                       AlphaValue += FadeIncrement;
                   }
                
               }else{

                    AlphaValue += FadeIncrement;
                   }
                //If the AlphaValue is equal or above the max Alpha value or
                //has dropped below or equal to the min Alpha value, then 
                //reverse the fade.


                if(secondClock.checkTime(gameTime)){
                if (AlphaValue >= 255 || AlphaValue <= 0)
                {

                    FadeIncrement *= -1;

                }
                }

            }
            }
        }
    }

}
