using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MetroTama.Domain;
using MetroTama.Domain.Repository;
using MetroTama.Services;
using Microsoft.Xna.Framework.Input;

namespace MetroTama
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;
        public Pet pet;
        public GamePage _gamePage;
        PetRepository petRepository;
        GameObjectService gameObjectService;
        // the spritesheet containing our animation frames
        Texture2D celebrateSpriteSheet;

        // the elapsed amount of time the frame has been shown for
        float time;
        // duration of time to show each frame
        // an index of the current frame being shown
        int frameIndex;

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
            celebrateSpriteSheet = Content.Load<Texture2D>(pet.animationData.contentPath);
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
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            time += (float)gameTime.ElapsedGameTime.TotalSeconds;
            while (time > pet.animationData.frameTime)
            {
                // Play the next frame in the SpriteSheet
                frameIndex++;
                // reset elapsedTIme
                time = 0f;
            }
            if (frameIndex > pet.animationData.totalFrames) frameIndex = 1;
            Rectangle source = new Rectangle(frameIndex * pet.animationData.frameWidth, 0, pet.animationData.frameWidth, pet.animationData.frameHeight);
            Vector2 position = new Vector2(this.Window.ClientBounds.Width / 2, this.Window.ClientBounds.Height / 2);
            Vector2 origin = new Vector2(pet.animationData.frameWidth / 2.0f, pet.animationData.frameHeight);
            _spriteBatch.Begin();
            _spriteBatch.Draw(celebrateSpriteSheet, position, source, Color.White, 0.0f, origin, 1.0f, SpriteEffects.None, 0.0f);
            _spriteBatch.End();
            base.Draw(gameTime);
        }

        public void Feed(int foodId)
        {
            //TODO: insert eating animation
            gameObjectService.UseObject(pet, foodId);
        }

        public void Light()
        {
            //TODO: insert light animation here
            pet.isSleeping = !pet.isSleeping;
        }


        public void Play(int gameId)
        {
            //TODO: add ball animation
            gameObjectService.UseObject(pet, gameId);
        }

        public void Read(int bookId)
        {
            //TODO: add read animation
            gameObjectService.UseObject(pet, bookId);
        }

        internal void Clean(int cleanObjectId)
        {
            //TODO: add clean animation
            gameObjectService.UseObject(pet, cleanObjectId);
        }

        internal void FirstAid(int medicObjectId)
        {
            //TODO: add first aid animation
            gameObjectService.UseObject(pet, medicObjectId);
        }
    }
}
