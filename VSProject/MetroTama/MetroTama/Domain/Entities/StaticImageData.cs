using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroTama.Content.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MetroTama.Domain.Entities
{
    public class StaticImageData
    {
        public int height; // define the size of our animation frame
        public int width;
        public int movementSpeed;
        public int xPosition;
        public int yPosition;
        public Texture2D spriteSheet;
        public GraphicsEnum graphicsEnum;

        public Rectangle getSourceRectangle()
        {
            return new Rectangle(0, 0, width, height);
        }

        public Vector2 getOriginVector() {
            return new Vector2(width / 2.0f, height / 2.0f);
        }
    }
}
