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
        public int AddPet( int t_PetStageId, int t_FavoriteGameObjectId, int t_DislikeGameObjectId, string t_Name, int t_Health,
                                    int t_Hygene, int t_Hunger, int t_Energy, int t_Discipline, int t_Mood, int t_Gender, int t_Age, bool t_Sleeping,
                                    bool t_Current, DateTime t_BirthDate, DateTime t_LastUpdated )
        {
            //returns new ID
            int success;
            using (var db = new SQLite.SQLiteConnection(App.DBPath))
            {
                    success = db.Insert(new Pet()
                    {
                        PetStageId = t_PetStageId,
                        FavoriteGameObjectId = t_FavoriteGameObjectId,
                        DislikeGameObjectId = t_DislikeGameObjectId,
                        Name = t_Name,
                        Health = t_Health,
                        Hygene = t_Hygene,
                        Hunger = t_Hunger,
                        Energy = t_Energy,
                        Discipline = t_Discipline,
                        Mood = t_Mood,
                        Gender = t_Gender,
                        Age = t_Age,
                        Sleeping = t_Sleeping,
                        Current = t_Current,
                        BirthDate = t_BirthDate,
                        LastUpdated = t_LastUpdated
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
