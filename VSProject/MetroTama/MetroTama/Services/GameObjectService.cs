using MetroTama.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroTama.Services
{
    class GameObjectService
    {
        public static void UseObject(Pet temp_pet, int gameObjectId)
        {

            if (temp_pet.FavoriteFoodId == gameObjectId)
            {
                // Encrease Fun
            }
            else if (temp_pet.DislikedFoodId == gameObjectId)
            {
                // Decrese Fun
            }



        }
    }
}
