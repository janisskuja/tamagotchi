using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroTama.Content.Graphics;
using MetroTama.Services.Animation;
using Microsoft.Xna.Framework.Graphics;

namespace MetroTama.Domain.Repository
{
    class AnimationDataRepository
    {
        Dictionary<GraphicsEnum, AnimationData> animationDataRepo;
        public AnimationDataRepository() { 
            animationDataRepo = new Dictionary<GraphicsEnum,AnimationData>();
            animationDataRepo.Add(GraphicsEnum.Celebrate, getAnimationData(64, 64, 10, 0.1f, GraphicsEnum.Celebrate));
            animationDataRepo.Add(GraphicsEnum.Player, getAnimationData(64, 64, 10, 0.1f, GraphicsEnum.Player));
        }

        private static AnimationData getAnimationData(int frameHeight, int frameWidth, int totalFrames, float frameTime, GraphicsEnum graphicsEnum)
        {
            AnimationData animationData = new AnimationData();
            animationData.frameHeight = frameHeight;
            animationData.frameWidth = frameWidth;
            animationData.totalFrames = totalFrames;
            animationData.frameTime = frameTime;
            animationData.graphicsEnum = graphicsEnum;
            return animationData;
        }

        public AnimationData getAnimationData(GraphicsEnum graphicsEnum) {
            return animationDataRepo[graphicsEnum];
        }

        public void setSpriteSheetForAnimation(GraphicsEnum graphicsEnum, Texture2D spriteSheet)
        {
            animationDataRepo[graphicsEnum].spriteSheet = spriteSheet;
        }

    }
}
