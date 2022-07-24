using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Asteroid_Avoidal
{
    class Controller
    {

        public List<Asteroid> asteroids = new List<Asteroid>();
        public double timer = 2.0;
        public double maxTime = 2.0;
        public int nextSpeed = 240;
        public bool inGame = false;
        public double totalTime = 0;

        public void controllerUpdate(GameTime gameTime)
        {


            if (inGame)
            {
                timer -= gameTime.ElapsedGameTime.TotalSeconds;
                totalTime += gameTime.ElapsedGameTime.TotalSeconds;
            }
            else
            {
                KeyboardState key_state = Keyboard.GetState();

                if (key_state.IsKeyDown(Keys.Enter))
                {
                    inGame = true;

                    maxTime = 2.0;
                    nextSpeed = 240;
                    timer = 2.0;
                    totalTime = 0;

                }

            }

            if(timer <= 0)
            {
                asteroids.Add(new Asteroid(nextSpeed));
                timer = maxTime;

                if (maxTime > 0.5)
                {
                    maxTime -= 0.1;
                }

                if(nextSpeed < 720)
                {
                    nextSpeed += 4;
                }
            }

        }


    }
}
