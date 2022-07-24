using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Asteroid_Avoidal
{
    class Ship
    {
        static public Vector2 defaultPosition = new Vector2(640, 360);
        public Vector2 position = defaultPosition;
        public const int SPEED = 320;
        public int radius = 30;

        public void shipUpdate(GameTime gameTime)
        {

            KeyboardState key_state = Keyboard.GetState();
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;


            if (key_state.IsKeyDown(Keys.S) && position.Y < 720)
            {
                position.Y += SPEED * dt;
            }
            if (key_state.IsKeyDown(Keys.W) && position.Y > 0)
            {
                position.Y -= SPEED * dt;
            }
            if (key_state.IsKeyDown(Keys.D) && position.X < 1280)
            {
                position.X += SPEED * dt;
            }
            if (key_state.IsKeyDown(Keys.A) && position.X > 0)
            {
                position.X -= SPEED * dt;
            }
        }

    }
}
