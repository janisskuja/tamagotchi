using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroTama.Domain.Repository
{
    class GameObjectRepository
    {
        public GameObject GetGameObject(int gameObjectId) {
            Dictionary<int, GameObject> objects = new Dictionary<int, GameObject>();
            objects.Add(1, getObject(1, "Apple"));
            objects.Add(2, getObject(2, "Burger"));
            objects.Add(2, getObject(3, "Drink"));
            return objects[gameObjectId];
        }

        private static GameObject getObject(int id, String Name)
        {
            GameObject gameObject = new GameObject();
            gameObject.GameObjectId = id;
            gameObject.Name = Name;
            gameObject.IsHealthy = true;
            gameObject.HungryEffect = 1;
            gameObject.HealthEffect = 1;
            gameObject.HygeneEffect = 1;
            gameObject.FunEffect = 1;
            gameObject.EnergyEffect = 1;
            gameObject.StudyEffect = 1;
            return gameObject;
        }
    }
}
