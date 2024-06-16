using UnityEngine;
using System.Collections.Generic;
using InnovecsTest.Load;

namespace InnovecsTest
{
    public class Bootstrap : MonoBehaviour
    {
        private GameData _gameData;

        private void Start()
        {
            LoadData();
            SpawnEninies();
        }

        private void LoadData()
        {
            ILoader<GameData> _loader = new ResourceLoader();
            _gameData = _loader.Load("GameData");
        }

        private void SpawnEninies()
        {
            SpawnManager _spawnManager = new SpawnManager(_gameData);

            List<Animal> _animals = _spawnManager.SpawnAnimals();
            MainHero _hero = _spawnManager.SpawnHero();

            MainHeroController _heroController = new MainHeroController(_hero, _gameData);
            AnimalsController _animalsController = new AnimalsController(_animals, _gameData);
            Collector _collector = new Collector(_gameData, _hero, _animals);
        }
    }
}