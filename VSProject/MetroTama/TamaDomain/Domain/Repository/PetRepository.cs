using System;
using MetroTama.Domain.Entities;
using System.Linq;
using TamaDomain.Domain.Entities;

namespace TamaDomain.Domain.Repository
{
    public class PetRepository
    {
        StageRepository _stageRepo = new StageRepository();
        SayTextRepository _sayTextRepository = new SayTextRepository();
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
                    LastUpdated = _pet.LastUpdated,
                    Dead = false
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


        public String UpdatePetFromBackground()
        {
            Pet pet = GetPet();
            if (pet == null)
            {
                return "Your lovely pet is missing :(";
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
            if (pet.Sleeping)
            {

                pet.Energy += pet.Energy < 100 ? 25 : 0;
                pet.Health += pet.Health < 100 ? 15 : 0;
                pet.Hunger -= pet.Hunger > 0 ? 15 : 0;
                pet.Mood -= pet.Mood > 0 ? 25 : 0;
            }
            else
            {
                pet.Health -= CalculateHealth(pet, petStage) >= 0 ? CalculateHealth(pet, petStage) : 5;
                pet.Hunger -= CalculateHunger(pet, petStage) >= 0 ? CalculateHunger(pet, petStage) : 5;
                pet.Hygene -= CalculateHygene(pet, petStage) >= 0 ? CalculateHygene(pet, petStage) : 5;
                pet.Energy -= CalculateEnergy(pet, petStage) >= 0 ? CalculateEnergy(pet, petStage) : 5;
                pet.Mood -= CalculateMood(pet, petStage) >= 0 ? CalculateMood(pet, petStage) : 5;
                pet.Discipline -= CalculateDiscipline(pet, petStage) >= 0 ? CalculateDiscipline(pet, petStage) : 5;
            }
            if (pet.Health <= 0)
            {
                pet.Current = false;
                pet.Dead = true;
            }
            UpdateAllPet(pet);
            int parameter = new Random().Next(1, 6);
            return _sayTextRepository.getText(pet, parameter);
        }

        private static int CalculateDiscipline(Pet pet, Stage petStage)
        {
            return pet.Discipline > 0 ? (GetMinutesFromLastUpdated(pet.LastUpdated) - petStage.DisciplineInterval) * petStage.DisciplineCoeff : 0;
        }

        private static int CalculateMood(Pet pet, Stage petStage)
        {
            return pet.Mood > 0 ? (GetMinutesFromLastUpdated(pet.LastUpdated) - petStage.MoodInterval) * petStage.MoodCoeff : 0;
        }

        private static int CalculateEnergy(Pet pet, Stage petStage)
        {
            return pet.Energy > 0 ? (GetMinutesFromLastUpdated(pet.LastUpdated) - petStage.EnergyInterval) * petStage.EnergyCoeff : 0;
        }

        private static int CalculateHygene(Pet pet, Stage petStage)
        {
            return pet.Hygene > 0 ? (GetMinutesFromLastUpdated(pet.LastUpdated) - petStage.HygeneInterval) * petStage.HygeneCoeff : 0;
        }

        private static int CalculateHunger(Pet pet, Stage petStage)
        {
            return pet.Hunger > 0 ? (GetMinutesFromLastUpdated(pet.LastUpdated) - petStage.HungerInterval) * petStage.HungerCoeff : 0;
        }

        private static int CalculateHealth(Pet pet, Stage petStage)
        {
            return pet.Health > 0 ? (GetMinutesFromLastUpdated(pet.LastUpdated) - petStage.HealthInterval) * petStage.HealthCoeff : 0;
        }

        public static int GetAge(Pet pet)
        {
            // 1.
            // Parse the date and put in DateTime object.
            DateTime startDate = pet.BirthDate;

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

        private static int GetMinutesFromLastUpdated(DateTime lastUpdated)
        {
            TimeSpan elapsed = DateTime.Now.Subtract(lastUpdated);
            double minutesAgo = elapsed.TotalMinutes;
            int minutes = Convert.ToInt32(minutesAgo);
            return minutes;
        }


        public int UpdateAllPet(Pet t_Pet)
        {
            int success;
            t_Pet.LastUpdated = DateTime.Now;
            using (var db = new SQLite.SQLiteConnection(Constants.DbPath))
            {
                success = db.Update(t_Pet);
            }
            return success;
        }
    }
}
