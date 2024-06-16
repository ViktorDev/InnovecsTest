using UnityEngine;

namespace InnovecsTest
{
    public class FollowBehaviour : IBehaviour
    {
        private Transform _heroTransform;
        private Animal _animal;
        private int _followsCount;
        private Vector3 _offset;

        public FollowBehaviour(Animal animal, Transform heroTransform, int followsCount)
        {
            _heroTransform = heroTransform;
            _followsCount = followsCount;
            _animal = animal;
            for (int i = 0; i < _followsCount; i++)
            {
                float angle = i * Mathf.PI * 2 / _followsCount;
                _offset = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * 0.4f;
            }
        }


        void IBehaviour.Update()
        {
            _animal.Transform.position = _heroTransform.position + _offset;
        }
    }
}
