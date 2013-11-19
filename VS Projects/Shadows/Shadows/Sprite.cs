using Shadows.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shadows
{
    class Sprite
    {
        #region Fields
        protected const int windowBuffer = 2;

        public Texture2D spriteTexture;
        public Vector2 position;
        public float scale;
        #endregion

        public Sprite(Texture2D texture)
        {
            position = new Vector2((RenderManager.width / 2), (RenderManager.height / 2));
            spriteTexture = texture;
        }

        public Sprite(Texture2D texture, Vector2 startingPosition)
        {   
            position = startingPosition;
            spriteTexture = texture;
        }

        public Sprite(Texture2D texture, Vector2 startingPosition, float scale)
        {
            position = startingPosition;
            spriteTexture = texture;
            this.scale = scale;
        }
    }
}
