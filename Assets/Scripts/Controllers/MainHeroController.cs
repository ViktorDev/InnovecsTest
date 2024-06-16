
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace InnovecsTest
{
    public class MainHeroController
    {
        private GameData _gameData;
        private MainHero _hero;
        private List<Animal> _animals = new List<Animal>();
        private Vector3 _targetPosition;

        public MainHeroController(MainHero hero, List<Animal> animals, GameData gameData)
        {
            _gameData = gameData;
            _hero = hero;
            _animals = animals;

            MessageBroker.Default.Receive<HeroClickedMessage>()
              .Subscribe(message => SetTargetPos(message.Position))
              .AddTo(_hero.Transform);

            Observable.EveryUpdate().Subscribe(upd => { Move(); }).AddTo(_hero.Transform);
        }

        private void SetTargetPos(Vector3 position)
        {
            _targetPosition = position;
        }

        private void Move()
        {
            if ((_targetPosition - _hero.Transform.position).magnitude > 0.1f)
            {
                _hero.Transform.position = Vector3.MoveTowards(_hero.Transform.position, _targetPosition, _gameData.heroSpeed * Time.deltaTime);
            }

            foreach (var animal in _animals)
            {
                if ((animal.Transform.position - _hero.Transform.position).magnitude < 0.3f)
                {
                    MessageBroker.Default.Publish(new AnimalStartFollow { Animal = animal, HeroTransform = _hero.Transform });
                    break;
                }
            }

            CheckYard();
        }

        private void CheckYard()
        {
            if (_hero.Transform.position.x >= 7f)
            {
                MessageBroker.Default.Publish(new AnimalReachedYardMessage());
                //Destroy(gameObject);
            }
        }
    }
}
