using MetroTama.Content.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MetroTama.Domain.Entities
{
    public class AnimationData
    {       

        //// duration of time to show each frame
        //public float frameTime = 0.1f;
        //// total number of frames in our spritesheet
        //public int totalFrames = 10;
        //// define the size of our animation frame
        //public int frameHeight = 64;
        //public int frameWidth = 64;
        //public Texture2D spriteSheet;

        public float FrameTime; // duration of time to show each frame
        public int TotalXFrames; // total number of frames in our spritesheet
        public int TotalYFrames; // total number of frames in our spritesheet
        public int FrameHeight; // define the size of our animation frame
        public int FrameWidth;
        public Texture2D SpriteSheet;
        public GraphicsEnum GraphicsEnum;

        public Rectangle GetSourceRectangle(int frameIndexX, int frameIndexY) {
            return new Rectangle(frameIndexX * FrameWidth, frameIndexY * FrameHeight, FrameWidth, FrameHeight);
        }
    }
}
