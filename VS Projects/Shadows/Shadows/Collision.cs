using Shadows.Managers;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shadows
{
    class Collision
    {
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
    }
}
