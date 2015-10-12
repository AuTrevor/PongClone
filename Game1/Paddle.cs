using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Game1
{
    public enum PlayerTypes
    {
        Human,
        Computer
    }


    public class Paddle : Sprite
    {
        private readonly PlayerTypes _playertype;
        private float paddleSpeed = 2.0f;
        //private Rectangle _screenBounds;

        public Paddle(Texture2D texture, Vector2 location, Rectangle gameBoundaries, PlayerTypes playertype) : base(texture, location, gameBoundaries)
        {
            _playertype = playertype;
        }

        public override void Update(GameTime gameTime, GamesObjects gameObjects)
        {
            if (_playertype == PlayerTypes.Human)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Left))
                    Velocity = new Vector2(0, -paddleSpeed);
                // Move paddle up

                if (Keyboard.GetState().IsKeyDown(Keys.Right))
                    Velocity = new Vector2(0, paddleSpeed);
                // Move paddle down
            }

            if (_playertype == PlayerTypes.Computer)
            {
                //Stuff
                var random = new Random();
                var reactionThreshold = random.Next(30, 130);


                if (gameObjects.Ball.Location.Y + gameObjects.Ball.Height < Location.Y + reactionThreshold)
                {
                    Velocity = new Vector2(0, -paddleSpeed);
                }
                if (gameObjects.Ball.Location.Y > Location.Y + Height + reactionThreshold)
                {
                    Velocity = new Vector2(0, paddleSpeed);
                }
            }


                base.Update(gameTime, gameObjects);
        }

        protected override void CheckBounds()
        {
          Location.Y =  MathHelper.Clamp(Location.Y, 0, gameBoundaries.Height - Texture.Height);
        }
    }
}
