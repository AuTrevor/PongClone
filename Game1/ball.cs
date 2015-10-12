using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    public class Ball : Sprite
    {
        private Paddle _attachedToPaddle;
        private float ballspeed;
        
        //test
        public Ball(Texture2D texture, Vector2 location, Rectangle gameBoundaries) : base(texture, location, gameBoundaries)
        {
        }

        public void AttachTo(Paddle paddle)
        {
            _attachedToPaddle = paddle;
        }

        protected override void CheckBounds()
        {
            if (Location.Y >= (gameBoundaries.Height - Texture.Height) || Location.Y <= 0)
            {
                var NewVelocity = new Vector2(Velocity.X, -Velocity.Y);
                Velocity = NewVelocity;
            }
        }

        public override void Update(GameTime gameTime, GamesObjects gameObjects)
        {
            ballspeed = 2.0f;
            bool collision;
            collision = false;
            if
                (
                Keyboard.GetState().IsKeyDown(Keys.Space) && _attachedToPaddle != null
                )
            {
                while (BoundingBox.Intersects(gameObjects.PlayerPaddle.BoundingBox))
                {
                    Location = new Vector2(Location.X + 1, Location.Y);
                }

                while (BoundingBox.Intersects(gameObjects.Computeraddle.BoundingBox))
                {
                    Location = new Vector2(Location.X - 1, Location.Y);
                }


                var newVelocity = new Vector2(ballspeed,_attachedToPaddle.Velocity.Y * 0.9f);
                Velocity = newVelocity;
                _attachedToPaddle = null;

            }
            if (_attachedToPaddle != null)
            {
                Location.X = _attachedToPaddle.Location.X + _attachedToPaddle.Width;
                Location.Y = _attachedToPaddle.Location.Y;
                collision = false;
            }
            else
            {
                if(BoundingBox.Intersects(gameObjects.PlayerPaddle.BoundingBox) || BoundingBox.Intersects(gameObjects.Computeraddle.BoundingBox))
                {
                    Velocity = new Vector2(-Velocity.X, Velocity.Y);
                    collision = true;
                }
            }
            
            base.Update(gameTime, gameObjects);
        }
    }
}