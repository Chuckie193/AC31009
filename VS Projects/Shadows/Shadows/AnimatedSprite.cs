using Shadows.Managers;

using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Shadows
{
    class AnimatedSprite : Sprite
    {
        private const int totalFrames = 5;
        private const int windowBuffer = 2;

        public float frameIndex;
        public int frameHeight;
        public int frameWidth;

        private float time;
        private float frameTime = 0.1f;

        public Vector2 prevPosition;
        public float angle;

        public AnimatedSprite(Texture2D texture) : base(texture)
        {
            frameHeight = texture.Height;
            frameWidth = (texture.Width / 6);
            frameIndex = 0;
        }

        /// <summary>
        /// The update methods allows the sprite to update it's animation and position
        /// on screen. Runs on every call of MainGame.Update()
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
        /// Updates the position of the Sprite to the new location (based on the input
        /// from the user). Ensures sprite does not go off the screen.
        /// </summary>
        /// <param name="direction">Provides the direction for sprite to move.</param>
        private void updatePosition(int direction)
        {
            Vector2 lastPos = position;

            switch (direction)
            {
                case (1):
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

            if (position.X > (RenderManager.width - windowBuffer) || position.X < 0 + (frameWidth / 2) + windowBuffer)
                position.X = lastPos.X;

            if (position.Y > (RenderManager.height - windowBuffer) || position.Y < 0 + (frameHeight / 2) + windowBuffer)
                position.Y = lastPos.Y;
        }
    }
}
