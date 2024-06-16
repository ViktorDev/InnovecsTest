
using UniRx;
using UnityEngine;

namespace InnovecsTest
{
    public class Animal : IEntity
    {
        public IBehaviour Behaviour
        {
            get
            {
                return _behaviour;
            }
            set
            {
                _behaviour = value;
            }
        }
        private IBehaviour _behaviour;
        public Transform Transform => _transform;
        private Transform _transform;

        public Animal(Transform transform)
        {
            _transform = transform;
        }

        public void Spawn(Vector3 position)
        {
            _transform.position = position;
            Debug.Log("Animal spawned at " + position);
        }
    }
}
