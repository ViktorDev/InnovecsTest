using UnityEngine;

namespace InnovecsTest
{
    public class PatrolBehaviour : IBehaviour
    {
        private Animal _animal;
        private Vector3 _targetPosition;
        private float _speed;

        public PatrolBehaviour(Animal animal, float speed)
        {
            _animal = animal;
            _targetPosition = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0);
            _animal.Transform.position = _targetPosition;
            _speed = speed;
        }

        void IBehaviour.Update()
        {
            if ((_targetPosition - _animal.Transform.position).magnitude > 0.1f)
            {
                _animal.Transform.position = Vector3.MoveTowards(_animal.Transform.position, _targetPosition, _speed * Time.deltaTime);
            }
            else
            {
                Vector3 randomPosition = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0);
                _targetPosition = randomPosition;
            }
        }
    }
}
