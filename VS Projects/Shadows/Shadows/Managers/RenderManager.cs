using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Shadows.Managers
{
    /* The RenderManager class improves cohesion by removing the content management code into a seperate class
     * RenderManager code taken from: http://tjclifton.com/2013/08/11/building-games-for-windows-8-with-monogame-rendering-part-2/
     */
    public static class RenderManager
    {
        public static GraphicsDeviceManager graphics;
        public static ContentManager content;
        public static SpriteBatch spriteBatch;
        public static SpriteFont spriteFont;

        public static void Initialise(Game1 game)
        {
            graphics = new GraphicsDeviceManager(game);
            game.Content.RootDirectory = "Content";
            content = game.Content;
        }

        public static void LoadContent()
        {
            spriteBatch = new SpriteBatch(graphics.GraphicsDevice);
            spriteFont = content.Load<SpriteFont>("Fonts/SegoeUI");
        }
    }
}
