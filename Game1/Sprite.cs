using System.Reflection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    public abstract class Sprite
    {
        protected readonly Texture2D Texture;
        protected readonly Rectangle gameBoundaries;
        public Vector2 Location;
        public int Width
        {
            get { return Texture.Width; }
        }
        public int Height
        {
            get { return Texture.Height; }
        }

        public Rectangle BoundingBox
        {
            get
            {
                return new Rectangle((int)Location.X, (int)Location.Y, Width, Height);
            }
        }

        public Vector2 Velocity { get; protected set; }

        public Sprite(Texture2D texture, Vector2 location, Rectangle gameBoundaries)
        {
            this.Texture = texture;
            this.Location = location;
            Velocity = Vector2.Zero;
            this.gameBoundaries = gameBoundaries;
        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(Texture,Location,Color.White);
                   
        }

        public virtual void Update(GameTime gameTime, GamesObjects gameObjects)
        {
            Location += Velocity;

            CheckBounds();
        }

        protected abstract void CheckBounds();
     
        }
}
