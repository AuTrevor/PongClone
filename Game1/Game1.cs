using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;

        private GamesObjects GameObjects;
        private Paddle _playerPaddle;
        private Paddle _computerPaddle;
        private Ball _ball;
        private Score Score;

        //private Texture2D paddle;
        //another comment.

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferHeight = 600;
            _graphics.PreferredBackBufferWidth = 800;
            
            Content.RootDirectory = "Content";

           
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            IsMouseVisible = true;
            

        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            var gameboundaries = new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height);
            var paddleTexture = Content.Load<Texture2D>("Paddle");


            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _playerPaddle = new Paddle(Content.Load<Texture2D>("Paddle"), Vector2.Zero, gameboundaries, PlayerTypes.Human);

            var computerPaddleLocation = new Vector2(Window.ClientBounds.Width - paddleTexture.Width, 0);
            _computerPaddle = new Paddle(Content.Load<Texture2D>("Paddle"), computerPaddleLocation , gameboundaries, PlayerTypes.Computer);
            _ball = new Ball(Content.Load<Texture2D>("Ball"), Vector2.Zero, gameboundaries);
            _ball.AttachTo(_playerPaddle);
            Score = new Score(Content.Load<SpriteFont>("NewSpriteFont"),gameboundaries);

            GameObjects = new GamesObjects { PlayerPaddle = _playerPaddle, Computeraddle = _computerPaddle, Ball = _ball, Score = Score};
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            _playerPaddle.Update(gameTime, GameObjects);
            _computerPaddle.Update(gameTime, GameObjects);
            _ball.Update(gameTime, GameObjects);
            Score.Update(gameTime, GameObjects);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _playerPaddle.Draw(_spriteBatch);
            _ball.Draw(_spriteBatch);
            _computerPaddle.Draw(_spriteBatch);
            Score.Draw(_spriteBatch);
            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
