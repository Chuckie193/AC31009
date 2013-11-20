using Shadows.Managers;

using System;
using System.Diagnostics;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shadows
{
    class Collision
    {
        public static Color[] coneColors = new Color[RenderManager.graphics.PreferredBackBufferWidth * RenderManager.graphics.PreferredBackBufferHeight];

        /// <summary>
        /// Detects if an AnimatedSprite has collided with a static sprite. If so, resets the sprite
        /// to its previous position
        /// </summary>
        /// <param name="sOne"></param>
        /// <param name="sTwo"></param>
        public static bool detectCollision(AnimatedSprite sOne, Sprite sTwo)
        {
            if (sOne.rect.Intersects(sTwo.rect))
            {
                sOne.position = sOne.prevPosition;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// sOne detects sTwo.
        /// </summary>
        /// <param name="sOne"></param>
        /// <param name="sTwo"></param>
        /// <returns></returns>
        public static bool detectSprite(AnimatedSprite sOne, AnimatedSprite sTwo)
        {
            Vector2 sOneDirection = sOne.position;
            float angle = sOne.angle;

            if (angle == 1.5) // Right
            {
                sOneDirection = new Vector2(1, 0);
            }
            else if (angle == 3) // Down
            {
                sOneDirection = new Vector2(0, 1);
            }
            else if (angle == 4.5) // Looking Left!
            {
                sOneDirection = new Vector2(-1, 0);
            }
            else // Up
            {
                sOneDirection = new Vector2(0, -1);
            }

            sOneDirection.Normalize();

            return CanEnemySeePlayer(sOneDirection, sOne.position, sTwo.position);

        }

        private static bool CanEnemySeePlayer(Vector2 enemyLookAtDirection, Vector2 enemyPosition, Vector2 playerPosition)
        {
            float ConeThirtyDegreesDotProduct = (float)Math.Cos(MathHelper.ToRadians(30f / 2f));

            Vector2 directionEnemyToPlayer = playerPosition - enemyPosition;
            directionEnemyToPlayer.Normalize();

            if (Vector2.Dot(directionEnemyToPlayer, enemyLookAtDirection) > ConeThirtyDegreesDotProduct)
            {
                Debug.WriteLine("Player Detected at X: " + playerPosition.X + " / Y: " + playerPosition.Y);
            }

            return (Vector2.Dot(directionEnemyToPlayer, enemyLookAtDirection) > ConeThirtyDegreesDotProduct);
        }
    }
}
