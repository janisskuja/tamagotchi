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
        public void UseObject(Pet temp_pet, int gameObjectId)
        {
            GameObjectRepository temp_GameObjectRepository = new GameObjectRepository();
            GameObject temp_GameObject = temp_GameObjectRepository.GetGameObject(gameObjectId);
           
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

            //Update Health
            if(temp_GameObject.IsHealthy)
            {
                temp_pet.Healt += temp_GameObject.HealthEffect;
            }
            else if(!temp_GameObject.IsHealthy)
            {
                temp_pet.Healt -= temp_GameObject.HealthEffect;
            }

            //update other stats
            temp_pet.Hungry += temp_GameObject.HungryEffect;
            temp_pet.Energy += temp_GameObject.EnergyEffect;
            temp_pet.Hygene += temp_GameObject.HygeneEffect;
            temp_pet.Study += temp_GameObject.StudyEffect;
        }
    }
}
