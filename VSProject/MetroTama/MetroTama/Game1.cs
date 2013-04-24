using MetroTama.ParticleEmitter;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MetroTama.Domain.Repository;
using MetroTama.Services;
using Microsoft.Xna.Framework.Input;
using MetroTama.Content.Graphics;
using System;
using MetroTama.Domain.Entities;
using System.Collections.Generic;

namespace MetroTama
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        // Maximum stat value (ex., Health)
        private const int MaxStat = 100;
        private static bool _showMessage;
        private static SpriteFont _font;
        private static string _sayText;
        private static TimeSpan _lastMessageUpdate;
        private static readonly TimeSpan MessageShowTime = new TimeSpan(0, 0, 0, 3, 0);
        private Vector2 position;
        private static readonly Random Random = new Random();
        private static readonly object SyncLock = new object();
        public bool IsGameStarted = false;
        public bool IsCleaning = false;
        SpriteBatch _spriteBatch;
        

        public GamePage GamePage;
        ContentRepository _contentRepo;
        GameObjectService _gameObjectService;
        public GraphicsEnum _graphicsEnum = GraphicsEnum.IdleAnimation;
        Color _bgColor;
        private double _mult = 3;
        private double _sunRingRotation;
        private const double _sunDestRotationPos = 2.5;
        Dictionary<int, float> _stars1;
        Dictionary<int, float> _stars2;

        ParticleSystem emitter = null;

        // the elapsed amount of time the frame has been shown for
        float _time;
        // duration of time to show each frame
        // an index of the current frame being shown
        int _frameIndexX;
        int _frameIndexY;
        private const float _animPause = 5000f;

        public Game1()
        {
            new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        public void SetXamlPage(GamePage gamePage)
        {
            GamePage = gamePage;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _gameObjectService = new GameObjectService();
            _bgColor = new Color(134, 185, 288);

            ParticleSystemSettings settings = new ParticleSystemSettings();
            position = new Vector2(this.Window.ClientBounds.Width/2, this.Window.ClientBounds.Height);
            settings.ParticleTextureFileName = "Graphics/Bubble";
            settings.IsBurst = true;
            settings.SetLifeTimes(1.0f, 1.5f);
            settings.SetScales(0.001f, 0.04f);
            settings.ParticlesPerSecond = 100.0f;
            settings.InitialParticleCount = (int)(settings.ParticlesPerSecond * settings.MaximumLifeTime);
            settings.SetDirectionAngles(0, 360);

            emitter = new ParticleSystem(this, settings);
            Components.Add(emitter);

            base.Initialize();
            
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            _contentRepo = new ContentRepository(Content);
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _font = Content.Load<SpriteFont>("gameFont");
            GenerateStars();
        }

        private void GenerateStars()
        {
            IsMouseVisible = true;
            emitter.OriginPosition = new Vector2(200, 200);
            var previousX = 0;
            _stars1 = new Dictionary<int, float>();
            _stars2 = new Dictionary<int, float>();
            for (var i = 1; i < 11; i++)
            {
                try
                {
                    AddStars(ref previousX, i);
                }
                catch
                {
                }
            }
        }

        private void AddStars(ref int previousX, int i)
        {
            lock (SyncLock)
            {
                // synchronize
                previousX = Random.Next(100)*i + previousX;
            }
            _stars1.Add(previousX, (float) GetRandomNumber(10, 400));
            _stars2.Add(previousX - 20 * i, (float)GetRandomNumber(10, 400));
        }

        private static double GetRandomNumber(double minimum, double maximum)
        {
            lock (SyncLock)
            { // synchronize
                return Random.NextDouble() * (maximum - minimum) + minimum;
            }
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here
           
            this.GamePage.UpdateStatusUI();
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (gameTime.TotalGameTime.Subtract(_lastMessageUpdate) > MessageShowTime)
            {
                _showMessage = false;
                _lastMessageUpdate = gameTime.TotalGameTime;
            }

            CleaningBubbles();

            base.Update(gameTime);
        }

        private void CleaningBubbles()
        {
            if (!IsCleaning && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                //emitter.Settings.EndBurst = false;
                IsCleaning = true;
                emitter.Settings.IsBurst = !emitter.Settings.IsBurst;
            }
            if (IsCleaning && Mouse.GetState().LeftButton != ButtonState.Pressed)
            {
                IsCleaning = false;
                emitter.Settings.IsBurst = !emitter.Settings.IsBurst;
            }

            emitter.OriginPosition = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(_bgColor);
            if (!IsGameStarted)
            {
                GraphicsDevice.Clear(Color.Black);
                base.Draw(gameTime);
                return;
            }

            var animation = _contentRepo.GetAnimationData(_graphicsEnum);

            var sunCore = _contentRepo.GetStaticImage(GraphicsEnum.SunCore);
            var sunRing = _contentRepo.GetStaticImage(GraphicsEnum.SunRing);
            var cloudOne = _contentRepo.GetStaticImage(GraphicsEnum.CloudOne);
            var cloudTwo = _contentRepo.GetStaticImage(GraphicsEnum.CloudTwo);
            var cloudThree = _contentRepo.GetStaticImage(GraphicsEnum.CloudThree);
            var moon = _contentRepo.GetStaticImage(GraphicsEnum.Moon);
            var bgDetail = _contentRepo.GetStaticImage(GraphicsEnum.BgDetail);
            var bgGradient = _contentRepo.GetStaticImage(GraphicsEnum.BgGradient);
            var bgGradientNight = _contentRepo.GetStaticImage(GraphicsEnum.BgGradientNight);
            var comicBubble = _contentRepo.GetStaticImage(GraphicsEnum.ComicBubble);
            var star1 = _contentRepo.GetStaticImage(GraphicsEnum.Star1);
            var star2 = _contentRepo.GetStaticImage(GraphicsEnum.Star2);
            // TODO: Add your drawing code here
         
            _time += (float)gameTime.ElapsedGameTime.TotalSeconds;
            
            if (_frameIndexX != _contentRepo.GetAnimationData(_graphicsEnum).TotalXFrames - 1 ||
                _frameIndexY != _contentRepo.GetAnimationData(_graphicsEnum).TotalYFrames - 1)
            {
                updateAnimations(animation);
            }
            else if(_time * 1000f > _animPause)
            {
                    updateAnimations(animation);
            }

            _spriteBatch.Begin();

            //if (Pet.IsSleeping)
            //{
                foreach (KeyValuePair<int, float> item in _stars1)
                    _spriteBatch.Draw(star1.SpriteSheet, new Vector2(item.Key, item.Value), star1.GetSourceRectangle(), Color.White, (float)_sunRingRotation, star1.GetOriginVectorCenter(), 1.0f, SpriteEffects.None, 0.0f);

                foreach (KeyValuePair<int, float> item in _stars2)
                    _spriteBatch.Draw(star2.SpriteSheet, new Vector2(item.Key, item.Value), star2.GetSourceRectangle(), Color.White, (float)_sunRingRotation, star2.GetOriginVectorCenter(), 1.0f, SpriteEffects.None, 0.0f);
            //}

            var sunRad = this.Window.ClientBounds.Height * 0.9;
            Vector2 positionInCircleRadius = GetCirclePosition(this.Window.ClientBounds.Width / 2, this.Window.ClientBounds.Height, _mult, sunRad);
            Vector2 moonPositionInCircleRadius = GetCirclePosition(this.Window.ClientBounds.Width / 2, this.Window.ClientBounds.Height, _mult + Math.PI, sunRad);
            _spriteBatch.Draw(sunCore.SpriteSheet, positionInCircleRadius, sunCore.GetSourceRectangle(), Color.White, 0.0f, sunCore.GetOriginVectorCenter(), 1.0f, SpriteEffects.None, 0.0f);
            _spriteBatch.Draw(sunRing.SpriteSheet, positionInCircleRadius, sunRing.GetSourceRectangle(), Color.White, (float)_sunRingRotation, sunRing.GetOriginVectorCenter(), 1.0f, SpriteEffects.None, 0.0f);
            _spriteBatch.Draw(moon.SpriteSheet, moonPositionInCircleRadius, moon.GetSourceRectangle(), Color.White, 0.0f, moon.GetOriginVectorCenter(), 1.0f, SpriteEffects.None, 0.0f);
            DrawBackgroundDetail(bgDetail, bgGradientNight, bgGradient);
            
            DrawClouds(cloudOne, cloudTwo, cloudThree, star1, star2);
            DrawTamogochiAnimation(animation);

            if (_showMessage)
            {
                _spriteBatch.Draw(comicBubble.SpriteSheet, new Vector2(this.Window.ClientBounds.Width / 2 + 130, this.Window.ClientBounds.Height / 2 + 10), comicBubble.GetSourceRectangle(), Color.White, 0.0f, comicBubble.GetOriginVectorLeftBottom(), 1.0f, SpriteEffects.None, 0.0f);
                _spriteBatch.DrawString(_font, _sayText, new Vector2(this.Window.ClientBounds.Width / 2 + 190, this.Window.ClientBounds.Height / 2 - 145), Color.Black);
            }

            _spriteBatch.End();
            _sunRingRotation = _sunRingRotation + 0.01f;
            ManageBigCircleRotationSpeed();
            base.Draw(gameTime);
        }

        private void updateAnimations(AnimationData animation)
        {
            while (_time > animation.FrameTime)
            {
                // Play the next frame in the SpriteSheet
                _frameIndexX++;

                // reset elapsedTIme
                _time = 0f;
            }

            ManageFrameIndexes();
        }


        private void DrawTamogochiAnimation(AnimationData animation)
        {
            
            var origin = new Vector2(animation.FrameWidth / 2.0f, animation.FrameHeight+ 128);
            _spriteBatch.Draw(animation.SpriteSheet, position, animation.GetSourceRectangle(_frameIndexX, _frameIndexY), Color.White, 0.0f, origin, 1.0f, SpriteEffects.None, 0.0f);
        }

        private void DrawBackgroundDetail(StaticImageData bgDetail, StaticImageData bgGradientNight, StaticImageData bgGradient)
        {
            for (int i = 0; i <= this.Window.ClientBounds.Width; i++)
            {
               // if (Pet.IsSleeping)
               // {
                    _spriteBatch.Draw(bgGradientNight.SpriteSheet, new Vector2(i, 0), bgGradientNight.GetSourceRectangle(), Color.White, 0.0f, bgGradientNight.GetOriginVectorLeftBottom(), 1.0f, SpriteEffects.None, 0.0f);
               // }
               // else
               // {
                    _spriteBatch.Draw(bgGradient.SpriteSheet, new Vector2(i, 0), bgGradient.GetSourceRectangle(), Color.White, 0.0f, bgGradient.GetOriginVectorLeftBottom(), 1.0f, SpriteEffects.None, 0.0f);
               // }
            }
            _spriteBatch.Draw(bgDetail.SpriteSheet, new Vector2(0, this.Window.ClientBounds.Height), bgDetail.GetSourceRectangle(), Color.White, 0.0f, bgDetail.GetOriginVectorLeftBottom(), 1.0f, SpriteEffects.None, 0.0f);
            _spriteBatch.Draw(bgDetail.SpriteSheet, new Vector2(bgDetail.Width, this.Window.ClientBounds.Height), bgDetail.GetSourceRectangle(), Color.White, 0.0f, bgDetail.GetOriginVectorLeftBottom(), 1.0f, SpriteEffects.None, 0.0f);
            _spriteBatch.Draw(bgDetail.SpriteSheet, new Vector2(bgDetail.Width * 2, this.Window.ClientBounds.Height), bgDetail.GetSourceRectangle(), Color.White, 0.0f, bgDetail.GetOriginVectorLeftBottom(), 1.0f, SpriteEffects.None, 0.0f);
            _spriteBatch.Draw(bgDetail.SpriteSheet, new Vector2(bgDetail.Width * 3, this.Window.ClientBounds.Height), bgDetail.GetSourceRectangle(), Color.White, 0.0f, bgDetail.GetOriginVectorLeftBottom(), 1.0f, SpriteEffects.None, 0.0f);
        }

        private void DrawClouds(StaticImageData cloudOne, StaticImageData cloudTwo, StaticImageData cloudThree, StaticImageData star1, StaticImageData star2)
        {
            CalculateObjectPositionX(cloudOne);
            CalculateObjectPositionX(cloudTwo);
            CalculateObjectPositionX(cloudThree);
          //  Color cloudColor = (Pet.IsSleeping) ? new Color(15, 24, 28) : Color.White;
            Color cloudColor = Color.White;
            var random = new Random();
            _spriteBatch.Draw(cloudOne.SpriteSheet, GetCloudPosition(cloudOne), cloudOne.GetSourceRectangle(), cloudColor, 0.0f, cloudOne.GetOriginVectorCenter(), 1.0f, SpriteEffects.None, 0.0f);
            _spriteBatch.Draw(cloudTwo.SpriteSheet, GetCloudPosition(cloudTwo), cloudTwo.GetSourceRectangle(), cloudColor, 0.0f, cloudTwo.GetOriginVectorCenter(), 1.0f, SpriteEffects.None, 0.0f);
            _spriteBatch.Draw(cloudThree.SpriteSheet, GetCloudPosition(cloudThree), cloudThree.GetSourceRectangle(), cloudColor, 0.0f, cloudThree.GetOriginVectorCenter(), 1.0f, SpriteEffects.None, 0.0f);

        }

        private void CalculateObjectPositionX(StaticImageData Object) {
            Object.XPosition = Object.XPosition + Object.MovementSpeed;
            if (this.Window.ClientBounds.Width + 250 < Object.XPosition)
            {
                Object.XPosition = -250;
            }
        }

        private void ManageBigCircleRotationSpeed()
        {
            if (Math.Abs(_mult) >= 2 * Math.PI)
            {
                _mult = 0;
            }
            if (Math.Abs(Math.Round(_mult, 1)) != Math.Abs(Math.Round(_sunDestRotationPos,1)))
            {
                _mult = _mult - 0.01;
            }
        }

        private void ManageFrameIndexes()
        {
            if (_frameIndexX > _contentRepo.GetAnimationData(_graphicsEnum).TotalXFrames)
            {
                _frameIndexX = 0;
                _frameIndexY++;
            }

            if (_frameIndexY <= _contentRepo.GetAnimationData(_graphicsEnum).TotalYFrames) return;
            _frameIndexY = 0;
            _graphicsEnum = GraphicsEnum.IdleAnimation;
        }

        public Vector2 GetCirclePosition(float cx, float cy, double mult, double rad) {
            var x = cx + Math.Sin(mult)*rad;
            var y = cy + Math.Cos(mult)*rad;
            return new Vector2((float)x, (float)y);
        }

        public Vector2 GetCloudPosition(StaticImageData cloud)
        {
            return new Vector2((float)cloud.XPosition, (float)cloud.YPosition);
        }
    }
}
