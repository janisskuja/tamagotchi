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

namespace MetroTama
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        // Maximum stat value (ex., Health)
        private static int MAX_STAT = 100;

        GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;
        public Pet pet;
        public GamePage _gamePage;
        PetRepository petRepository;
        ContentRepository contentRepo;
        GameObjectService gameObjectService;
        private GraphicsEnum graphicsEnum;
<<<<<<< HEAD
        Color bgColor;
=======
        private double mult = 3;
        private double destRotationPos = 2.5;
>>>>>>> Added several animations

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
<<<<<<< HEAD
            animationDataRepo = new AnimationDataRepository();
            bgColor = new Color(134, 185, 288);
=======
            contentRepo = new ContentRepository();
>>>>>>> Added several animations
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

            // TODO: use this.Content to load your game content here
            contentRepo.setSpriteSheetForAnimation(GraphicsEnum.Celebrate, Content.Load<Texture2D>("Graphics/" + GraphicsEnum.Celebrate));
            contentRepo.setSpriteSheetForAnimation(GraphicsEnum.Player, Content.Load<Texture2D>("Graphics/" + GraphicsEnum.Player));
            contentRepo.setSpriteSheetForAnimation(GraphicsEnum.IdleAnimation, Content.Load<Texture2D>("Graphics/" + GraphicsEnum.IdleAnimation));

            contentRepo.setSpriteSheetForStaticImage(GraphicsEnum.SunCore, Content.Load<Texture2D>("Graphics/" + GraphicsEnum.SunCore));
            contentRepo.setSpriteSheetForStaticImage(GraphicsEnum.SunRing, Content.Load<Texture2D>("Graphics/" + GraphicsEnum.SunRing));
            contentRepo.setSpriteSheetForStaticImage(GraphicsEnum.CloudOne, Content.Load<Texture2D>("Graphics/" + GraphicsEnum.CloudOne));
            contentRepo.setSpriteSheetForStaticImage(GraphicsEnum.CloudTwo, Content.Load<Texture2D>("Graphics/" + GraphicsEnum.CloudTwo));
            contentRepo.setSpriteSheetForStaticImage(GraphicsEnum.CloudThree, Content.Load<Texture2D>("Graphics/" + GraphicsEnum.CloudThree));
            graphicsEnum = GraphicsEnum.IdleAnimation;
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
           base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
<<<<<<< HEAD
            AnimationData animation = animationDataRepo.getAnimationData(graphicsEnum);

            GraphicsDevice.Clear(bgColor);

=======
            AnimationData animation = contentRepo.getAnimationData(graphicsEnum);
            GraphicsDevice.Clear(Color.CornflowerBlue);
            StaticImageData sunCore = contentRepo.getStaticImage(GraphicsEnum.SunCore);
            StaticImageData sunRing = contentRepo.getStaticImage(GraphicsEnum.SunRing);
            StaticImageData cloudOne = contentRepo.getStaticImage(GraphicsEnum.CloudOne);
            StaticImageData cloudTwo = contentRepo.getStaticImage(GraphicsEnum.CloudTwo);
            StaticImageData cloudThree = contentRepo.getStaticImage(GraphicsEnum.CloudThree);
>>>>>>> Added several animations
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
            Vector2 position = new Vector2(this.Window.ClientBounds.Width / 2, this.Window.ClientBounds.Height / 2);
            Vector2 origin = new Vector2(animation.frameWidth / 2.0f, animation.frameHeight / 2.0f);
            _spriteBatch.Begin();
            int sunRad = 700;
            calculateObjectPositionX(cloudOne);
            calculateObjectPositionX(cloudTwo);
            calculateObjectPositionX(cloudThree);

            Vector2 positionInCircleRadius = getCirclePosition(this.Window.ClientBounds.Width / 2, this.Window.ClientBounds.Height, mult, sunRad);
            _spriteBatch.Draw(animation.spriteSheet, position, animation.getSourceRectangle(frameIndexX, frameIndexY), Color.White, 0.0f, origin, 1.0f, SpriteEffects.None, 0.0f);
            _spriteBatch.Draw(sunCore.spriteSheet, positionInCircleRadius, sunCore.getSourceRectangle(), Color.White, 0.0f, sunCore.getOriginVector(), 1.0f, SpriteEffects.None, 0.0f);
            _spriteBatch.Draw(sunRing.spriteSheet, positionInCircleRadius, sunRing.getSourceRectangle(), Color.White, (float)mult * 2, sunRing.getOriginVector(), 1.0f, SpriteEffects.None, 0.0f);
            _spriteBatch.Draw(cloudOne.spriteSheet, getCloudPosition(cloudOne), cloudOne.getSourceRectangle(), Color.White, 0.0f, cloudOne.getOriginVector(), 1.0f, SpriteEffects.None, 0.0f);
            _spriteBatch.Draw(cloudTwo.spriteSheet, getCloudPosition(cloudTwo), cloudTwo.getSourceRectangle(), Color.White, 0.0f, cloudTwo.getOriginVector(), 1.0f, SpriteEffects.None, 0.0f);
            _spriteBatch.Draw(cloudThree.spriteSheet, getCloudPosition(cloudThree), cloudThree.getSourceRectangle(), Color.White, 0.0f, cloudThree.getOriginVector(), 1.0f, SpriteEffects.None, 0.0f);
            _spriteBatch.End();

            manageBigCircleRotationSpeed();
            base.Draw(gameTime);
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
            if (mult != destRotationPos)
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
            if (pet.isSleeping)
            {
                //Show message: "I'm sleeping!"
            }
            else
            {
                if (pet.Hungry < MAX_STAT)
                {
                    //TODO: insert eating animation
                    graphicsEnum = GraphicsEnum.Player;
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
            //TODO: insert light animation here
            pet.isSleeping = !pet.isSleeping;
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
