using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroTama.Domain.Repository
{
    class PetRepository
    {
        public Pet GetPet() {
            Pet pet = new Pet();
            pet.PetId = 1;
            pet.Name = "Tamo";
            pet.FavoriteFoodId = 1;
            pet.DislikedFoodId = 2;
            return pet;
        }
    }
}
