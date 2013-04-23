using System;
using MetroTama.Domain.Entities;
using MetroTama.Domain.Enumerator;
using MetroTama.Domain.Repository;

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
                    Energy = 100,
                    FavoriteGameObjectId = randomLikeObject,
                    Gender = randomGender,
                    Health = 100,
                    Hygene = 100,
                    Hunger = 100,
                    LastUpdated = DateTime.Now,
                    Mood = 100,
                    PetStageId = (int) StageEnum.Baby,
                    Sleeping = false
                };

            return pet;
        }
    }
}
