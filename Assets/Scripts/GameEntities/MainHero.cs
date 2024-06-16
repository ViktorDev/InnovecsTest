using UnityEngine;

namespace InnovecsTest
{
    public class MainHero : IEntity
    {
        public Transform Transform { get; set; }
        public IBehaviour Behaviour { get; set; }

        public MainHero(Transform transform)
        {
            Transform = transform;
        }

        public void Spawn(Vector3 position)
        {
            Transform.position = position;
            Debug.Log("MainHero spawned at " + position);
        }
    }
}
