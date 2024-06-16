using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace InnovecsTest
{
    public class MoveBehaviour : IBehaviour
    {
        private GameData _gameData;
        private Vector3 _targetPosition;
        private IEntity _hero;

        public MoveBehaviour(GameData gameData, IEntity hero)
        {
            _gameData = gameData;
            _hero = hero;

            MessageBroker.Default.Receive<HeroClickedMessage>()
            .Subscribe(message => SetTargetPos(message.Position))
            .AddTo(_hero.Transform);
        }

        public void Update()
        {
            if ((_targetPosition - _hero.Transform.position).magnitude > 0.1f)
            {
                _hero.Transform.position = Vector3.MoveTowards(_hero.Transform.position, _targetPosition, _gameData.heroSpeed * Time.deltaTime);
            }
        }

        private void SetTargetPos(Vector3 position)
        {
            _targetPosition = position;
        }
    }
}
