
using UnityEngine;

namespace InnovecsTest
{
    public class MainHeroFactory : IEntityFactory
    {
        private GameObject _heroPrefab;

        public MainHeroFactory(GameObject prefab)
        {
            _heroPrefab = prefab;
        }

        public IEntity CreateEntity()
        {
            GameObject _heroObject = Object.Instantiate(_heroPrefab);
            IEntity _entity = new MainHero(_heroObject.transform);
            return _entity;
        }
    }
}
