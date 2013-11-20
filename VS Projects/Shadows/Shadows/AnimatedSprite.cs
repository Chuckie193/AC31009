using Shadows.Managers;

using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Shadows
{
    class AnimatedSprite : Sprite
    {
        private const int totalFrames = 5;

        public float frameIndex;
        public int frameHeight;
        public int frameWidth;

        private float time;
        private float frameTime = 0.1f;

        public Vector2 origin;
        public Vector2 prevPosition;

        public float angle;
        public int direction;

        public AnimatedSprite(Texture2D texture, Vector2 startingPosition) : base(texture, startingPosition)
        {
            frameHeight = texture.Height;
            frameWidth = (texture.Width / 6);
            frameIndex = 0;

            origin = new Vector2((frameWidth / 2.0f), (frameHeight / 2.0f));
            prevPosition = new Vector2((RenderManager.width / 2), (RenderManager.height / 2));

            if (startingPosition.X > (RenderManager.width - buffer - (frameWidth / 2)) || startingPosition.X < 0 + buffer + (frameWidth / 2))
                startingPosition.X = (buffer + (frameWidth / 2));

            if (startingPosition.Y > (RenderManager.height - buffer - (frameWidth / 2)) || startingPosition.Y < 0 + buffer + (frameHeight / 2))
                startingPosition.Y = (buffer + (frameHeight / 2));

            position = startingPosition;

            rect = new Rectangle((int)(startingPosition.X - (frameWidth / 2)), (int)(startingPosition.Y - (frameHeight / 2)), (int)(frameWidth), (int)(frameHeight));
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
                    this.frameIndex++;
                    time = 0f;
                }

                if (this.frameIndex > totalFrames)
                {
                    this.frameIndex = 0;
                }
            }
            else
            {
                this.frameIndex = 0;
            }
        }

        /// <summary>
        /// Updates the position of the Sprite to the new location (based on the input
        /// from the user). Ensures sprite does not go off the screen.
        /// </summary>
        /// <param name="direction">Provides the direction for sprite to move.</param>
        private void updatePosition(int direction)
        {
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

            this.direction = direction;

            if (position.X > (RenderManager.width - buffer - (frameWidth / 2)) || position.X < 0 + buffer + (frameWidth / 2))
                position.X = prevPosition.X;

            if (position.Y > (RenderManager.height - buffer - (frameWidth / 2)) || position.Y < 0 + buffer + (frameHeight / 2))
                position.Y = prevPosition.Y;

            rect.X = (int)position.X-(frameWidth/2);
            rect.Y = (int)position.Y-(frameHeight/2);
        }
    }
}
