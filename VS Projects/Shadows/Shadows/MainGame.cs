using Windows.UI.ViewManagement;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Shadows.Managers;

namespace Shadows
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class MainGame : Game
    {
        #region Fields
        private Texture2D background;
        private Texture2D backgroundx2;
        private Texture2D shadowsTXT;
        private Vector2 FontPos;
        private SoundEffect soundEffect;

        GamePadState gamePadState;
        bool called = false;
        
        public MainGame()
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

        #endregion

        #region Content Management

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
            soundEffect = RenderManager.content.Load<SoundEffect>("erokia-16");

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

        #endregion

        protected void MenuText()
        {
            KeyboardState keyState = Keyboard.GetState();

            Rectangle destRect = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            RenderManager.spriteBatch.Begin();

            string output = "LANDSCAPE BABY!";

            // Find the center of the string
            Vector2 FontOrigin = RenderManager.spriteFont.MeasureString(output) / 2;

            if (keyState.IsKeyDown(Keys.Up))
            {
                RenderManager.spriteBatch.DrawString(RenderManager.spriteFont, output, FontPos, Color.Yellow, 0, FontOrigin, 1.0f, SpriteEffects.None, 0.5f);
            }
            else if (keyState.IsKeyDown(Keys.Down))
            {
                RenderManager.spriteBatch.DrawString(RenderManager.spriteFont, output, FontPos, Color.Red, 0, FontOrigin, 1.0f, SpriteEffects.None, 0.5f);
            }
            else if (keyState.IsKeyDown(Keys.Right))
            {
                RenderManager.spriteBatch.DrawString(RenderManager.spriteFont, output, FontPos, Color.Green, 0, FontOrigin, 1.0f, SpriteEffects.None, 0.5f);
            }
            else if (keyState.IsKeyDown(Keys.Left))
            {
                RenderManager.spriteBatch.DrawString(RenderManager.spriteFont, output, FontPos, Color.Blue, 0, FontOrigin, 1.0f, SpriteEffects.None, 0.5f);
            }

            RenderManager.spriteBatch.End();
        }

        static protected void LoopSound(SoundEffect soundEffect)
        {
            SoundEffectInstance instance = soundEffect.CreateInstance();
            instance.IsLooped = true;
            instance.Play();
        }

        #region Update and Draw

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here
            gamePadState = GamePad.GetState(PlayerIndex.One);

            if (!called)
            {
                LoopSound(soundEffect);
                called = true;
            }

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

            MenuText();

            base.Draw(gameTime);
        }

        #endregion
    }
}
