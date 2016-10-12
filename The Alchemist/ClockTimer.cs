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
    class ClockTimer
    {
        // Declare timer variables
        private int endTimer;
        private int countTimeRef;
        public bool isRunning { get; private set; }
        public bool isFinished { get; private set; }

        

        // ClockTimer method
        public ClockTimer()
        {
            endTimer = 0;
            countTimeRef = 0;
            isRunning = false;
            isFinished = false;
        }

        // The (int seconds) is the amount of time you would like the timer to run. You will see in the Game1 Class: clock.Start(10) that means timer will run for 10 Seconds

        public void Start(int seconds)
        {
            // Start timer
            endTimer = seconds;
            isRunning = true;

        }

        public Boolean checkTime(GameTime gameTime)
        {
            countTimeRef += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (!isFinished)
            {
                if (countTimeRef > 1000.0f)
                {
                    // Let timer count down
                    endTimer = endTimer - 1;
                    countTimeRef = 0;


                    if (endTimer <= 0)
                    {
                        endTimer = 0;
                        isFinished = true;
                    }
                }
            }
            else
            {

            }
            return isFinished;
        }

        // Reset clocktimer method
        public void Reset()
        {
            isRunning = false;
            isFinished = false;
            countTimeRef = 0;
            endTimer = 0;
        }
    }

}
















