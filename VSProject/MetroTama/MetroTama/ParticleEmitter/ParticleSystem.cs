using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MetroTama.ParticleEmitter
{
    class ParticleSystem : DrawableGameComponent
    {
        private Texture2D m_particleSprite;             // 2D texture to draw to the screen
        private Vector2 m_origin;                       // origin of the texture (center of the texture)
        private Vector2 m_originPosition;               // initial position of the particles

        private SpriteBatch m_spriteBuffer;             // used for drawing the particles to the screen

        private List<Particle> m_particleList;          // List of all the particles

        Random rand = new Random();                     // random number generator

        private float m_elapsedTime = 0.0f;             // elapsed time since the last update
        private float m_particlesPerSecond = 50.0f;     // number of particles to draw per second
        private float m_timeLeft = 0.0f;

        private ParticleSystemSettings m_settings = null;   // particles settings

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="game">the current instance of the game</param>
        /// <param name="newSettings">setting for the particle system</param>
        public ParticleSystem(Game game, ParticleSystemSettings newSettings)
            : base(game)
        {
            m_settings = newSettings;

            m_particleList = new List<Particle>(m_settings.InitialParticleCount);

            for (int i = 0; i < m_settings.InitialParticleCount; ++i)
            {
                m_particleList.Add(new Particle());
            }
        }

        /// <summary>
        /// calculate a new velocity for a newly initialized particle
        /// </summary>
        /// <returns>Vector2</returns>
        private Vector2 GetNewVelocity()
        {
            // get a random angle between min direction angle and max direction angle
            float angle = RandomMinMax(m_settings.MinimumDirectionAngle, m_settings.MaximumDirectionAngle);

            // convert the angle to radians
            angle = MathHelper.ToRadians(-angle);

            // return the new velocity based on the angle
            return new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
        }

        /// <summary>
        /// Load the necessary content for the particle system
        /// </summary>
        protected override void LoadContent()
        {
            // load particle texture
            m_particleSprite = Game.Content.Load<Texture2D>(m_settings.ParticleTextureFileName);

            // set the origin of the texture
            m_origin = new Vector2(m_particleSprite.Width / 2, m_particleSprite.Height / 2);

            // initialize the position to zero
            m_originPosition = new Vector2();

            // create the sprite batch
            m_spriteBuffer = new SpriteBatch(GraphicsDevice);

            base.LoadContent();
        }

        // clean up a little
        protected override void Dispose(bool disposing)
        {
            m_particleSprite.Dispose();
            m_particleList.Clear();

            base.Dispose(disposing);
        }

        /// <summary>
        /// Update the particles based on the number of particles to generate per second
        /// </summary>
        /// <param name="gameTime">elapsed game time</param>
        private void UpdateParticlesPerSec(GameTime gameTime)
        {
            // grab the elapsed time since the last update
            m_elapsedTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            // calculate the approximate number of particle to add this iteration
            float particlePerSec = m_settings.ParticlesPerSecond * m_elapsedTime;

            foreach (Particle p in m_particleList)
            {
                // add a new particle if we still have remaining particles to add
                if (particlePerSec > 0.0f)
                {
                    if (p.Active == false)
                    {
                        InitializeParticle(p);
                        --particlePerSec;
                    }
                }

                if (p.Active)
                    p.Update((float)(gameTime.ElapsedGameTime.TotalSeconds));
            }
        }

        /// <summary>
        /// Update the particle system as just a single explosion
        /// </summary>
        /// <param name="gameTime">elapsed game time</param>
        private void UpdateParticleBurst(GameTime gameTime)
        {
            // here we want to only initialize new particles until all the 
            // particles in the List are active. Once all particles are
            // active, the burst is complete so do not re-initialize any
            // new particles, until m_settings.EndBurst == false, again
            foreach (Particle p in m_particleList)
            {
                if (p.Active == false)
                {
                    if (!m_settings.EndBurst)
                        InitializeParticle(p);
                }
                else
                {
                    m_settings.EndBurst = true;
                }

                // update all active particles
                if (p.Active)
                    p.Update((float)(gameTime.ElapsedGameTime.TotalSeconds));
            }
        }

        /// <summary>
        /// Update the particle system
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            // here we update the particles based on whether the
            // particle system is in Burst mode or not
            if (m_settings.IsBurst)
            {
                UpdateParticleBurst(gameTime);
            }
            else
            {
                UpdateParticlesPerSec(gameTime);
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// Initialize a particle to its default values
        /// </summary>
        /// <param name="particle">Particle to initialize</param>
        private void InitializeParticle(Particle particle)
        {
            // get new particle velocity (based on min and max direction angles)
            Vector2 velocity = GetNewVelocity();

            // grab a new speed between MinimumSpeed and MaximumSpeed
            float speed = RandomMinMax(m_settings.MinimumSpeed, m_settings.MaximumSpeed);

            // add the speed to the velocity
            velocity *= speed;

            // grab a new amount of time the particle should remain alive
            float lifeTime = RandomMinMax(m_settings.MinimumLifeTime, m_settings.MaximumLifeTime);

            // grab a new size for the particle 
            float scale = RandomMinMax(m_settings.MinimumScale, m_settings.MaximumScale);

            // initialize the particle with the new settings
            particle.Initialize(m_originPosition, velocity, lifeTime, scale, true);
        }

        /// <summary>
        /// Get a random float between min and max
        /// </summary>
        /// <param name="min">the minimum random value</param>
        /// <param name="max">the maximum random value</param>
        /// <returns>float</returns>
        private float RandomMinMax(float min, float max)
        {
            return min + (float)rand.NextDouble() * (max - min);
        }

        /// <summary>
        /// Draw all active particles
        /// </summary>
        /// <param name="gameTime">elapsed game time</param>
        public override void Draw(GameTime gameTime)
        {
            m_spriteBuffer.Begin();

            foreach (Particle p in m_particleList)
            {
                // draw each active particle in the system
                if (p.Active)
                {
                    // the older the particle, the more transparent it becomes
                    // or basically it fades away the older it gets
                    float remainingLife = p.LifeTimeStart / p.LifeTime;
                    float alpha = 4 * remainingLife * (1 - remainingLife);
                    Color color = Color.White * alpha;

                    m_spriteBuffer.Draw(m_particleSprite, p.Position, null, color,
                        0.0f, m_origin, p.Scale, SpriteEffects.None, 0.0f);
                }
            }

            m_spriteBuffer.End();

            base.Draw(gameTime);
        }

        //****************************
        // Properties
        //****************************
        public Vector2 OriginPosition
        {
            get { return m_originPosition; }
            set { m_originPosition = value; }
        }

        public ParticleSystemSettings Settings
        {
            get { return m_settings; }
            set { m_settings = value; }
        }
    }
}
