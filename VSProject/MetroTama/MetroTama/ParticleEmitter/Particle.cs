using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace MetroTama.ParticleEmitter
{
    class Particle
    {
        private Vector2 m_position;         // position of the particle
        private Vector2 m_velocity;         // current speed and angle of travel
        private float m_lifeTime = 0.0f;    // how long this particle with live, in seconds
        private float m_startTime = 0.0f;   // when this particle becomes active
        private float m_scale = 1.0f;       // current scale of this particle (for drawing)
        private bool m_active = false;      // is this particle active (or alive)

        // constructor
        public Particle()
        {
            m_position = new Vector2();
            m_velocity = new Vector2();
        }

        /// <summary>
        /// Initialize the particle
        /// </summary>
        /// <param name="pos">initial position of the particle</param>
        /// <param name="vel">initial velocity of the particle</param>
        /// <param name="lifeTime">how long the particle will live</param>
        /// <param name="scale">how big will the particle be</param>
        /// <param name="active">is the particle active (or alive)?</param>
        public void Initialize(Vector2 pos, Vector2 vel, float lifeTime, float scale, bool active)
        {
            m_position = pos;
            m_velocity = vel;
            m_lifeTime = lifeTime;
            m_scale = scale;
            m_active = active;
            m_startTime = 0.0f;
        }

        /// <summary>
        /// Update the particles position and update the particles life time
        /// </summary>
        /// <param name="deltaTime">time between function calls</param>
        public void Update(float deltaTime)
        {
            // add the current velocity to the position
            m_position += m_velocity * deltaTime;

            // update the life time of this particle
            m_startTime += deltaTime;

            // if the life of the particle has expired
            // this particle is no longer active
            if (m_startTime > m_lifeTime)
                m_active = false;
        }

        //*********************
        // Properties
        //*********************

        public Vector2 Position
        {
            get { return m_position; }
            set { m_position = value; }
        }

        public Vector2 Velocity
        {
            get { return m_velocity; }
            set { m_velocity = value; }
        }

        public float LifeTime
        {
            get { return m_lifeTime; }
            set { m_lifeTime = value; }
        }

        public float LifeTimeStart
        {
            get { return m_startTime; }
            set { m_startTime = value; }
        }

        public bool Active
        {
            get { return m_active; }
            set { m_active = value; }
        }

        public float Scale
        {
            get { return m_scale; }
            set { m_scale = value; }
        }
    }
}
