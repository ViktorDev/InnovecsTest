
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace InnovecsTest
{
    public class MainHeroController
    {
        private IEntity _hero;
        public MainHeroController(IEntity hero, GameData gameData)
        {
            _hero = hero;
            _hero.Behaviour = new MoveBehaviour(gameData, _hero);

            Observable.EveryUpdate().Subscribe(upd => { Update(); }).AddTo(hero.Transform);
        }

        private void Update()
        {
            _hero.Behaviour.Update();
        }
    }
}
