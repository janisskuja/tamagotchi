using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MetroTama.Domain;
using MetroTama.Domain.Repository;
using MetroTama.Services;
using Microsoft.Xna.Framework.Input;
using MetroTama.Content.Graphics;
using MetroTama.Services.Animation;
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
        private static int MAX_STAT = 100;
        private static bool showMessage = false;
        private static SpriteFont font;
        private static string sayText;
        private static TimeSpan lastMessageUpdate;
        private static TimeSpan messageShowTime = new TimeSpan(0, 0, 0, 3, 0);
        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();

        GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;
        
        public Pet pet;
        public GamePage _gamePage;
        PetRepository petRepository;
        ContentRepository contentRepo;
        GameObjectService gameObjectService;
        private GraphicsEnum graphicsEnum;
        Color bgColor;
        private double mult = 3;
        private double sunRingRotation;
        private double sunDestRotationPos = 2.5;
        Dictionary<int, float> stars1;
        Dictionary<int, float> stars2;

        // the elapsed amount of time the frame has been shown for
        float time;
        // duration of time to show each frame
        // an index of the current frame being shown
        int frameIndexX;
        int frameIndexY = 0;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        public void SetXAMLPage(GamePage gamePage)
        {
            _gamePage = gamePage;
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
            petRepository = new PetRepository();
            pet = petRepository.GetPet();
            gameObjectService = new GameObjectService();
            bgColor = new Color(134, 185, 288);
            contentRepo = new ContentRepository();
            base.Initialize();
            
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("gameFont");

            // TODO: use this.Content to load your game content here
            contentRepo.setSpriteSheetForAnimation(GraphicsEnum.Celebrate, Content.Load<Texture2D>("Graphics/" + GraphicsEnum.Celebrate));
            contentRepo.setSpriteSheetForAnimation(GraphicsEnum.Player, Content.Load<Texture2D>("Graphics/" + GraphicsEnum.Player));
            contentRepo.setSpriteSheetForAnimation(GraphicsEnum.IdleAnimation, Content.Load<Texture2D>("Graphics/" + GraphicsEnum.IdleAnimation));
            contentRepo.setSpriteSheetForAnimation(GraphicsEnum.EatingAnim, Content.Load<Texture2D>("Graphics/" + GraphicsEnum.EatingAnim));
            
            contentRepo.setSpriteSheetForStaticImage(GraphicsEnum.SunCore, Content.Load<Texture2D>("Graphics/" + GraphicsEnum.SunCore));
            contentRepo.setSpriteSheetForStaticImage(GraphicsEnum.SunRing, Content.Load<Texture2D>("Graphics/" + GraphicsEnum.SunRing));
            contentRepo.setSpriteSheetForStaticImage(GraphicsEnum.CloudOne, Content.Load<Texture2D>("Graphics/" + GraphicsEnum.CloudOne));
            contentRepo.setSpriteSheetForStaticImage(GraphicsEnum.CloudTwo, Content.Load<Texture2D>("Graphics/" + GraphicsEnum.CloudTwo));
            contentRepo.setSpriteSheetForStaticImage(GraphicsEnum.CloudThree, Content.Load<Texture2D>("Graphics/" + GraphicsEnum.CloudThree));
            contentRepo.setSpriteSheetForStaticImage(GraphicsEnum.Moon, Content.Load<Texture2D>("Graphics/" + GraphicsEnum.Moon));
            contentRepo.setSpriteSheetForStaticImage(GraphicsEnum.BgDetail, Content.Load<Texture2D>("Graphics/" + GraphicsEnum.BgDetail));
            contentRepo.setSpriteSheetForStaticImage(GraphicsEnum.BgGradient, Content.Load<Texture2D>("Graphics/" + GraphicsEnum.BgGradient));
            contentRepo.setSpriteSheetForStaticImage(GraphicsEnum.BgGradientNight, Content.Load<Texture2D>("Graphics/" + GraphicsEnum.BgGradientNight));
            contentRepo.setSpriteSheetForStaticImage(GraphicsEnum.ComicBubble, Content.Load<Texture2D>("Graphics/" + GraphicsEnum.ComicBubble));
            contentRepo.setSpriteSheetForStaticImage(GraphicsEnum.Star1, Content.Load<Texture2D>("Graphics/Stars/" + GraphicsEnum.Star1));
            contentRepo.setSpriteSheetForStaticImage(GraphicsEnum.Star2, Content.Load<Texture2D>("Graphics/Stars/" + GraphicsEnum.Star2));
            graphicsEnum = GraphicsEnum.IdleAnimation;

            int previousX = 0;
            stars1 = new Dictionary<int, float>();
            stars2 = new Dictionary<int, float>();
            for(int i = 1; i < 11; i++) {
                lock (syncLock)
                { // synchronize
                    previousX = random.Next(100) * i + previousX;
                }
                stars1.Add(previousX, (float)GetRandomNumber(10, 400));
                stars2.Add(20 * i, (float)GetRandomNumber(10, 400));
            }
            
        }

        private double GetRandomNumber(double minimum, double maximum)
        {
            lock (syncLock)
            { // synchronize
                return random.NextDouble() * (maximum - minimum) + minimum;
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
            pet.Update(gameTime);
            _gamePage.UpdateText(pet);
           if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
           if (gameTime.TotalGameTime.Subtract(lastMessageUpdate) > messageShowTime)
           {
               showMessage = false;
               lastMessageUpdate = gameTime.TotalGameTime;
           }
           base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(bgColor);
            
            AnimationData animation = contentRepo.getAnimationData(graphicsEnum);

            StaticImageData sunCore = contentRepo.getStaticImage(GraphicsEnum.SunCore);
            StaticImageData sunRing = contentRepo.getStaticImage(GraphicsEnum.SunRing);
            StaticImageData cloudOne = contentRepo.getStaticImage(GraphicsEnum.CloudOne);
            StaticImageData cloudTwo = contentRepo.getStaticImage(GraphicsEnum.CloudTwo);
            StaticImageData cloudThree = contentRepo.getStaticImage(GraphicsEnum.CloudThree);
            StaticImageData moon = contentRepo.getStaticImage(GraphicsEnum.Moon);
            StaticImageData bgDetail = contentRepo.getStaticImage(GraphicsEnum.BgDetail);
            StaticImageData bgGradient = contentRepo.getStaticImage(GraphicsEnum.BgGradient);
            StaticImageData bgGradientNight = contentRepo.getStaticImage(GraphicsEnum.BgGradientNight);

            StaticImageData comicBubble = contentRepo.getStaticImage(GraphicsEnum.ComicBubble);

            StaticImageData star1 = contentRepo.getStaticImage(GraphicsEnum.Star1);
            StaticImageData star2 = contentRepo.getStaticImage(GraphicsEnum.Star2);
          

            // TODO: Add your drawing code here
         
            time += (float)gameTime.ElapsedGameTime.TotalSeconds;
            while (time > animation.frameTime)
            {
                // Play the next frame in the SpriteSheet
                frameIndexX++;
                // reset elapsedTIme
                time = 0f;
            }
            manageFrameIndexes();

            _spriteBatch.Begin();
            DrawBackgroundDetail(bgDetail, bgGradientNight, bgGradient);
            if (pet.isSleeping)
            {
                foreach (KeyValuePair<int, float> item in stars1)
                {
                    _spriteBatch.Draw(star1.spriteSheet, new Vector2(item.Key, item.Value), star1.getSourceRectangle(), Color.White, (float)sunRingRotation, star1.getOriginVectorCenter(), 1.0f, SpriteEffects.None, 0.0f);
                }

                foreach (KeyValuePair<int, float> item in stars2)
                {
                    _spriteBatch.Draw(star2.spriteSheet, new Vector2(item.Key, item.Value), star2.getSourceRectangle(), Color.White, (float)sunRingRotation, star2.getOriginVectorCenter(), 1.0f, SpriteEffects.None, 0.0f);
                }
            }
            int sunRad = 700;
            Vector2 positionInCircleRadius = getCirclePosition(this.Window.ClientBounds.Width / 2, this.Window.ClientBounds.Height, mult, sunRad);
            Vector2 moonPositionInCircleRadius = getCirclePosition(this.Window.ClientBounds.Width / 2, this.Window.ClientBounds.Height, mult + Math.PI, sunRad);
            _spriteBatch.Draw(sunCore.spriteSheet, positionInCircleRadius, sunCore.getSourceRectangle(), Color.White, 0.0f, sunCore.getOriginVectorCenter(), 1.0f, SpriteEffects.None, 0.0f);
            _spriteBatch.Draw(sunRing.spriteSheet, positionInCircleRadius, sunRing.getSourceRectangle(), Color.White, (float)sunRingRotation, sunRing.getOriginVectorCenter(), 1.0f, SpriteEffects.None, 0.0f);
            _spriteBatch.Draw(moon.spriteSheet, moonPositionInCircleRadius, moon.getSourceRectangle(), Color.White, 0.0f, moon.getOriginVectorCenter(), 1.0f, SpriteEffects.None, 0.0f);
            DrawClouds(cloudOne, cloudTwo, cloudThree, star1, star2);
            DrawTamogochiAnimation(animation);



            if (showMessage)
            {
                _spriteBatch.Draw(comicBubble.spriteSheet, new Vector2(this.Window.ClientBounds.Width / 2 + 130, this.Window.ClientBounds.Height / 2 + 10), comicBubble.getSourceRectangle(), Color.White, 0.0f, comicBubble.getOriginVectorLeftBottom(), 1.0f, SpriteEffects.None, 0.0f);
                _spriteBatch.DrawString(font, sayText, new Vector2(this.Window.ClientBounds.Width / 2 + 190, this.Window.ClientBounds.Height / 2 - 145), Color.Black);
            }

            _spriteBatch.End();
            sunRingRotation = sunRingRotation + 0.01f;
            manageBigCircleRotationSpeed();
            base.Draw(gameTime);
        }
            
        

        private void DrawTamogochiAnimation(AnimationData animation)
        {
            Vector2 position = new Vector2(this.Window.ClientBounds.Width / 2, this.Window.ClientBounds.Height / 2);
            Vector2 origin = new Vector2(animation.frameWidth / 2.0f, 13);
            _spriteBatch.Draw(animation.spriteSheet, position, animation.getSourceRectangle(frameIndexX, frameIndexY), Color.White, 0.0f, origin, 1.0f, SpriteEffects.None, 0.0f);
        }

        private void DrawBackgroundDetail(StaticImageData bgDetail, StaticImageData bgGradientNight, StaticImageData bgGradient)
        {
            for (int i = 0; i <= this.Window.ClientBounds.Width; i++)
            {
                if (pet.isSleeping)
                {
                    _spriteBatch.Draw(bgGradientNight.spriteSheet, new Vector2(i, 0), bgGradientNight.getSourceRectangle(), Color.White, 0.0f, bgGradientNight.getOriginVectorLeftBottom(), 1.0f, SpriteEffects.None, 0.0f);
                }
                else
                {
                    _spriteBatch.Draw(bgGradient.spriteSheet, new Vector2(i, 0), bgGradient.getSourceRectangle(), Color.White, 0.0f, bgGradient.getOriginVectorLeftBottom(), 1.0f, SpriteEffects.None, 0.0f);
                }
            }
            _spriteBatch.Draw(bgDetail.spriteSheet, new Vector2(0, this.Window.ClientBounds.Height), bgDetail.getSourceRectangle(), Color.White, 0.0f, bgDetail.getOriginVectorLeftBottom(), 1.0f, SpriteEffects.None, 0.0f);
            _spriteBatch.Draw(bgDetail.spriteSheet, new Vector2(bgDetail.width, this.Window.ClientBounds.Height), bgDetail.getSourceRectangle(), Color.White, 0.0f, bgDetail.getOriginVectorLeftBottom(), 1.0f, SpriteEffects.None, 0.0f);
            _spriteBatch.Draw(bgDetail.spriteSheet, new Vector2(bgDetail.width * 2, this.Window.ClientBounds.Height), bgDetail.getSourceRectangle(), Color.White, 0.0f, bgDetail.getOriginVectorLeftBottom(), 1.0f, SpriteEffects.None, 0.0f);
        }

        private void DrawClouds(StaticImageData cloudOne, StaticImageData cloudTwo, StaticImageData cloudThree, StaticImageData star1, StaticImageData star2)
        {
            calculateObjectPositionX(cloudOne);
            calculateObjectPositionX(cloudTwo);
            calculateObjectPositionX(cloudThree);
            Color cloudColor = (pet.isSleeping) ? new Color(15, 24, 28) : Color.White;
            Random random = new Random();
            _spriteBatch.Draw(cloudOne.spriteSheet, getCloudPosition(cloudOne), cloudOne.getSourceRectangle(), cloudColor, 0.0f, cloudOne.getOriginVectorCenter(), 1.0f, SpriteEffects.None, 0.0f);
            _spriteBatch.Draw(cloudTwo.spriteSheet, getCloudPosition(cloudTwo), cloudTwo.getSourceRectangle(), cloudColor, 0.0f, cloudTwo.getOriginVectorCenter(), 1.0f, SpriteEffects.None, 0.0f);
            _spriteBatch.Draw(cloudThree.spriteSheet, getCloudPosition(cloudThree), cloudThree.getSourceRectangle(), cloudColor, 0.0f, cloudThree.getOriginVectorCenter(), 1.0f, SpriteEffects.None, 0.0f);

        }

        private void calculateObjectPositionX(StaticImageData Object) {
            Object.xPosition = Object.xPosition + Object.movementSpeed;
            if (this.Window.ClientBounds.Width + 250 < Object.xPosition)
            {
                Object.xPosition = -250;
            }
        }

        private void manageBigCircleRotationSpeed()
        {
            if (Math.Abs(mult) >= 2 * Math.PI)
            {
                mult = 0;
            }
            if (Math.Abs(Math.Round(mult, 1)) != Math.Abs(Math.Round(sunDestRotationPos,1)))
            {
                mult = mult - 0.01;
            }
        }

        private void manageFrameIndexes()
        {
            if (frameIndexX > contentRepo.getAnimationData(graphicsEnum).totalXFrames)
            {
                frameIndexX = 0;
                frameIndexY++;
            }
            if (frameIndexY > contentRepo.getAnimationData(graphicsEnum).totalYFrames)
            {
                frameIndexY = 0;
                graphicsEnum = GraphicsEnum.IdleAnimation;
            }
        }

        public Vector2 getCirclePosition(float cx, float cy, double mult, int rad) {
            double x = cx + Math.Sin(mult)*rad;
            double y = cy + Math.Cos(mult)*rad;
            return new Vector2((float)x, (float)y);
        }

        public Vector2 getCloudPosition(StaticImageData cloud)
        {
            Vector2 vector = new Vector2((float)cloud.xPosition, (float)cloud.yPosition);
            return vector;
        }

        public void Feed(int foodId)
        {
            //Just for testing: must be deleted!
            SayTextService sayTextSrv = new SayTextService();
            sayText = sayTextSrv.GetText(pet);
            showMessage = true;
            // end of tests

            if (pet.isSleeping)
            {
                //Show message: "I'm sleeping!"
            }
            else
            {
                if (pet.Hungry < MAX_STAT)
                {
                    //TODO: insert eating animation
                    graphicsEnum = GraphicsEnum.EatingAnim;
                    gameObjectService.UseObject(pet, foodId);
                }
                else
                {
                    //Show message: "I don't want to play!"
                }
            }
        }

        public void Light()
        {
            pet.isSleeping = !pet.isSleeping;
            if (pet.isSleeping)
            {
                sunDestRotationPos = sunDestRotationPos - Math.PI;
                bgColor = new Color(15,24,28);
            }
            else {
                sunDestRotationPos = 2.5;
                bgColor = new Color(134, 185, 288);
            }
        }

        public void Play(int gameId)
        {
            if (pet.isSleeping)
            {
                //Show message: "I'm sleeping!"
            }
            else
            {
                if (pet.Fun < MAX_STAT)
                {
                    //TODO: add ball animation

                    gameObjectService.UseObject(pet, gameId);
                }
                else
                {
                    //Show message: "I don't want to play!"
                }
            }

        }

        public void Read(int bookId)
        {
            if (pet.isSleeping)
            {
                //Show message: "I'm sleeping!"
            }
            else
            {
                if (pet.Study < MAX_STAT)
                {
                    //TODO: add read animation

                    gameObjectService.UseObject(pet, bookId);
                }
                else
                {
                    //Show message: "I don't want to study!"
                }
            }
        }

        public void Clean(int cleanObjectId)
        {
            if (pet.isSleeping)
            {
                //Show message: "I'm sleeping!"
            }
            else
            {
                if (pet.Hygene < MAX_STAT)
                {
                    //TODO: add clean animation
                    gameObjectService.UseObject(pet, cleanObjectId);
                }
                else
                {
                    //Show message: "Can't clean <petname>, because he is not dirty!"
                }
            }
        }

        public void FirstAid(int medicObjectId)
        {
            if (pet.isSleeping)
            {
                //Show message: "I'm sleeping!"
            }
            else
            {
                if (pet.isSick)
                {
                    //TODO: add first aid animation
                    gameObjectService.UseObject(pet, medicObjectId);
                }
                else
                {
                    //Show message: "Can't use "First Aid", because <petname> is not sick!"
                }
            }
        }
    }
}
