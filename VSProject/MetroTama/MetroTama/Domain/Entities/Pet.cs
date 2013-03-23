using Microsoft.Xna.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroTama.Services.Animation;
using MetroTama.Content.Graphics;
using Microsoft.Xna.Framework.Graphics;

namespace MetroTama.Domain
{
    public class Pet
    {
        private static int ZERRO_VALUE = 0;
        private static int HEALT_DECREASE = 1;
        private static int STUDY_DECREASE = 2;
        private static int HUNGRY_DECREASE = 4;
        private static int HYGENE_DECREASE = 3;
        private static int FUN_DECREASE = 5;
        private static int ENERGY_DECREASE = 2;

        public int PetId;
        public string Name;
        public int UserId;
        public int TypeId;
        public int FavoriteFoodId; //TODO: many favorite foods
        public int DislikedFoodId; //TODO: many disliked foods
        public bool isSick;
        public int Hungry;
        public int Healt;
        public int Hygene;
        public int Fun;
        public int Energy;
        public int Study;
        public Stage Stage;
        public TimeSpan Hungry_LastUpdateTime;
        public TimeSpan Healt_LastUpdateTime;
        public TimeSpan Hygene_LastUpdateTime;
        public TimeSpan Fun_LastUpdateTime;
        public TimeSpan Energy_LastUpdateTime;
        public TimeSpan Study_LastUpdateTime;
        public TimeSpan Poop_LastUpdateTime;
        public bool isSleeping;
        public List<GraphicsEnum> animations;

        public void Update(GameTime temp_gameTime)
        {

            CheckEnergy(temp_gameTime);
            CheckHungry(temp_gameTime);
            CheckHygene(temp_gameTime);
            CheckFun(temp_gameTime);
            CheckStudy(temp_gameTime);
            CheckPoop(temp_gameTime);
            CheckHealth(temp_gameTime);

        }

        private void CheckHealth(GameTime temp_gameTime)
        {
            if (temp_gameTime.TotalGameTime.Subtract(Healt_LastUpdateTime) > Stage.HealtTime)
            {
                if (Healt > ZERRO_VALUE)
                {
                    if ((Energy < 50) || (Hungry < 50) || (Hygene < 50) || (Fun < 50))
                    {
                        Healt -= HEALT_DECREASE;
                    }
                    Healt_LastUpdateTime = temp_gameTime.TotalGameTime;
                }
                if (Healt < ZERRO_VALUE)
                {
                    Healt = 0;
                }
            }
        }

        private void CheckPoop(GameTime temp_gameTime)
        {
            if (temp_gameTime.TotalGameTime.Subtract(Poop_LastUpdateTime) > Stage.PoopTime)
            {
                // Do poop
                Poop_LastUpdateTime = temp_gameTime.TotalGameTime;
            }
        }

        private void CheckStudy(GameTime temp_gameTime)
        {
            if (temp_gameTime.TotalGameTime.Subtract(Study_LastUpdateTime) > Stage.StudyTime)
            {
                if (Study > ZERRO_VALUE)
                {
                    Study -= STUDY_DECREASE;
                    Study_LastUpdateTime = temp_gameTime.TotalGameTime;
                }
                if (Study < ZERRO_VALUE)
                {
                    Study = 0;
                }
            }
        }

        private void CheckFun(GameTime temp_gameTime)
        {
            if (temp_gameTime.TotalGameTime.Subtract(Fun_LastUpdateTime) > Stage.FunTime)
            {
                if (Fun > ZERRO_VALUE)
                {
                    Fun -= FUN_DECREASE;
                    Fun_LastUpdateTime = temp_gameTime.TotalGameTime;
                }
                if (Fun < ZERRO_VALUE)
                {
                    Fun = 0;
                }
            }
        }

        private void CheckHygene(GameTime temp_gameTime)
        {
            if (temp_gameTime.TotalGameTime.Subtract(Hygene_LastUpdateTime) > Stage.DirtyTime)
            {
                if (Hygene>ZERRO_VALUE)
                {
                    Hygene -= HYGENE_DECREASE;
                    Hygene_LastUpdateTime = temp_gameTime.TotalGameTime;
                }
                if (Hygene < ZERRO_VALUE)
                {
                    Hygene = 0;
                }
            }
        }

        private void CheckEnergy(GameTime temp_gameTime)
        {
            if (temp_gameTime.TotalGameTime.Subtract(Energy_LastUpdateTime) > Stage.EnergyTime)
            {
                if (Energy > ZERRO_VALUE)
                {
                    if (isSleeping)
                    {
                        Energy += ENERGY_DECREASE;
                    }
                    else
                    {
                        Energy -= ENERGY_DECREASE;
                    }
                    Energy_LastUpdateTime = temp_gameTime.TotalGameTime;
                }
                if (Energy < ZERRO_VALUE)
                {
                    Energy = 0;
                }
            }
        }

        private void CheckHungry(GameTime temp_gameTime)
        {
            if (temp_gameTime.TotalGameTime.Subtract(Hungry_LastUpdateTime) > Stage.EatTime)
            {
                if (Hungry > ZERRO_VALUE)
                {
                    Hungry -= HUNGRY_DECREASE;
                    Hungry_LastUpdateTime = temp_gameTime.TotalGameTime;
                }
                if (Hungry < ZERRO_VALUE)
                {
                    Hungry = 0;
                }
            }
        }
    }
}
