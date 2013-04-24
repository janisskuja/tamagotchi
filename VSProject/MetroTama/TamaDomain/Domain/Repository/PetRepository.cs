using System;
using MetroTama.Domain.Entities;
using System.Linq;
using TamaDomain.Domain.Entities;

namespace TamaDomain.Domain.Repository
{
    public class PetRepository
    {
        StageRepository _stageRepo = new StageRepository();
        public int AddPet(Pet _pet)
        {
            //returns new ID
            int success;
            using (var db = new SQLite.SQLiteConnection(Constants.DbPath))
            {
                success = db.Insert(new Pet()
                {
                    PetStageId = _pet.PetStageId,
                    FavoriteGameObjectId = _pet.FavoriteGameObjectId,
                    DislikeGameObjectId = _pet.DislikeGameObjectId,
                    Name = _pet.Name,
                    Health = _pet.Health,
                    Hygene = _pet.Hygene,
                    Hunger = _pet.Hunger,
                    Energy = _pet.Energy,
                    Discipline = _pet.Discipline,
                    Mood = _pet.Mood,
                    Gender = _pet.Gender,
                    Age = _pet.Age,
                    Sleeping = _pet.Sleeping,
                    Current = _pet.Current,
                    BirthDate = _pet.BirthDate,
                    LastUpdated = _pet.LastUpdated
                });

            }
            return success;
        }
        
        public bool SetPetToSleep()
        {
            Pet pet = GetPet();
            if (pet == null)
            {
                return false;
            }
            pet.Sleeping = !pet.Sleeping;
            UpdateAllPet(pet);
            return pet.Sleeping;
        }

        public Pet GetPet()
        {
            using (var db = new SQLite.SQLiteConnection(Constants.DbPath))
            {
                Pet newPet = new Pet();
                try
                {
                    newPet = (db.Table<Pet>().Where(
                                p => p.Current == true)).SingleOrDefault();
                }
                catch
                {
                    newPet = null;
                }
                return newPet;
            }
        }


        public void UpdatePetFromBackground()
        {
            Pet pet = GetPet();
            if (pet == null)
            {
                return;
            }

            Stage petStage = _stageRepo.GetPetStage(pet.PetStageId);
            pet.Age = GetAge(pet);
            int age = pet.Age;
            if (petStage.AgeFrom >= age && petStage.AgeTo <= age)
            {
                Stage newStage = _stageRepo.GetPetNewStage(age);
                if (newStage != null)
                {
                    pet.PetStageId = newStage.StageId;
                }
            }
          //  pet.Health = CalculateHealth()


        }

        public static int GetAge(Pet pet)
        {
            // 1.
            // Parse the date and put in DateTime object.
            DateTime startDate = pet.BirthDate

            // 2.
            // Get the current DateTime.
            DateTime now = DateTime.Now;

            // 3.
            // Get the TimeSpan of the difference.
            TimeSpan elapsed = now.Subtract(startDate);

            // 4.
            // Get number of days ago.
            double daysAgo = elapsed.TotalDays;
            int age = Convert.ToInt32(daysAgo);
            return age;
        }

        public int UpdateAllPet(Pet t_Pet)
        {
            int success;
            using (var db = new SQLite.SQLiteConnection(Constants.DbPath))
            {
                success = db.Update(t_Pet);
            }
            return success;
        }
    }
}
