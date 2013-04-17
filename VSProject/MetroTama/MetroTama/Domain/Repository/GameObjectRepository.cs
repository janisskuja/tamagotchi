using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroTama.Domain.Entities;

namespace MetroTama.Domain.Repository
{
    class GameObjectRepository
    {
        public GameObject GetGameObject(int gameObjectId) {
            var objects = new Dictionary<int, GameObject>
                {
                    {1, GetObject(1, "Apple")},
                    {2, GetObject(2, "Burger")},
                    {3, GetObject(3, "Drink")},
                    {4, GetObject(4, "Ball")},
                    {5, GetObject(5, "Read")},
                    {6, GetObject(6, "Clean")},
                    {7, GetObject(7, "Medic")}
                };
            return objects[gameObjectId];
        }

        private static GameObject GetObject(int id, String name)
        {
            var gameObject = new GameObject {GameObjectId = id, Name = name};

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
                        gameObject.EnergyEffect = -10;
                        gameObject.StudyEffect = 1;
                    }
                    break;
                case 5: //Read
                    {
                        gameObject.IsHealthy = true;
                        gameObject.HungryEffect = 0;
                        gameObject.HealthEffect = 0;
                        gameObject.HygeneEffect = 0;
                        gameObject.FunEffect = -5;
                        gameObject.EnergyEffect = -10;
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
