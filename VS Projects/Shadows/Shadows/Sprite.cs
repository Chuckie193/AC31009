using Shadows.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shadows
{
    class Sprite
    {
        #region Fields
        private const int totalFrames = 5;

        public Texture2D spriteTexture;
        private float time;
        private float frameTime = 0.1f;

        public float frameIndex;
        public int frameHeight;
        public int frameWidth;

        public Vector2 position;
        public Vector2 prevPosition;
        public float angle;

        #endregion

        public Sprite(Texture2D texture)
        {
            position = new Vector2((RenderManager.width / 2), (RenderManager.height / 2));
            spriteTexture = texture;

            frameHeight = texture.Height;
            frameWidth = (texture.Width/6);
            frameIndex = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        /// <param name="direction">Provides the direction for sprite to move.</param>
        public void Update(GameTime gameTime, int direction)
        {
            prevPosition = position;
            updatePosition(direction);

            if (prevPosition.X != position.X || prevPosition.Y != position.Y)
            {
                time += (float)gameTime.ElapsedGameTime.TotalSeconds;

                while (time > frameTime)
                {
                    frameIndex++;
                    time = 0f;
                }

                if (frameIndex > totalFrames)
                {
                    frameIndex = 0;
                }
            }
            else
            {
                frameIndex = 0;
            }
        }

        /// <summary>
        /// Converts the direction integer to the X, Y and Angle fields.
        /// </summary>
        /// <param name="direction">Provides the direction for sprite to move.</param>
        private void updatePosition(int direction)
        {
            switch (direction)
            {
                case(1):
                    position.X += 0;
                    position.Y += -1;
                    angle = 0f;
                    break;

                case (2):
                    position.X += 0;
                    position.Y += 1;
                    angle = 3f;
                    break;

                case (3):
                    position.X += -1;
                    position.Y += 0;
                    angle = 4.5f;
                    break;

                case (4):
                    position.X += 1;
                    position.Y += 0;
                    angle = 1.5f;
                    break;

                default:
                    break;
            }

            if (position.X > RenderManager.width)
                position.X = RenderManager.width - frameWidth;
            else if (position.X < 0)
                position.X = 0 + frameWidth;

            if (position.Y > RenderManager.height)
                position.Y = RenderManager.height - frameHeight;
            else if (position.Y < 0)
                position.Y = 0 + frameHeight;
        }
    }
}
