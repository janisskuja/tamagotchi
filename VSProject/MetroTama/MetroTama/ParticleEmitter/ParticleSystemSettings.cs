using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroTama.ParticleEmitter
{
    class ParticleSystemSettings
    {
        private int m_initialParticleCount = 200;           // number of particles
        private float m_particlesPerSecond = 100.0f;        // number of particles per second
        private string m_particleTextureFileName = null;    // file to load the particle texture
        private float m_minimumDirectionAngle = 0.0f;       // min direction angle (in degrees)
        private float m_maximumDirectionAngle = 360.0f;     // max direction angle (in degrees)
        private float m_minimumSpeed = 50.0f;               // min particle speed
        private float m_maximumSpeed = 100.0f;              // max particle speed
        private float m_minimumLifeTime = 1.0f;             // min life time of the particle
        private float m_maximumLifeTime = 2.5f;             // max life time of the particle
        private float m_minimumScale = 0.1f;                // min size of the particle
        private float m_maximumScale = 1.0f;                // max size of the particle
        private bool m_isBurst = false;                     // single burst?
        private bool m_endBurst = false;                    // auto set in ParticleSystem

        // constructor
        public ParticleSystemSettings()
        {
        }

        /// <summary>
        /// Set the minimum and maximum of the velocity angles of a particle
        /// </summary>
        /// <param name="min">minimum angle</param>
        /// <param name="max">maximum angle</param>
        public void SetDirectionAngles(float min, float max)
        {
            m_minimumDirectionAngle = min;
            m_maximumDirectionAngle = max;
        }

        /// <summary>
        /// Set how fast the particle should travel
        /// </summary>
        /// <param name="min">minimum speed of the particle</param>
        /// <param name="max">maximum speed of the particle</param>
        public void SetSpeeds(float min, float max)
        {
            m_minimumSpeed = min;
            m_maximumSpeed = max;
        }

        /// <summary>
        /// Set the amount of time the particle should remain active
        /// </summary>
        /// <param name="min">minimum life time of the particle</param>
        /// <param name="max">maximum life time of the particle</param>
        public void SetLifeTimes(float min, float max)
        {
            m_minimumLifeTime = min;
            m_maximumLifeTime = max;
        }

        /// <summary>
        /// Set the size of the particle
        /// </summary>
        /// <param name="min">minimum size of the particle</param>
        /// <param name="max">maximum size of the particle</param>
        public void SetScales(float min, float max)
        {
            m_minimumScale = min;
            m_maximumScale = max;
        }

        //*****************
        // Properties
        //*****************

        public int InitialParticleCount
        {
            get { return m_initialParticleCount; }
            set { m_initialParticleCount = value; }
        }

        public float ParticlesPerSecond
        {
            get { return m_particlesPerSecond; }
            set { m_particlesPerSecond = value; }
        }

        public string ParticleTextureFileName
        {
            get { return m_particleTextureFileName; }
            set { m_particleTextureFileName = value; }
        }

        public float MinimumDirectionAngle
        {
            get { return m_minimumDirectionAngle; }
            set { m_minimumDirectionAngle = value; }
        }

        public float MaximumDirectionAngle
        {
            get { return m_maximumDirectionAngle; }
            set { m_maximumDirectionAngle = value; }
        }

        public float MinimumSpeed
        {
            get { return m_minimumSpeed; }
            set { m_minimumSpeed = value; }
        }

        public float MaximumSpeed
        {
            get { return m_maximumSpeed; }
            set { m_maximumSpeed = value; }
        }

        public float MinimumLifeTime
        {
            get { return m_minimumLifeTime; }
            set { m_minimumLifeTime = value; }
        }

        public float MaximumLifeTime
        {
            get { return m_maximumLifeTime; }
            set { m_maximumLifeTime = value; }
        }

        public float MinimumScale
        {
            get { return m_minimumScale; }
            set { m_minimumScale = value; }
        }

        public float MaximumScale
        {
            get { return m_maximumScale; }
            set { m_maximumScale = value; }
        }

        public bool IsBurst
        {
            get { return m_isBurst; }
            set { m_isBurst = value; }
        }

        public bool EndBurst
        {
            get { return m_endBurst; }
            set { m_endBurst = value; }
        }
    }
}
