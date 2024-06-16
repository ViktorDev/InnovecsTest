
using UnityEngine;

namespace InnovecsTest
{
    public class ResourceLoader : ILoader<GameData>
    {
        public GameData Load(string path)
        {
            GameData gameData = Resources.Load<GameData>(path);
            if (gameData == null)
            {
                Debug.LogError("Failed to load GameData from path: " + path);
            }
            return gameData;
        }
    }
}
