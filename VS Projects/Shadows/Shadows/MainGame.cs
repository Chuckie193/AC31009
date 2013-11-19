using Shadows.Managers;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

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
        private Vector2 position;

        private Sprite player;
        private Sprite enemy;
        private Audio bgMenu;
        #endregion

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
            RenderManager.SetBoundary(this.Window.ClientBounds.Height, this.Window.ClientBounds.Width);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            RenderManager.createSprites();
            background = RenderManager.content.Load<Texture2D>("gun_metal");
            backgroundx2 = RenderManager.content.Load<Texture2D>("gun_metal_2x");
            shadowsTXT = RenderManager.content.Load<Texture2D>("shadowsTXT");

            position = new Vector2((this.Window.ClientBounds.Width / 2), (this.Window.ClientBounds.Height / 2));

            player = new Sprite(RenderManager.content.Load<Texture2D>("player"));

            bgMenu = new Audio(RenderManager.content.Load<SoundEffect>("erokia-16"));
            // bgMenu.playSound();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            player.Update(gameTime, InputManager.GetInput());

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

            // PLAYER
            Rectangle source = new Rectangle((int)player.frameIndex * player.frameWidth, 0, player.frameWidth, player.frameHeight);
            Vector2 origin = new Vector2((player.frameWidth / 2.0f), (player.frameHeight / 2.0f));
            
            RenderManager.spriteBatch.Begin();
            RenderManager.spriteBatch.Draw(player.spriteTexture, player.position, source, Color.White, player.angle, origin, 1.0f, SpriteEffects.None, 0.0f);
            RenderManager.spriteBatch.End();

            /*
            string output = position.X + " / " + position.Y;
            Vector2 FontOrigin = RenderManager.spriteFont.MeasureString(output) / 2;

            RenderManager.spriteBatch.Begin();
            RenderManager.spriteBatch.DrawString(RenderManager.spriteFont, output, position, Color.Yellow, 0, FontOrigin, 1.0f, SpriteEffects.None, 0.5f);
            RenderManager.spriteBatch.End();
            */

            base.Draw(gameTime);
        }
    }
}
