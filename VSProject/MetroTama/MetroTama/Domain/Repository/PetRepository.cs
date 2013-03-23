using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace MetroTama.Domain.Repository
{
    class PetRepository
    {
        public Pet GetPet() {
            StageRepository temp_StageRepository = new StageRepository();
            Stage temp_stage = temp_StageRepository.GetStage();

            Pet pet = new Pet();
            pet.PetId = 1;
            pet.Name = "Tamo";
            pet.FavoriteFoodId = 1;
            pet.DislikedFoodId = 2;
            pet.Hungry = 100;
            pet.Healt = 100;
            pet.Hygene = 100;
            pet.Fun = 100;
            pet.Energy = 100;
            pet.Study = 100;
            pet.Stage = temp_stage;
            pet.animationData = new Services.Animation.AnimationData();
            return pet;
        }
    }
}
