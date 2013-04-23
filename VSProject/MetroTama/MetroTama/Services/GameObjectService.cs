using MetroTama.Domain;
using MetroTama.Domain.Entities;
using MetroTama.Domain.Enumerator;
using MetroTama.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroTama.Services
{
    class GameObjectService
    {
        public void UseObject(Game1 game, GameObjectEnum gameObjectEnum)
        {
            GameObjectRepository _gameObjectRep = new GameObjectRepository();
            PetRepository _petRepository = new PetRepository();

            GameObject _gameObject = _gameObjectRep.GetGameObject(gameObjectEnum);
            Pet _pet = _petRepository.GetPet();

            _pet.Health += _gameObject.HealthEffect;
            _pet.Hunger += _gameObject.HungerEffect;
            _pet.Hygene += _gameObject.HygeneEffect;
            _pet.Discipline += _gameObject.DisciplineEffect;
            _pet.Mood += _gameObject.MoodEffect;
            _pet.Energy += _gameObject.EnergyEffect;

            _petRepository.UpdateAllPet(_pet);

            game._graphicsEnum = Content.Graphics.GraphicsEnum.EatingAnim;

        }
    }
}
