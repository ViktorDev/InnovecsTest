
using UnityEngine;

namespace InnovecsTest
{
    public interface IEntity
    {
        Transform Transform { get; set; }
        IBehaviour Behaviour { get; set; }
        void Spawn(Vector3 position);
    }
}
