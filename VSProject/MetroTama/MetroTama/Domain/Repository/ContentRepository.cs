using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroTama.Content.Graphics;
using MetroTama.Domain.Entities;
using Microsoft.Xna.Framework.Graphics;

namespace MetroTama.Domain.Repository
{
    class ContentRepository
    {
        readonly Dictionary<GraphicsEnum, AnimationData> _animationDataRepo;
        readonly Dictionary<GraphicsEnum, StaticImageData> _staticImageData;
        private readonly Microsoft.Xna.Framework.Content.ContentManager _content;

        public ContentRepository(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            _content = content;
            _animationDataRepo = new Dictionary<GraphicsEnum, AnimationData>
                {
                    {GraphicsEnum.Celebrate, GetAnimationData(64, 64, 10, 1, 0.1f, "Graphics/", GraphicsEnum.Celebrate)},
                    {GraphicsEnum.Player, GetAnimationData(64, 64, 10, 1, 0.1f, "Graphics/", GraphicsEnum.Player)},
                    {GraphicsEnum.IdleAnimation, GetAnimationData(325, 293, 5, 4, 0.02f, "Graphics/", GraphicsEnum.IdleAnim)},
                    {GraphicsEnum.EatingAnim, GetAnimationData(325, 294, 5, 3, 0.06f, "Graphics/", GraphicsEnum.EatingAnim)}
                };

            _staticImageData = new Dictionary<GraphicsEnum, StaticImageData>
                {
                    {GraphicsEnum.SunCore, GetStaticImageData(175, 175, 0, 0, 0, "Graphics/", GraphicsEnum.SunCore)},
                    {GraphicsEnum.SunRing, GetStaticImageData(213, 213, 0, 0, 0, "Graphics/", GraphicsEnum.SunRing)},
                    {GraphicsEnum.CloudOne, GetStaticImageData(77, 120, 0, 40, 3, "Graphics/", GraphicsEnum.CloudOne)},
                    {GraphicsEnum.CloudTwo, GetStaticImageData(170, 267, 0, 100, 1, "Graphics/", GraphicsEnum.CloudThree)},
                    {GraphicsEnum.CloudThree, GetStaticImageData(105, 167, 0, 95, 2, "Graphics/", GraphicsEnum.CloudTwo)},
                    {GraphicsEnum.Moon, GetStaticImageData(188, 187, 0, 0, 0, "Graphics/", GraphicsEnum.Moon)},
                    {GraphicsEnum.BgDetail, GetStaticImageData(331, 612, 0, 0, 0, "Graphics/", GraphicsEnum.BgDetail)},
                    {GraphicsEnum.BgGradient, GetStaticImageData(396, 1, 0, 0, 0, "Graphics/", GraphicsEnum.BgGradient)},
                    {GraphicsEnum.BgGradientNight, GetStaticImageData(396, 1, 0, 0, 0, "Graphics/", GraphicsEnum.BgGradientNight)},
                    {GraphicsEnum.ComicBubble, GetStaticImageData(229, 331, 0, 0, 0, "Graphics/", GraphicsEnum.ComicBubble)},
                    {GraphicsEnum.Star1, GetStaticImageData(26, 27, 0, 0, 0, "Graphics/Stars/", GraphicsEnum.Star1)},
                    {GraphicsEnum.Star2, GetStaticImageData(18, 19, 0, 0, 0, "Graphics/Stars/", GraphicsEnum.Star2)}
                };
        }

        private StaticImageData GetStaticImageData(int height, int width, int xPosition, int yPosition, int movementSpeed, String spriteDir, GraphicsEnum graphicsEnum)
        {
            var data = new StaticImageData();
            data.GraphicsEnum = graphicsEnum;
            data.Height = height;
            data.Width = width;
            data.XPosition = xPosition;
            data.MovementSpeed = movementSpeed;
            data.YPosition = yPosition;
            data.SpriteSheet = _content.Load<Texture2D>(spriteDir + graphicsEnum);
            return data;
        }

        private AnimationData GetAnimationData(int frameHeight, int frameWidth, int totalXFrames, int totalYFrames, float frameTime, String spriteDir, GraphicsEnum graphicsEnum)
        {
            var animationData = new AnimationData();
            animationData.FrameHeight = frameHeight;
            animationData.FrameWidth = frameWidth;
            animationData.TotalXFrames = totalXFrames;
            animationData.TotalYFrames = totalYFrames;
            animationData.FrameTime = frameTime;
            animationData.GraphicsEnum = graphicsEnum;
            animationData.SpriteSheet = _content.Load<Texture2D>(spriteDir + graphicsEnum);
            return animationData;
        }

        public AnimationData GetAnimationData(GraphicsEnum graphicsEnum) {
            return _animationDataRepo[graphicsEnum];
        }

        public StaticImageData GetStaticImage(GraphicsEnum graphicsEnum)
        {
            return _staticImageData[graphicsEnum];
        }

    }
}
