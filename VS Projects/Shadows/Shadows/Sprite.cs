using Shadows.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shadows
{
    class Sprite
    {
        #region Fields
        public Texture2D spriteTexture;
        public Vector2 position;

        #endregion

        public Sprite(Texture2D texture)
        {
            position = new Vector2((RenderManager.width / 2), (RenderManager.height / 2));
            spriteTexture = texture;
        }

    }
}
