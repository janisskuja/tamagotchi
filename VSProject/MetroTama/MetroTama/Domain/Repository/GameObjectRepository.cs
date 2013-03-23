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
            objects.Add(3, getObject(3, "Drink"));
            objects.Add(4, getObject(4, "Ball"));
            objects.Add(5, getObject(5, "Read"));
            objects.Add(6, getObject(6, "Clean"));
            objects.Add(7, getObject(7, "Medic"));
            return objects[gameObjectId];
        }

        private static GameObject getObject(int id, String Name)
        {
            GameObject gameObject = new GameObject();
            gameObject.GameObjectId = id;
            gameObject.Name = Name;

            switch(id)
            {
                case 1: //Apple
                    {
                        gameObject.IsHealthy = true;
                        gameObject.HungryEffect = 10;
                        gameObject.HealthEffect = 5;
                        gameObject.HygeneEffect = 0;
                        gameObject.FunEffect = 5;
                        gameObject.EnergyEffect = 1;
                        gameObject.StudyEffect = 0;
                    }
                    break;
                case 2: //Burger
                    {
                        gameObject.IsHealthy = false;
                        gameObject.HungryEffect = 25;
                        gameObject.HealthEffect = 3;
                        gameObject.HygeneEffect = -2;
                        gameObject.FunEffect = 7;
                        gameObject.EnergyEffect = 2;
                        gameObject.StudyEffect = 0;
                    }
                    break;
                case 3: //Drink
                    {
                        gameObject.IsHealthy = true;
                        gameObject.HungryEffect = 9;
                        gameObject.HealthEffect = 2;
                        gameObject.HygeneEffect = 0;
                        gameObject.FunEffect = 2;
                        gameObject.EnergyEffect = 5;
                        gameObject.StudyEffect = 0;
                    }
                    break;
                case 4: //Ball
                    {
                        gameObject.IsHealthy = true;
                        gameObject.HungryEffect = 0;
                        gameObject.HealthEffect = 2;
                        gameObject.HygeneEffect = -2;
                        gameObject.FunEffect = 10;
                        gameObject.EnergyEffect = -2;
                        gameObject.StudyEffect = 1;
                    }
                    break;
                case 5: //Read
                    {
                        gameObject.IsHealthy = true;
                        gameObject.HungryEffect = 0;
                        gameObject.HealthEffect = 0;
                        gameObject.HygeneEffect = 0;
                        gameObject.FunEffect = 5;
                        gameObject.EnergyEffect = 0;
                        gameObject.StudyEffect = 20;
                    }
                    break;
                case 6: //Clean
                    {
                        gameObject.IsHealthy = true;
                        gameObject.HungryEffect = 0;
                        gameObject.HealthEffect = 0;
                        gameObject.HygeneEffect = 40;
                        gameObject.FunEffect = 0;
                        gameObject.EnergyEffect = 0;
                        gameObject.StudyEffect = 0;
                    }
                    break;
                case 7: //Medic
                    {
                        gameObject.IsHealthy = true;
                        gameObject.HungryEffect = 0;
                        gameObject.HealthEffect = 60;
                        gameObject.HygeneEffect = 0;
                        gameObject.FunEffect = 0;
                        gameObject.EnergyEffect = 0;
                        gameObject.StudyEffect = 0;
                    }
                    break;
                default:
                    {
                        gameObject.IsHealthy = true;
                        gameObject.HungryEffect = 0;
                        gameObject.HealthEffect = 0;
                        gameObject.HygeneEffect = 0;
                        gameObject.FunEffect = 0;
                        gameObject.EnergyEffect = 0;
                        gameObject.StudyEffect = 0;
                    }
                    break;
            }
            return gameObject;
        }
    }
}
