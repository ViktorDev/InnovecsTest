using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace InnovecsTest
{
    public class Collector
    {
        private GameData _gameData;
        private MainHero _hero;
        private List<Animal> _animals = new List<Animal>();
        private List<Animal> _followingAnimals = new List<Animal>();

        public Collector(GameData gameData, MainHero hero, List<Animal> animals)
        {
            _gameData = gameData;
            _hero = hero;
            _animals = animals;

            Observable.EveryUpdate().Subscribe(upd => { Check(); }).AddTo(_hero.Transform);
        }

        private void Check()
        {
            foreach (var animal in _animals)
            {
                if ((animal.Transform.position - _hero.Transform.position).magnitude < 0.3f)
                {
                    ChangeBehaviour(animal, _hero.Transform);
                    break;
                }
            }

            CheckYard();
        }

        private void CheckYard()
        {
            foreach (var animal in _followingAnimals)
            {
                if (animal.Transform.position.x >= 7f)
                {
                    MessageBroker.Default.Publish(new AnimalReachedYardMessage());

                    _followingAnimals.Remove(animal);
                    _animals.Add(animal);
                    animal.Transform.gameObject.SetActive(false);
                    animal.Behaviour = new PatrolBehaviour(animal, _gameData.animalSpeed);
                    animal.Transform.gameObject.SetActive(true);
                    break;
                }
            }
        }

        private void ChangeBehaviour(Animal animal, Transform heroTransform)
        {
            if (_followingAnimals.Count < _gameData.maxAnimalsInGroup && animal.Behaviour is PatrolBehaviour)
            {
                _followingAnimals.Add(animal);
                animal.Behaviour = new FollowBehaviour(animal, heroTransform, _followingAnimals.Count);
            }
        }
    }
}
