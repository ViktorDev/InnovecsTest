using System.Collections.Generic;
using UnityEngine;

namespace InnovecsTest
{
    public class SpawnManager
    {
        private GameData _gameData;
        public SpawnManager(GameData gameData)
        {
            _gameData = gameData;
        }

        public List<Animal> SpawnAnimals()
        {
            List<Animal> _animals = new List<Animal>();
            IEntityFactory _animalsFactory = new AnimalsFactory(_gameData.animalPrefab);

            for (int i = 0; i < _gameData.initialAnimalCount; i++)
            {
                Vector2 randomPosition = new Vector2(Random.Range(-5f, 5f), Random.Range(-5f, 5f));
                IEntity _animal = _animalsFactory.CreateEntity();
                _animal.Spawn(randomPosition);
                _animals.Add(_animal as Animal);
            }

            return _animals;
        }

        public MainHero SpawnHero()
        {
            IEntityFactory _heroFactory = new MainHeroFactory(_gameData.heroPrefab);
            IEntity _hero = _heroFactory.CreateEntity();
            _hero.Spawn(Vector3.zero);
            return _hero as MainHero;
        }
    }
}
