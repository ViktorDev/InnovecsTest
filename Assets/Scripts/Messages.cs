using UnityEngine;

namespace InnovecsTest
{
    public class AnimalReachedYardMessage { }

    public class HeroClickedMessage
    {
        public Vector3 Position { get; set; }
    }

    public class AnimalStartFollow
    {
        public Animal Animal { get; set; }
        public Transform HeroTransform { get; set; }
    }
}