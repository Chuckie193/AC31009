using Shadows.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shadows
{
    class Sprite
    {
        #region Fields
        protected const int buffer = 2;

        public Rectangle rect;
        public Vector2 position;
        public Texture2D spriteTexture;
        public float scale = 1.0f;

        #endregion

        public Sprite(Texture2D texture)
        {
            rect = new Rectangle((RenderManager.width / 2)-buffer, (RenderManager.height / 2)-buffer, texture.Width+buffer, texture.Height+buffer);
            position = new Vector2((RenderManager.width / 2), (RenderManager.height / 2));
            spriteTexture = texture;
        }

        public Sprite(Texture2D texture, Vector2 startingPosition)
        {
            rect = new Rectangle((int)startingPosition.X-buffer, (int)startingPosition.Y-buffer, texture.Width+buffer, texture.Height+buffer);
            position = startingPosition;
            spriteTexture = texture;
        }

        public Sprite(Texture2D texture, Vector2 startingPosition, float scale)
        {
            rect = new Rectangle((int)startingPosition.X-buffer, (int)startingPosition.Y-buffer, (int)(texture.Width*scale), (int)(texture.Height*scale));
            position = startingPosition;
            spriteTexture = texture;
            this.scale = scale;
        }
    }
}
