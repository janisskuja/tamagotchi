using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroTama.Content.Graphics;
using MetroTama.Domain.Entities;
using MetroTama.Services.Animation;
using Microsoft.Xna.Framework.Graphics;

namespace MetroTama.Domain.Repository
{
    class ContentRepository
    {
        Dictionary<GraphicsEnum, AnimationData> animationDataRepo;
        Dictionary<GraphicsEnum, StaticImageData> staticImageData;
        public ContentRepository() { 
            animationDataRepo = new Dictionary<GraphicsEnum,AnimationData>();
            animationDataRepo.Add(GraphicsEnum.Celebrate, getAnimationData(64, 64, 10, 1, 0.1f, GraphicsEnum.Celebrate));
            animationDataRepo.Add(GraphicsEnum.Player, getAnimationData(64, 64, 10, 1, 0.1f, GraphicsEnum.Player));
            animationDataRepo.Add(GraphicsEnum.IdleAnimation, getAnimationData(260, 360, 4, 1, 0.2f, GraphicsEnum.IdleAnimation));
            animationDataRepo.Add(GraphicsEnum.EatingAnim, getAnimationData(260, 360, 4, 1, 0.2f, GraphicsEnum.EatingAnim));

            staticImageData = new Dictionary<GraphicsEnum, StaticImageData>();
            staticImageData.Add(GraphicsEnum.SunCore, getStaticImageData(175, 175, 0, 0, 0, GraphicsEnum.SunCore));
            staticImageData.Add(GraphicsEnum.SunRing, getStaticImageData(213, 213, 0, 0, 0, GraphicsEnum.SunRing));
            staticImageData.Add(GraphicsEnum.CloudOne, getStaticImageData(77, 120, 0, 40, 3, GraphicsEnum.CloudOne));
            staticImageData.Add(GraphicsEnum.CloudTwo, getStaticImageData(170, 267, 0, 100, 1, GraphicsEnum.CloudThree));
            staticImageData.Add(GraphicsEnum.CloudThree, getStaticImageData(105, 167, 0, 95, 2, GraphicsEnum.CloudTwo));
            staticImageData.Add(GraphicsEnum.Moon, getStaticImageData(188, 187, 0, 0, 0, GraphicsEnum.Moon));
            staticImageData.Add(GraphicsEnum.BgDetail, getStaticImageData(331, 612, 0, 0, 0, GraphicsEnum.BgDetail));
            staticImageData.Add(GraphicsEnum.BgGradient, getStaticImageData(396, 1, 0, 0, 0, GraphicsEnum.BgGradient));
            staticImageData.Add(GraphicsEnum.BgGradientNight, getStaticImageData(396, 1, 0, 0, 0, GraphicsEnum.BgGradientNight));
            
        }

        private static StaticImageData getStaticImageData(int height, int width, int xPosition, int yPosition, int movementSpeed, GraphicsEnum graphicsEnum)
        {
            StaticImageData data = new StaticImageData();
            data.graphicsEnum = graphicsEnum;
            data.height = height;
            data.width = width;
            data.xPosition = xPosition;
            data.movementSpeed = movementSpeed;
            data.yPosition = yPosition;
            return data;
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

        public StaticImageData getStaticImage(GraphicsEnum graphicsEnum)
        {
            return staticImageData[graphicsEnum];
        }

        public void setSpriteSheetForAnimation(GraphicsEnum graphicsEnum, Texture2D spriteSheet)
        {
            animationDataRepo[graphicsEnum].spriteSheet = spriteSheet;
        }

        public void setSpriteSheetForStaticImage(GraphicsEnum graphicsEnum, Texture2D spriteSheet)
        {
            staticImageData[graphicsEnum].spriteSheet = spriteSheet;
        }
    }
}
