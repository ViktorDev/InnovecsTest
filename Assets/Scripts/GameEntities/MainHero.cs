using UnityEngine;

namespace InnovecsTest
{
    public class MainHero : IEntity
    {
        public Transform Transform => _transform;
        private Transform _transform;

        public MainHero(Transform transform)
        {
            _transform = transform;
        }
        public void Spawn(Vector3 position)
        {
            _transform.position = position;
            Debug.Log("MainHero spawned at " + position);
        }
    }
}
