
using UnityEngine;

namespace InnovecsTest
{
    public class AnimalsFactory : IEntityFactory
    {
        private GameObject _animalPrefab;

        public AnimalsFactory(GameObject prefab)
        {
            _animalPrefab = prefab;
        }

        public IEntity CreateEntity()
        {
            GameObject _animalObject = Object.Instantiate(_animalPrefab);
            IEntity _entity = new Animal(_animalObject.transform);
            return _entity;
        }
    }
}
