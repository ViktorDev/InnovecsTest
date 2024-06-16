
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace InnovecsTest
{
    public class AnimalsController
    {
        private List<Animal> _animals = new List<Animal>();
        private List<Animal> _followAnimals = new List<Animal>();
        private GameData _gameData;

        public AnimalsController(List<Animal> animals, GameData gameData)
        {
            _animals = animals;
            _gameData = gameData;
            for (int i = 0; i < _animals.Count; i++)
            {
                _animals[i].Behaviour = new PatrolBehaviour(_animals[i], _gameData.animalSpeed);
            }

            MessageBroker.Default.Receive<AnimalStartFollow>()
             .Subscribe(ani => ChangeBehaviour(ani.Animal, ani.HeroTransform));
        }

        private void ChangeBehaviour(Animal animal, Transform heroTransform)
        {
            if (_followAnimals.Count < _gameData.maxAnimalsInGroup && animal.Behaviour is PatrolBehaviour)
            {
                _followAnimals.Add(animal);
                animal.Behaviour = new FollowBehaviour(animal, heroTransform, _followAnimals.Count);
            }
        }
    }
}