using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroTama.Domain
{
    public class Pet
    {
        public int PetId;
        public string Name;
        public int UserId;
        public int TypeId;
        public int FavoriteFoodId; //TODO: many favorite foods
        public int DislikedFoodId; //TODO: many disliked foods
        public int StatsId;
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
            if (temp_gameTime.TotalGameTime.Subtract(Healt_LastUpdateTime) < Stage.HealtTime)
            {
                if ((Energy < 50) || (Hungry < 50) || (Hygene < 50) || (Fun < 50))
                {
                    Healt -= 5;
                }
                Healt_LastUpdateTime = temp_gameTime.TotalGameTime;
            }
        }

        private void CheckPoop(GameTime temp_gameTime)
        {
            if (temp_gameTime.TotalGameTime.Subtract(Poop_LastUpdateTime) < Stage.PoopTime)
            {
                // Do poop
                Poop_LastUpdateTime = temp_gameTime.TotalGameTime;
            }
        }

        private void CheckStudy(GameTime temp_gameTime)
        {
            if (temp_gameTime.TotalGameTime.Subtract(Study_LastUpdateTime) < Stage.StudyTime)
            {
                Study -= 10;
                Study_LastUpdateTime = temp_gameTime.TotalGameTime;
            }
        }

        private void CheckFun(GameTime temp_gameTime)
        {
            if (temp_gameTime.TotalGameTime.Subtract(Fun_LastUpdateTime) < Stage.FunTime)
            {
                Fun -= 10;
                Fun_LastUpdateTime = temp_gameTime.TotalGameTime;
            }
        }

        private void CheckHygene(GameTime temp_gameTime)
        {
            if (temp_gameTime.TotalGameTime.Subtract(Hygene_LastUpdateTime) < Stage.DirtyTime)
            {
                Hygene -= 10;
                Hygene_LastUpdateTime = temp_gameTime.TotalGameTime;
            }
        }

        private void CheckEnergy(GameTime temp_gameTime)
        {
            if (temp_gameTime.TotalGameTime.Subtract(Energy_LastUpdateTime) < Stage.EnergyTime)
            {
                if (isSleeping)
                {
                    Energy += 5;
                }
                else
                {
                    Energy -= 5;
                }
                Energy_LastUpdateTime = temp_gameTime.TotalGameTime;
            }
        }

        private void CheckHungry(GameTime temp_gameTime)
        {
            if (temp_gameTime.TotalGameTime.Subtract(Hungry_LastUpdateTime) < Stage.EatTime)
            {
                Hungry -= 10;
                Hungry_LastUpdateTime = temp_gameTime.TotalGameTime;
            }
        }
    }
}
