using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Asteroid_Avoidal
{
    class Asteroid
    {


        /*Creates the asteroid constructor and updates the speed of the 
         * asteroids based on the speed that is passed to the contstructor,
         * multiplied times the speed of the total elapsed time in the game.
         * 
         * 
         * 
         * 
         */

        public Vector2 position = new Vector2();
        public int speed;
        public int radius = 59; // radius of asteroid sprite


        public Asteroid(int newSpeed)
        {
            speed = newSpeed;
            Random rand = new Random();
            position = new Vector2(1380, rand.Next(0, 721));

        }


        public void asteroidUpdate(GameTime gameTime)
        {        

            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

            position.X -= speed * dt;
            
        }


    }
}
