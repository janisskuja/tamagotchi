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
        public int FavoriteFoodId;
        public int DislikedFoodId;
        public int StatsId;
        public int Hungry;
        public int Healt;
        public int Hygene;
        public int Fun;
        public int Energy;
        public int Study;
        public Stage Stage;
        public TimeSpan LastUpdateTime;
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
            if (temp_gameTime.TotalGameTime.Subtract(LastUpdateTime) < Stage.HealtTime)
            {
                if ((Energy < 50) || (Hungry < 50) || (Hygene < 50) || (Fun < 50))
                {
                    Healt -= 5;
                }
            }
        }

        private void CheckPoop(GameTime temp_gameTime)
        {
            if (temp_gameTime.TotalGameTime.Subtract(LastUpdateTime) < Stage.PoopTime)
            {
                // Do poop
            }
        }

        private void CheckStudy(GameTime temp_gameTime)
        {
            if (temp_gameTime.TotalGameTime.Subtract(LastUpdateTime) < Stage.StudyTime)
            {
                Study -= 10;
            }
        }

        private void CheckFun(GameTime temp_gameTime)
        {
            if (temp_gameTime.TotalGameTime.Subtract(LastUpdateTime) < Stage.FunTime)
            {
                Fun -= 10;
            }
        }

        private void CheckHygene(GameTime temp_gameTime)
        {
            if (temp_gameTime.TotalGameTime.Subtract(LastUpdateTime) < Stage.DirtyTime)
            {
                Hygene -= 10;
            }
        }

        private void CheckEnergy(GameTime temp_gameTime)
        {
            if (temp_gameTime.TotalGameTime.Subtract(LastUpdateTime) < Stage.EnergyTime)
            {
                if (isSleeping)
                {
                    Energy += 5;
                }
                else
                {
                    Energy -= 5;
                }
            }
        }

        private void CheckHungry(GameTime temp_gameTime)
        {
            if (temp_gameTime.TotalGameTime.Subtract(LastUpdateTime) < Stage.EatTime)
            {
                Hungry -= 10;
            }
        }
    }
}
