using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroTama.Content.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MetroTama.Services.Animation
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

        public float frameTime; // duration of time to show each frame
        public int totalFrames; // total number of frames in our spritesheet
        public int frameHeight; // define the size of our animation frame
        public int frameWidth;
        public Texture2D spriteSheet;
        public GraphicsEnum graphicsEnum;

    }
}
