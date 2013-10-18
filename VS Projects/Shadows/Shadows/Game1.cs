using Windows.UI.ViewManagement;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Shadows.Managers;

namespace Shadows
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        private Texture2D background;
        private Texture2D backgroundx2;
        private Texture2D shadowsTXT;
        private Vector2 FontPos;

        GamePadState gamePadState;

        public Game1()
        {
            RenderManager.Initialise(this);
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
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            RenderManager.LoadContent();
            background = RenderManager.content.Load<Texture2D>("gun_metal");
            backgroundx2 = RenderManager.content.Load<Texture2D>("gun_metal_2x");
            shadowsTXT = RenderManager.content.Load<Texture2D>("shadowsTXT");

            FontPos = new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            Content.Unload();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here
            gamePadState = GamePad.GetState(PlayerIndex.One);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            Rectangle destRect = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);

            RenderManager.spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.Opaque, SamplerState.LinearWrap, DepthStencilState.Default, RasterizerState.CullNone);
            RenderManager.spriteBatch.Draw(backgroundx2, Vector2.Zero, destRect, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
            RenderManager.spriteBatch.End();

            RenderManager.spriteBatch.Begin();

            string output = "LANDSCAPE BABY!";

            // Find the center of the string
            Vector2 FontOrigin = RenderManager.spriteFont.MeasureString(output) / 2;

            if (gamePadState.IsConnected)
            {
                RenderManager.spriteBatch.DrawString(RenderManager.spriteFont, output, FontPos, Color.HotPink, 0, FontOrigin, 1.0f, SpriteEffects.None, 0.5f);
            }
            
            if (gamePadState.Buttons.Y == ButtonState.Pressed)
            {
                RenderManager.spriteBatch.DrawString(RenderManager.spriteFont, output, FontPos, Color.Yellow, 0, FontOrigin, 1.0f, SpriteEffects.None, 0.5f);
            }
            else if (gamePadState.Buttons.B == ButtonState.Pressed)
            {
                RenderManager.spriteBatch.DrawString(RenderManager.spriteFont, output, FontPos, Color.Red, 0, FontOrigin, 1.0f, SpriteEffects.None, 0.5f);
            }
            else if (gamePadState.Buttons.A == ButtonState.Pressed)
            {
                RenderManager.spriteBatch.DrawString(RenderManager.spriteFont, output, FontPos, Color.Green, 0, FontOrigin, 1.0f, SpriteEffects.None, 0.5f);
            }
            else if (gamePadState.Buttons.X == ButtonState.Pressed)
            {
                RenderManager.spriteBatch.DrawString(RenderManager.spriteFont, output, FontPos, Color.Blue, 0, FontOrigin, 1.0f, SpriteEffects.None, 0.5f);
            }

            RenderManager.spriteBatch.End();

            /*
            
            if (ApplicationView.Value == ApplicationViewState.FullScreenLandscape)
            {
                // Draw Hello World
                string output = "LANDSCAPE BABY!";

                // Find the center of the string
                Vector2 FontOrigin = RenderManager.spriteFont.MeasureString(output) / 2;
                RenderManager.spriteBatch.DrawString(RenderManager.spriteFont, output, FontPos, Color.White, 0, FontOrigin, 1.0f, SpriteEffects.None, 0.5f);

                RenderManager.spriteBatch.End();
            }
            
            // GameState running if ApplicationViewState.FullScreenLandscape
            // GameState paused if !ApplicationViewState.FullScreenLandscape
            
            */

            base.Draw(gameTime);
        }
    }
}
