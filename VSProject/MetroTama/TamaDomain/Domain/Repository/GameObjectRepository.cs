using MetroTama.Domain.Entities;
using System.Linq;
using TamaDomain.Domain.Enumerator;

namespace TamaDomain.Domain.Repository
{
   public class GameObjectRepository
    {
        public GameObject GetGameObject(GameObjectEnum enums)
        {
            using (var db = new SQLite.SQLiteConnection(Constants.DbPath))
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
