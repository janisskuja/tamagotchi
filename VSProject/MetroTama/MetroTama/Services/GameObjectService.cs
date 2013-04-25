using System;
using MetroTama.Domain.Entities;
using TamaDomain.Domain.Entities;
using TamaDomain.Domain.Enumerator;
using TamaDomain.Domain.Repository;

namespace MetroTama.Services
{
    class GameObjectService
    {
        PetRepository _petRepository = new PetRepository();
        SayTextRepository _sayTextRepository = new SayTextRepository();

        public void UseObject(Game1 game, GameObjectEnum gameObjectEnum)
        {
            int MAX_VALUE = 100;
            int MED_VALUE = 50;


            Pet _pet = _petRepository.GetPet();
            if (_pet.Sleeping)
            {
                return;
            }
            switch (gameObjectEnum)
            {
                case GameObjectEnum.Apple:
                    {
                        if (_pet.Hunger < MAX_VALUE)
                        {
                            UpdatePet(_pet, gameObjectEnum);
                            game._graphicsEnum = Content.Graphics.GraphicsEnum.EatingAnim;
                        }
                        else
                        {
                            //Saytext Method
                        }
                    }
                    break;
                case GameObjectEnum.Ball:
                    {
                        if (_pet.Mood < MAX_VALUE && _pet.Energy > 0 && _pet.Hunger > 0)
                        {
                            UpdatePet(_pet, gameObjectEnum);
                            //game._graphicsEnum = Content.Graphics.GraphicsEnum.Player;
                        }
                        else
                        {
                            //Saytext Method
                        }
                    }
                    break;
                case GameObjectEnum.Book:
                    {
                        if (_pet.Discipline < MAX_VALUE && _pet.Energy > 0 && _pet.Hunger > 0)
                        {
                            UpdatePet(_pet, gameObjectEnum);
                            //game._graphicsEnum = Content.Graphics.GraphicsEnum.Read;
                        }
                        else
                        {
                            //Saytext Method
                        }
                    }
                    break;
                case GameObjectEnum.Burger:
                    {
                        if (_pet.Hunger < MAX_VALUE)
                        {
                            UpdatePet(_pet, gameObjectEnum);
                            game._graphicsEnum = Content.Graphics.GraphicsEnum.EatingAnim;
                        }
                        else
                        {
                            //Saytext Method
                        }
                    }
                    break;
                case GameObjectEnum.Light:
                    UpdatePet(_pet, gameObjectEnum);
                    break;
                case GameObjectEnum.Medkit:
                    {
                        if (_pet.Health < MED_VALUE)
                        {
                            UpdatePet(_pet, gameObjectEnum);
                            //game._graphicsEnum = Content.Graphics.GraphicsEnum.Heal;
                        }
                        else
                        {
                            //Saytext Method
                        }
                    }
                    break;
                case GameObjectEnum.Soap:
                    {
                        if (_pet.Hygene < MAX_VALUE)
                        {
                            UpdatePet(_pet, gameObjectEnum);
                            //game._graphicsEnum = Content.Graphics.GraphicsEnum.Wash;
                        }
                        else
                        {
                            //Saytext Method
                        }
                    }
                    break;
                case GameObjectEnum.Watter:
                    {
                        if (_pet.Hunger < MAX_VALUE)
                        {
                            UpdatePet(_pet, gameObjectEnum);
                            game._graphicsEnum = Content.Graphics.GraphicsEnum.EatingAnim;
                        }
                        else
                        {
                            //Saytext Method
                        }
                    }
                    break;
                default:
                    game._graphicsEnum = Content.Graphics.GraphicsEnum.IdleAnim;
                    break;
            }

            _petRepository.UpdateAllPet(_pet);
            SaySomeText(game, _pet);
        }

        private void SaySomeText(Game1 game, Pet pet)
        {
            game._sayText = _sayTextRepository.getText(pet, new Random().Next(1, 6));
            game._showMessage = true;
        }

        private static void UpdatePet(Pet _pet, GameObjectEnum gameObjectEnum)
        {
            GameObjectRepository _gameObjectRep = new GameObjectRepository();
            GameObject _gameObject = _gameObjectRep.GetGameObject(gameObjectEnum);

            _pet.Health += _gameObject.HealthEffect;
            _pet.Hunger += _gameObject.HungerEffect;
            _pet.Hygene += _gameObject.HygeneEffect;
            _pet.Discipline += _gameObject.DisciplineEffect;
            _pet.Mood += _gameObject.MoodEffect;
            _pet.Energy += _gameObject.EnergyEffect;
        }
    }
}
