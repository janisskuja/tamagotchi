using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MetroTama.Domain;
using MetroTama.Domain.Repository;
using MetroTama.Services;

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


            base.Draw(gameTime);
        }

        public void Feed(int foodId)
        {
            //TODO: insert eating animation
            gameObjectService.UseObject(pet, foodId);
        }

        public void Play()
        {
            //TODO: add playing logic
            throw new System.NotImplementedException();
        }

        public void Clean()
        {
            //TODO: add clean logic
            throw new System.NotImplementedException();
        }

        public void FirstAid()
        {
            //TODO: add FirstAid logic
            throw new System.NotImplementedException();
        }

        public void Light()
        {
            //TODO: insert light animation here
            pet.isSleeping = !pet.isSleeping;
            throw new System.NotImplementedException();
        }


        public void Play(int gameId)
        {
            throw new System.NotImplementedException();
        }

        public void Read(int bookId)
        {
            throw new System.NotImplementedException();
        }
    }
}
