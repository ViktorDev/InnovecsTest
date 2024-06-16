using UnityEngine;

namespace InnovecsTest
{
    public class GameData : ScriptableObject
    {
        public GameObject heroPrefab;
        public GameObject animalPrefab;
        public int maxAnimalsInGroup = 5;
        public int initialAnimalCount = 10;
        public float heroSpeed = 5;
        public float animalSpeed = 1;
    }
}
