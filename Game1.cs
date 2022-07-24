using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Asteroid_Avoidal
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;


        // Imported Sprites/Font
        Texture2D shipSprite;
        Texture2D asteroidSprite;
        Texture2D spaceSprite;

        SpriteFont gameFont;
        SpriteFont timerFont;

        Ship player = new Ship();
        Controller control = new Controller();



        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }




        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;
            _graphics.ApplyChanges();

            base.Initialize();
        }





        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            shipSprite = Content.Load<Texture2D>("ship");
            asteroidSprite = Content.Load<Texture2D>("asteroid");
            spaceSprite = Content.Load<Texture2D>("space");

            gameFont = Content.Load<SpriteFont>("spaceFont");
            timerFont = Content.Load<SpriteFont>("timerFont");

            // TODO: use this.Content to load your game content here
        }






        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            if (control.inGame)
            {
                player.shipUpdate(gameTime);
            }

            control.controllerUpdate(gameTime);


            for(int i = 0; i < control.asteroids.Count; i++)
            {
                control.asteroids[i].asteroidUpdate(gameTime);

                int sum = control.asteroids[i].radius + player.radius;

                if(Vector2.Distance(control.asteroids[i].position, player.position) < sum)
                {
                    control.inGame = false;
                    player.position = Ship.defaultPosition;
                    control.asteroids.Clear();
                }



            }



            base.Update(gameTime);
        }






        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _spriteBatch.Draw(spaceSprite, new Vector2(0, 0), Color.White);
            _spriteBatch.Draw(shipSprite, new Vector2(player.position.X - 34, player.position.Y - 50), Color.White);

            for (int i = 0; i < control.asteroids.Count; i++)
            {
                _spriteBatch.Draw(asteroidSprite, new Vector2(control.asteroids[i].position.X - control.asteroids[i].radius, control.asteroids[i].position.Y - control.asteroids[i].radius), Color.White);

            }

            if(!control.inGame)
            {
                string menuMessage = "Press Enter to Begin!";
                Vector2 sizeText = gameFont.MeasureString(menuMessage); // Measure String gives width and height, hence Vectror2

                int halfWidth = _graphics.PreferredBackBufferWidth / 2;
                _spriteBatch.DrawString(gameFont, menuMessage, new Vector2(halfWidth - sizeText.X / 2, 200), Color.White);
            }

            _spriteBatch.DrawString(timerFont, "Time: " + Math.Floor(control.totalTime).ToString(), new Vector2(3, 3), Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
