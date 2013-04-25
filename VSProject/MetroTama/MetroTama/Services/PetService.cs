using System;
using TamaDomain.Domain.Entities;
using TamaDomain.Domain.Repository;
using TamaDomain.Domain.Enumerator;

namespace MetroTama.Services
{
    class PetService
    {
        readonly PetRepository _petRepository = new PetRepository();

        public Pet GeneratePet()
        {
            int randomDislikeObject = new Random().Next(1,3);
            int randomLikeObject = new Random().Next(1, 3);
            while (randomLikeObject == randomDislikeObject)
            {
                randomLikeObject = new Random().Next(1, 3);
            }
            
            int randomGender = new Random().Next(1, 2);

            Pet pet = new Pet()
                {
                    Age = 0,
                    BirthDate = DateTime.Now,
                    Current = true,
                    Discipline = 0,
                    DislikeGameObjectId = randomDislikeObject,
                    Energy = 50,
                    FavoriteGameObjectId = randomLikeObject,
                    Gender = randomGender,
                    Health = 100,
                    Hygene = 100,
                    Hunger = 50,
                    LastUpdated = DateTime.Now,
                    Mood = 50,
                    PetStageId = (int) StageEnum.Baby,
                    Sleeping = false
                };

            return pet;
        }

    }
}
