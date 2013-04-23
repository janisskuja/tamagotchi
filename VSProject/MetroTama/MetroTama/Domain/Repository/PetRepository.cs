using MetroTama.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroTama.Domain.Repository
{
    class PetRepository
    {
        public int AddPet( Pet _pet )
        {
            //returns new ID
            int success;
            using (var db = new SQLite.SQLiteConnection(App.DBPath))
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

        public Pet GetPet()
        {
            using (var db = new SQLite.SQLiteConnection(App.DBPath))
            {
                Pet newPet = new Pet();
                try
                {
                    newPet = (db.Table<Pet>().Where(
                                p => p.Current == true)).SingleOrDefault();
                }
                catch {
                    newPet = null;
                }
                return newPet;
            }
        }
        public int UpdateAllPet(Pet t_Pet)
        {
            int success;
            using (var db = new SQLite.SQLiteConnection(App.DBPath))
            {
                success = db.Update(t_Pet);
            }
            return success;
        }
    }
}
