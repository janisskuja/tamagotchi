using MetroTama.Domain.Entities;
using MetroTama.Domain.Enumerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroTama.Domain.Repository
{
    class GameObjectRepository
    {
        public GameObject GetGameObject(GameObjectEnum enums)
        {
            using (var db = new SQLite.SQLiteConnection(App.DBPath))
            {
                GameObject newObject = new GameObject();
                try
                {
                    newObject = (db.Table<GameObject>().Where(
                                g => g.GameObjectId == (int)enums )).SingleOrDefault();
                }
                catch
                {
                    newObject = null;
                }
                return newObject;
            }
        }
    }
}
