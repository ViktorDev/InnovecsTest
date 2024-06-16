
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace InnovecsTest
{
    public class MainHeroController
    {
        private GameData _gameData;
        private MainHero _hero;
        private Vector3 _targetPosition;

        public MainHeroController(MainHero hero, GameData gameData)
        {
            _gameData = gameData;
            _hero = hero;

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
        }
    }
}
