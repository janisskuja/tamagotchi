using MetroTama.Domain;
using MetroTama.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroTama.Services
{
    class GameObjectService
    {
        private static int MAX_VALUE = 100;
        private static int MIN_VALUE = 0;

        public void UseObject(Pet temp_pet, int gameObjectId)
        {
            GameObjectRepository temp_GameObjectRepository = new GameObjectRepository();
            GameObject temp_GameObject = temp_GameObjectRepository.GetGameObject(gameObjectId);

            UpdateFun(temp_pet, gameObjectId, temp_GameObject);
            UpdateHealth(temp_pet, temp_GameObject);
            UpdateHungry(temp_pet, temp_GameObject);
            UpdateEnergy(temp_pet, temp_GameObject);
            UpdateHygene(temp_pet, temp_GameObject);
            UpdateStudy(temp_pet, temp_GameObject);
        }

        private static void UpdateStudy(Pet temp_pet, GameObject temp_GameObject)
        {
            temp_pet.Study += temp_GameObject.StudyEffect;

            if (temp_pet.Study > MAX_VALUE)
            {
                temp_pet.Study = MAX_VALUE;
            }

            if (temp_pet.Study < MIN_VALUE)
            {
                temp_pet.Study = MIN_VALUE;
            }
        }

        private static void UpdateHygene(Pet temp_pet, GameObject temp_GameObject)
        {
            temp_pet.Hygene += temp_GameObject.HygeneEffect;

            if (temp_pet.Hygene > MAX_VALUE)
            {
                temp_pet.Hygene = MAX_VALUE;
            }

            if (temp_pet.Hygene < MIN_VALUE)
            {
                temp_pet.Hygene = MIN_VALUE;
            }
        }

        private static void UpdateEnergy(Pet temp_pet, GameObject temp_GameObject)
        {
            temp_pet.Energy += temp_GameObject.EnergyEffect;

            if (temp_pet.Energy > MAX_VALUE)
            {
                temp_pet.Energy = MAX_VALUE;
            }

            if (temp_pet.Energy < MIN_VALUE)
            {
                temp_pet.Energy = MIN_VALUE;
            }
        }

        private static void UpdateHungry(Pet temp_pet, GameObject temp_GameObject)
        {
            temp_pet.Hungry += temp_GameObject.HungryEffect;

            if (temp_pet.Hungry > MAX_VALUE)
            {
                temp_pet.Hungry = MAX_VALUE;
            }

            if (temp_pet.Hungry < MIN_VALUE)
            {
                temp_pet.Hungry = MIN_VALUE;
            }
        }

        private static void UpdateHealth(Pet temp_pet, GameObject temp_GameObject)
        {
            //Update Health
            if (temp_GameObject.IsHealthy)
            {
                temp_pet.Healt += temp_GameObject.HealthEffect;
            }
            else if (!temp_GameObject.IsHealthy)
            {
                temp_pet.Healt -= temp_GameObject.HealthEffect;
            }

            if (temp_pet.Healt > MAX_VALUE)
            {
                temp_pet.Healt = MAX_VALUE;
            }

            if (temp_pet.Healt < MIN_VALUE)
            {
                temp_pet.Healt = MIN_VALUE;
            }
        }

        private static void UpdateFun(Pet temp_pet, int gameObjectId, GameObject temp_GameObject)
        {
            if (temp_pet.FavoriteFoodId == gameObjectId)
            {
                // Encrease Fun
                temp_pet.Fun += temp_GameObject.FunEffect;
            }
            else if (temp_pet.DislikedFoodId == gameObjectId)
            {
                // Decrese Fun
                temp_pet.Fun -= temp_GameObject.FunEffect;
            }

            if (temp_pet.Fun > MAX_VALUE)
            {
                temp_pet.Fun = MAX_VALUE;
            }

            if (temp_pet.Fun < MIN_VALUE)
            {
                temp_pet.Fun = MIN_VALUE;
            }
        }
    }
}
