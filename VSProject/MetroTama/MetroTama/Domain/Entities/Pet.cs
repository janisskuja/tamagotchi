using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using MetroTama.Content.Graphics;

namespace MetroTama.Domain.Entities
{
    public class Pet
    {
        private const int ZerroValue = 0;
        private const int MaxValue = 100;
        private const int HealtDecrease = 1;
        private const int StudyDecrease = 2;
        private const int HungryDecrease = 4;
        private const int HygeneDecrease = 3;
        private const int FunDecrease = 5;
        private const int EnergyDecrease = 2;

        public int PetId;
        public string Name;
        public int UserId;
        public int TypeId;
        public int FavoriteFoodId; //TODO: many favorite foods
        public int DislikedFoodId; //TODO: many disliked foods
        public bool IsSick;
        public int Hungry;
        public int Healt;
        public int Hygene;
        public int Fun;
        public int Energy;
        public int Study;
        public Stage Stage;
        public TimeSpan HungryLastUpdateTime;
        public TimeSpan HealtLastUpdateTime;
        public TimeSpan HygeneLastUpdateTime;
        public TimeSpan FunLastUpdateTime;
        public TimeSpan EnergyLastUpdateTime;
        public TimeSpan StudyLastUpdateTime;
        public TimeSpan PoopLastUpdateTime;
        public bool IsSleeping;
        public List<GraphicsEnum> Animations;

        public void Update(GameTime tempGameTime)
        {

            CheckEnergy(tempGameTime);
            CheckHungry(tempGameTime);
            CheckHygene(tempGameTime);
            CheckFun(tempGameTime);
            CheckStudy(tempGameTime);
            CheckPoop(tempGameTime);
            CheckHealth(tempGameTime);

        }

        public void UpdateFromBackgroud()
        {
            UpdateEnergy();
            UpdateHungry();
            UpdateHygene();
            UpdateFun();
            UpdateStudy();
            UpdateHealth();
        }

        private void CheckHealth(GameTime tempGameTime)
        {
            if (tempGameTime.TotalGameTime.Subtract(HealtLastUpdateTime) > Stage.HealtTime)
            {
                UpdateHealth();
                HealtLastUpdateTime = tempGameTime.TotalGameTime;
            }
           
        }

        private void UpdateHealth()
        {
            if (Healt > ZerroValue)
            {
                if (!IsSleeping)
                {
                    if ((Energy < 50) || (Hungry < 50) || (Hygene < 50) || (Fun < 50))
                    {
                        Healt -= HealtDecrease;
                    }
                }
                else
                {
                    if ((Energy < 50) || (Hungry < 50) || (Hygene < 50) || (Fun < 50))
                    {
                        Healt -= HealtDecrease / 2;
                    }
                }

            }

            if (Healt > MaxValue)
            {
                Healt = MaxValue;
            }

            if (Healt < ZerroValue)
            {
                Healt = 0;
            }
        }

        private void CheckPoop(GameTime tempGameTime)
        {
            if (tempGameTime.TotalGameTime.Subtract(PoopLastUpdateTime) > Stage.PoopTime)
            {
                // Do poop
                PoopLastUpdateTime = tempGameTime.TotalGameTime;
            }
        }

        private void CheckStudy(GameTime tempGameTime)
        {
            if (tempGameTime.TotalGameTime.Subtract(StudyLastUpdateTime) > Stage.StudyTime)
            {
                UpdateStudy();
                StudyLastUpdateTime = tempGameTime.TotalGameTime;
            }
        }

        private void UpdateStudy()
        {
            if (!IsSleeping)
            {
                if (Study > ZerroValue)
                {
                    Study -= StudyDecrease;

                }
            }
            else
            {
                if (Study > ZerroValue)
                {
                    Study -= StudyDecrease / 2;
                }
            }

            if (Study < ZerroValue)
            {
                Study = 0;
            }
            if (Study > MaxValue)
            {
                Study = MaxValue;
            }
        }

        private void CheckFun(GameTime tempGameTime)
        {
            if (tempGameTime.TotalGameTime.Subtract(FunLastUpdateTime) > Stage.FunTime)
            {
                UpdateFun();
                FunLastUpdateTime = tempGameTime.TotalGameTime;
            }
        }

        private void UpdateFun()
        {
            if (!IsSleeping)
            {
                if (Fun > ZerroValue)
                {
                    Fun -= FunDecrease;

                }
            }
            else
            {
                if (Fun > ZerroValue)
                {
                    Fun -= FunDecrease / 2;

                }
            }
            if (Fun < ZerroValue)
            {
                Fun = 0;
            }

            if (Fun > MaxValue)
            {
                Fun = MaxValue;
            }
        }

        private void CheckHygene(GameTime tempGameTime)
        {
            if (tempGameTime.TotalGameTime.Subtract(HygeneLastUpdateTime) > Stage.DirtyTime)
            {
                UpdateHygene();
                HygeneLastUpdateTime = tempGameTime.TotalGameTime;
            }
        }

        private void UpdateHygene()
        {
            if (!IsSleeping)
            {
                if (Hygene > ZerroValue)
                {
                    Hygene -= HygeneDecrease;

                }
            }
            else
            {
                if (Hygene > ZerroValue)
                {
                    Hygene -= HygeneDecrease / 2;

                }
            }
            if (Hygene < ZerroValue)
            {
                Hygene = 0;
            }
            if (Hygene > MaxValue)
            {
                Hygene = MaxValue;
            }
        }

        private void CheckEnergy(GameTime tempGameTime)
        {
            if (tempGameTime.TotalGameTime.Subtract(EnergyLastUpdateTime) > Stage.EnergyTime)
            {
                UpdateEnergy();
                EnergyLastUpdateTime = tempGameTime.TotalGameTime;
            }
        }

        private void UpdateEnergy()
        {
            if (Energy > ZerroValue)
            {
                if (IsSleeping)
                {
                    Energy += EnergyDecrease;
                }
                else
                {
                    Energy -= EnergyDecrease;
                }

            }
            if (Energy < ZerroValue)
            {
                Energy = 0;
            }
            if (Energy > MaxValue)
            {
                Energy = MaxValue;
            }
        }

        private void CheckHungry(GameTime tempGameTime)
        {
            if (tempGameTime.TotalGameTime.Subtract(HungryLastUpdateTime) > Stage.EatTime)
            {
                UpdateHungry();
                HungryLastUpdateTime = tempGameTime.TotalGameTime;
            }
        }

        private void UpdateHungry()
        {
            if (!IsSleeping)
            {
                if (Hungry > ZerroValue)
                {
                    Hungry -= HungryDecrease;

                }
            }
            else
            {
                if (Hungry > ZerroValue)
                {
                    Hungry -= HungryDecrease / 2;

                }
            }
            if (Hungry < ZerroValue)
            {
                Hungry = 0;
            }
            if (Hungry > MaxValue)
            {
                Hungry = MaxValue;
            }
        }
    }
}
