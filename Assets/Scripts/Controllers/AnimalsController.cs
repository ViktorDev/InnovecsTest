
using System.Collections.Generic;
using UniRx;

namespace InnovecsTest
{
    public class AnimalsController
    {
        private List<Animal> _animals = new List<Animal>();
        private GameData _gameData;

        public AnimalsController(List<Animal> animals, GameData gameData)
        {
            _animals = animals;
            _gameData = gameData;
            for (int i = 0; i < _animals.Count; i++)
            {
                _animals[i].Behaviour = new PatrolBehaviour(_animals[i], _gameData.animalSpeed);
            }

            Observable.EveryUpdate().Subscribe(upd => { Update(); });
        }

        private void Update()
        {
            foreach (var animal in _animals)
            {
                animal.Behaviour.Update();
            }
        }
    }
}
