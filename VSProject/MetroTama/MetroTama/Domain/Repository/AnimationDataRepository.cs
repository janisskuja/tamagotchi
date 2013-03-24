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
            animationDataRepo.Add(GraphicsEnum.Celebrate, getAnimationData(64, 64, 10, 1, 0.1f, GraphicsEnum.Celebrate));
            animationDataRepo.Add(GraphicsEnum.Player, getAnimationData(64, 64, 10, 1, 0.1f, GraphicsEnum.Player));
            animationDataRepo.Add(GraphicsEnum.IdleAnimation, getAnimationData(260, 360, 4, 1, 0.2f, GraphicsEnum.IdleAnimation));
        }

        private static AnimationData getAnimationData(int frameHeight, int frameWidth, int totalXFrames, int totalYFrames, float frameTime, GraphicsEnum graphicsEnum)
        {
            AnimationData animationData = new AnimationData();
            animationData.frameHeight = frameHeight;
            animationData.frameWidth = frameWidth;
            animationData.totalXFrames = totalXFrames;
            animationData.totalYFrames = totalYFrames;
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
