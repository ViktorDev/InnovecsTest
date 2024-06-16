
using UniRx;
using UnityEngine;

namespace InnovecsTest
{
    public class Animal : IEntity
    {
        public Transform Transform { get; set; }
        public IBehaviour Behaviour { get; set; }

        public Animal(Transform transform)
        {
            Transform = transform;
        }



        public void Spawn(Vector3 position)
        {
            Transform.position = position;
            Debug.Log("Animal spawned at " + position);
        }
    }
}
