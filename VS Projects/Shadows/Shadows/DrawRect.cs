using Shadows.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shadows
{
    class DrawRect
    {
        static public void DrawRectangle(Rectangle rec, Texture2D tex, Color col, SpriteBatch spriteBatch, bool solid, int thickness)
        {
            if (!solid)
            {

                Vector2 Position = new Vector2(rec.X, rec.Y);
                int border = thickness;

                int borderWidth = (int)(rec.Width) + (border * 2);
                int borderHeight = (int)(rec.Height) + (border);

                drawStraightLine(new Vector2((int)rec.X, (int)rec.Y), new Vector2((int)rec.X + rec.Width, (int)rec.Y), tex, col, spriteBatch, thickness); //top bar 
                drawStraightLine(new Vector2((int)rec.X, (int)rec.Y + rec.Height), new Vector2((int)rec.X + rec.Width, (int)rec.Y + rec.Height), tex, col, spriteBatch, thickness); //bottom bar 
                drawStraightLine(new Vector2((int)rec.X, (int)rec.Y), new Vector2((int)rec.X, (int)rec.Y + rec.Height), tex, col, spriteBatch, thickness); //left bar 
                drawStraightLine(new Vector2((int)rec.X + rec.Width, (int)rec.Y), new Vector2((int)rec.X + rec.Width, (int)rec.Y + rec.Height), tex, col, spriteBatch, thickness); //right bar 
            }
            else
            {
                spriteBatch.Draw(tex, new Vector2((float)rec.X, (float)rec.Y), rec, col, 0.0f, new Vector2(0, 0), 1.0f, SpriteEffects.None, 0.0f);
            }

        }

        //draws a line (rectangle of thickness) from A to B.  A and B have make either horiz or vert line. 
        public static void drawStraightLine(Vector2 A, Vector2 B, Texture2D tex, Color col, SpriteBatch spriteBatch, int thickness)
        {
            Rectangle rec;
            if (A.X < B.X) // horiz line 
            {
                rec = new Rectangle((int)A.X, (int)A.Y, (int)(B.X - A.X), thickness);
            }
            else //vert line 
            {
                rec = new Rectangle((int)A.X, (int)A.Y, thickness, (int)(B.Y - A.Y));
            }

            spriteBatch.Draw(tex, rec, col);
        }
    }
}
