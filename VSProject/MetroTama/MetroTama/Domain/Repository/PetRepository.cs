using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroTama.Domain.Entities;
using Microsoft.Xna.Framework.Graphics;
using MetroTama.Content.Graphics;

namespace MetroTama.Domain.Repository
{
    class PetRepository
    {
        public Pet GetPet() {
            var tempStageRepository = new StageRepository();
            var tempStage = tempStageRepository.GetStage();

            var pet = new Pet
                {
                    PetId = 1,
                    Name = "Tamo",
                    FavoriteFoodId = 1,
                    DislikedFoodId = 2,
                    Hungry = 100,
                    Healt = 100,
                    Hygene = 100,
                    Fun = 100,
                    Energy = 100,
                    Study = 0,
                    Stage = tempStage,
                    IsSick = false
                };
            var animations = new List<GraphicsEnum> {GraphicsEnum.Celebrate, GraphicsEnum.Player};
            pet.Animations = animations;
            return pet;
        }
    }
}
