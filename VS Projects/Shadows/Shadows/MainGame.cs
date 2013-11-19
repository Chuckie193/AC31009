using Shadows.Managers;

using System;
using System.Collections.Generic;

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
        private Texture2D shadowsTXT;
        private Texture2D crate;

        private List<Sprite> crates = new List<Sprite>();

        private Player player;
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
            RenderManager.createSprites();
            RenderManager.SetBoundary(this.Window.ClientBounds.Height, this.Window.ClientBounds.Width);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            background = RenderManager.content.Load<Texture2D>("gun_metal");
            shadowsTXT = RenderManager.content.Load<Texture2D>("shadowsTXT");
            crate = RenderManager.content.Load<Texture2D>("crate");

            crates.Add(new Sprite(crate, new Vector2(50, 50), 0.2f));
            crates.Add(new Sprite(crate, new Vector2(500, 100), 0.5f));
            crates.Add(new Sprite(crate, new Vector2(205, 320), 0.8f));

            player = new Player(RenderManager.content.Load<Texture2D>("player"), new Vector2(10, 10));
            bgMenu = new Audio(RenderManager.content.Load<SoundEffect>("erokia-16"));
            bgMenu.playSound();
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
            Rectangle backgroundLayer = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            Rectangle playerLayer = new Rectangle((int)player.frameIndex * player.frameWidth, 0, player.frameWidth, player.frameHeight);

            RenderManager.spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.Opaque, SamplerState.LinearWrap, DepthStencilState.Default, RasterizerState.CullNone);
            RenderManager.spriteBatch.Draw(background, Vector2.Zero, backgroundLayer, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
            RenderManager.spriteBatch.End();
            
            RenderManager.spriteBatch.Begin();
            RenderManager.spriteBatch.Draw(player.spriteTexture, player.position, playerLayer, Color.White, player.angle, player.origin, 1.0f, SpriteEffects.None, 0.0f);
            RenderManager.spriteBatch.End();

            foreach (Sprite s in crates)
            {
                RenderManager.spriteBatch.Begin();
                RenderManager.spriteBatch.Draw(s.spriteTexture, s.position, null, Color.White, 0.0f, Vector2.Zero, s.scale, SpriteEffects.None, 0.0f);
                RenderManager.spriteBatch.End();
                Collision.detectCollision(player, s);
            }

            base.Draw(gameTime);
        }
    }
}
