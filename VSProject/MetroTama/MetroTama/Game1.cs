using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MetroTama.Domain;
using MetroTama.Domain.Repository;
using MetroTama.Services;
using Microsoft.Xna.Framework.Input;
using MetroTama.Content.Graphics;
using MetroTama.Services.Animation;

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
        AnimationDataRepository animationDataRepo;
        GameObjectService gameObjectService;
        private GraphicsEnum graphicsEnum;
        Color bgColor;

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
            animationDataRepo = new AnimationDataRepository();
            bgColor = new Color(134, 185, 288);
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
            animationDataRepo.setSpriteSheetForAnimation(GraphicsEnum.Celebrate, Content.Load<Texture2D>("Graphics/" + GraphicsEnum.Celebrate));
            animationDataRepo.setSpriteSheetForAnimation(GraphicsEnum.Player, Content.Load<Texture2D>("Graphics/" + GraphicsEnum.Player));
            animationDataRepo.setSpriteSheetForAnimation(GraphicsEnum.IdleAnimation, Content.Load<Texture2D>("Graphics/" + GraphicsEnum.IdleAnimation));
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
            AnimationData animation = animationDataRepo.getAnimationData(graphicsEnum);

            GraphicsDevice.Clear(bgColor);

            // TODO: Add your drawing code here
            time += (float)gameTime.ElapsedGameTime.TotalSeconds;
            while (time > animation.frameTime)
            {
                // Play the next frame in the SpriteSheet
                frameIndexX++;
                // reset elapsedTIme
                time = 0f;
            }
            if (frameIndexX > animationDataRepo.getAnimationData(graphicsEnum).totalXFrames)
            {
                frameIndexX = 0;
                frameIndexY++;
            }
            if (frameIndexY > animationDataRepo.getAnimationData(graphicsEnum).totalYFrames)
            {
                frameIndexY = 0;
                graphicsEnum = GraphicsEnum.IdleAnimation;
            }
            Rectangle source = new Rectangle(frameIndexX * animation.frameWidth, frameIndexY * animation.frameHeight, animation.frameWidth, animation.frameHeight);
            Vector2 position = new Vector2(this.Window.ClientBounds.Width / 2, this.Window.ClientBounds.Height / 2);
            Vector2 origin = new Vector2(animation.frameWidth / 2.0f, animation.frameHeight / 2.0f);
            _spriteBatch.Begin();
            _spriteBatch.Draw(animation.spriteSheet, position, source, Color.White, 0.0f, origin, 1.0f, SpriteEffects.None, 0.0f);
            _spriteBatch.End();
            base.Draw(gameTime);
        }

        public void Feed(int foodId)
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

        public void Light()
        {
            //TODO: insert light animation here
            pet.isSleeping = !pet.isSleeping;
        }


        public void Play(int gameId)
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

        public void Read(int bookId)
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

        public void Clean(int cleanObjectId)
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

        public void FirstAid(int medicObjectId)
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
