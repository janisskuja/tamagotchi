using MetroTama.Content.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MetroTama.Domain.Entities
{
    public class StaticImageData
    {
        public int Height; // define the size of our animation frame
        public int Width;
        public int MovementSpeed;
        public int XPosition;
        public int YPosition;
        public Texture2D SpriteSheet;
        public GraphicsEnum GraphicsEnum;

        public Rectangle GetSourceRectangle()
        {
            return new Rectangle(0, 0, Width, Height);
        }

        public Vector2 GetOriginVectorCenter() {
            return new Vector2(Width / 2.0f, Height / 2.0f);
        }

        public Vector2 GetOriginVectorBottom()
        {
            return new Vector2(Width / 2.0f, Height);
        }

        public Vector2 GetOriginVectorLeftBottom()
        {
            return new Vector2(0, Height);
        }
    }
}
